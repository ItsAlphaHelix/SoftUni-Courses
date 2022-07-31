namespace Theatre.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [XmlType("Cast")]
    public class CastXmlImportModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"\+44-[\d]{2}-[\d]{3}-[\d]{4}")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Play")]
        public int PlayId { get; set; }
    }
}
