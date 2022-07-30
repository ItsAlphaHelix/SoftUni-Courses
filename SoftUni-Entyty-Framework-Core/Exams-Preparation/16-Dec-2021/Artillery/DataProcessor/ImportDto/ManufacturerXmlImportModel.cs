
namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Manufacturer")]
    public class ManufacturerXmlImportModel
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string ManufacturerName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Founded { get; set; }
    }
}
