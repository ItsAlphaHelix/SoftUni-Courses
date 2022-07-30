namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }
        public int Id { get; set; }

        [Required]
        public string ManufacturerName { get; set; }

        [Required]
        public string Founded { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
