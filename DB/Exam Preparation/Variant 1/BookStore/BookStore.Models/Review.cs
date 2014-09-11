namespace BookStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

        public virtual Book Book { get; set; }

        [ForeignKey("Author")]
        public int? AuthorID { get; set; }              //int?: an author could be anonymous

        public virtual Author Author { get; set; }
    }
}
