﻿namespace WeaponsFactory.Models.SqlModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        private ICollection<Weapon> weapons;

        public Manufacturer()
        {
            this.weapons = new HashSet<Weapon>();
        }

        [Key]
        [Column("ID")]
        public int ManufacturerId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Weapon> Weapons
        {
            get
            {
                return this.weapons;
            }

            set
            {
                this.weapons = value;
            }
        }
    }
}
