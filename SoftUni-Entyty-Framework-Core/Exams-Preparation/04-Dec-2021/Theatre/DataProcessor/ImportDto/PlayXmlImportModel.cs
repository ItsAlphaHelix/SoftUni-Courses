
namespace Theatre.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Play")]
    public class PlayXmlImportModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}
