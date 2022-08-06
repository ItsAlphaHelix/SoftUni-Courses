using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerXmlImportModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string ContractStartDate { get; set; }

        [Required]
        public string ContractEndDate { get; set; }

       //[Range(0, 4)]
       [Required]
        public string BestSkillType { get; set; }

        //[Range(0, 3)]
        [Required]
        public string PositionType { get; set; }
    }
}

//• Id – integer, Primary Key
//• Name – text with length [2, 40] (required)
//• ContractStartDate – date and time (required)
//• ContractEndDate – date and time (required)
//• PositionType – enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required)
//• BestSkillType – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required)
//• CoachId – integer, foreign key(required)
//• Coach – Coach 
//• TeamsFootballers – collection of type TeamFootballer