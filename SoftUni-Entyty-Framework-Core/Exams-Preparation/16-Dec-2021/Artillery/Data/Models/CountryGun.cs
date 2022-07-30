
namespace Artillery.Data.Models
{
    using System;
    public class CountryGun
    {
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int GunId { get; set; }

        public virtual Gun Gun { get; set; }
    }
}
