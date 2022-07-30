namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Shell")]
    public class ShellXmlImportModel
    {
        [Range(2, 2000)]
        public double ShellWeight { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Caliber { get; set; }
    }
}
