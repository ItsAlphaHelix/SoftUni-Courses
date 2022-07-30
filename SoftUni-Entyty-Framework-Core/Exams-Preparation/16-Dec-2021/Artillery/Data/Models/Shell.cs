
namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }
        public int Id { get; set; }

        public double ShellWeight { get; set; }

        [Required]
        public string Caliber { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}

    //• Id – integer, Primary Key
    //• ShellWeight – double in range  [2…1_680] (required)
    //• Caliber – text with length [4…30] (required)
    //• Guns – a collection of Gun
