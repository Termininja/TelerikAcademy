namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(20)]
        [Required]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("Dealer")]
        public int DealerID { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
