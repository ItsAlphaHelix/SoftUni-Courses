namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }
        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; }

        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}

    //• Id – integer, Primary Key
    //• CountryName – text with length [4, 60] (required)
    //• ArmySize – integer in the range[50_000….10_000_000] (required)
    //• CountriesGuns – a collection of CountryGun
