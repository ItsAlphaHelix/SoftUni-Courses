using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public PositionType PositionType { get; set; }

        public BestSkillType BestSkillType { get; set; }

        public int CoachId { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
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