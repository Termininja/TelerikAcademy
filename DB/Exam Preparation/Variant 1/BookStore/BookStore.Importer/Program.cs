namespace BookStore.Importer
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using BookStore.Data;
    using BookStore.Models;

    public class Program
    {
        private static BookStoreDbContext db;

        public static void Main()
        {
            Console.WriteLine("USE .!!!");
            db = new BookStoreDbContext();

            //XmlImporter();
            //XmlSearcher();
        }

        private static void XmlSearcher()
        {
            var xmlQueries = XElement.Load("../../../reviews-queries.xml").Elements();
            var result = new XElement("search-results");

            foreach (var xmlQuery in xmlQueries)
            {
                var queryInReviews = db.Reviews.AsQueryable();

                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    var startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    var endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);

                    queryInReviews = queryInReviews.Where(r => startDate <= r.CreatedOn && r.CreatedOn <= endDate);
                }
                else if (xmlQuery.Attribute("type").Value == "by-author")
                {
                    var authorName = xmlQuery.Element("author-name").Value;

                    queryInReviews = queryInReviews.Where(r => r.Author.Name == authorName);
                }

                var resultSet = queryInReviews
                    .OrderBy(o => o.CreatedOn)
                    .ThenBy(o => o.Content)
                    .Select(s => new
                        {
                            Date = s.CreatedOn,
                            Content = s.Content,
                            Book = new
                            {
                                Title = s.Book.Title,
                                Authors = s.Book.Authors.AsQueryable().OrderBy(o => o.Name).Select(a => a.Name),
                                ISBN = s.Book.ISBN,
                                URL = s.Book.WebSite
                            },
                        }).ToList();

                var xmlResultSet = new XElement("result-set");
                foreach (var reviewInResult in resultSet)
                {
                    var xmlReview = new XElement("review");
                    xmlReview.Add(new XElement("date", reviewInResult.Date.ToString("d-MMM-yyyy")));
                    xmlReview.Add(new XElement("content", reviewInResult.Content));

                    var book = new XElement("book");
                    //book.Add(new XAttribute("attributeName", "attributeValue"));      //add attribute

                    // title is mandatory
                    book.Add(new XElement("title", reviewInResult.Book.Title));

                    if (reviewInResult.Book.Authors.ToList().Count > 0)
                    {
                        book.Add(new XElement("authors", string.Join(", ", reviewInResult.Book.Authors)));
                    }

                    if (reviewInResult.Book.ISBN != null)
                    {
                        book.Add(new XElement("isbn", reviewInResult.Book.ISBN));
                    }

                    if (reviewInResult.Book.URL != null)
                    {
                        book.Add(new XElement("url", reviewInResult.Book.URL));
                    }

                    xmlReview.Add(book);
                    xmlResultSet.Add(xmlReview);
                }

                result.Add(xmlResultSet);
            }

            result.Save("../../../reviews-search-results.xml");
        }

        private static void XmlImporter()
        {
            var xmlBooks = XElement.Load("../../../complex-books.xml").Elements();

            foreach (var xmlBook in xmlBooks)
            {
                var currentSqlBook = new Book();

                // the title is mandatory
                currentSqlBook.Title = xmlBook.Element("title").Value;

                var isbn = xmlBook.Element("isbn");
                if (isbn != null)
                {
                    var bookExists = db.Books.Any(b => b.ISBN == isbn.Value);       //check for unique
                    if (bookExists)
                    {
                        throw new ArgumentException("ISBN already exists!");
                    }

                    currentSqlBook.ISBN = isbn.Value;
                }

                var price = xmlBook.Element("price");
                if (price != null)
                {
                    currentSqlBook.Price = decimal.Parse(price.Value);
                }

                var webSite = xmlBook.Element("web-site");
                if (webSite != null)
                {
                    currentSqlBook.WebSite = webSite.Value;
                }

                var xmlAuthors = xmlBook.Element("authors");
                if (xmlAuthors != null)
                {
                    var authors = xmlAuthors.Elements("author");
                    foreach (var xmlAuthor in authors)
                    {
                        var authorName = xmlAuthor.Value;
                        currentSqlBook.Authors.Add(GetAuthor(authorName));
                    }
                }

                var xmlReviews = xmlBook.Element("reviews");
                if (xmlReviews != null)
                {
                    var reviews = xmlReviews.Elements("review");
                    foreach (var xmlReview in reviews)
                    {
                        var reviewDate = xmlReview.Attribute("date");
                        var authorName = xmlReview.Attribute("author");

                        var review = new Review
                        {
                            Content = xmlReview.Value,
                            CreatedOn = reviewDate == null ? DateTime.Now : DateTime.Parse(reviewDate.Value)
                        };

                        if (authorName != null)
                        {
                            review.Author = GetAuthor(authorName.Value);
                        }

                        currentSqlBook.Reviews.Add(review);
                    }
                }

                db.Books.Add(currentSqlBook);
                db.SaveChanges();
            }
        }

        public static Author GetAuthor(string authorName)
        {
            var author = db.Authors.FirstOrDefault(a => a.Name == authorName);

            if (author == null)
            {
                author = new Author { Name = authorName };
            }

            return author;
        }
    }
}