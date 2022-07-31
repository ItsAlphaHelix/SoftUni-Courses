namespace Theatre.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Cast
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }

        public virtual Play Play { get; set; }
    }
}

    //• Id – integer, Primary Key
    //• FullName – text with length [4, 30] (required)
    //• IsMainCharacter – Boolean represents if the actor plays the main character in a play (required)
    //• PhoneNumber - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}".Valid phone numbers are: +44 - 53 - 468 - 3479, +44 - 91 - 842 - 6054, +44 - 59 - 742 - 3119(required)
    //• PlayId - integer, foreign key(required)
