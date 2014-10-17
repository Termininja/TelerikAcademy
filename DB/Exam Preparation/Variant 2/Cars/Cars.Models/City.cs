namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(10)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Dealer")]
        public int DealerID { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
