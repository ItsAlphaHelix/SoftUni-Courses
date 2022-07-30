namespace Artillery.DataProcessor.ImportDto
{
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GunJsonImportModel
    {
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        [Range(100, 1350000)]
        public int GunWeight { get; set; }

        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(1, 100000)]
        public int Range { get; set; }

        public string GunType { get; set; }

        [ForeignKey("Shell")]
        public int ShellId { get; set; }

        public IEnumerable<CountryJsonImportModel> Countries { get; set; }
    }
}
