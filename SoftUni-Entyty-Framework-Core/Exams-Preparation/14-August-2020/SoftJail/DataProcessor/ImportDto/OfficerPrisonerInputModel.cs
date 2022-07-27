using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerPrisonerInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [EnumDataType(typeof(Position))]
        public string Position { get; set; }

        [EnumDataType(typeof(Weapon))]
        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        [XmlArray]
        public PrisonerIdInputModel[] Prisoners { get; set; }
    }
}

//< Officers >
//  < Officer >
//    < Name > Minerva Kitchingman </ Name >
   
//       < Money > 2582 </ Money >
   
//       < Position > Invalid </ Position >
   
//       < Weapon > ChainRifle </ Weapon >
   
//       < DepartmentId > 2 </ DepartmentId >
   
//       < Prisoners >
   
//         < Prisoner id = "15" />
    
//        </ Prisoners >
