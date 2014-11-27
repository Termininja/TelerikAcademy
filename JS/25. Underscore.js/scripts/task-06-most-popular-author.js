define(function () {
    console.log('');
    console.info(
        'Task 06. By a given collection of books, find the most popular ' +
        'author (the author with the highest number of books).'
    );

    // Find the most popular author
    console.log('Most popular author: ' + getMostPopularAuthor(books));

    function getMostPopularAuthor(books) {
        return _.chain(books).groupBy('author').sortBy(function (group) {
            return group.length;
        }).reverse().value()[0][0].author;
    }
});