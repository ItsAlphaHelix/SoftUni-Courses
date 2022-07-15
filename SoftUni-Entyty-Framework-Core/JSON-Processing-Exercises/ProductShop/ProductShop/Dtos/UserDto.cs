
namespace ProductShop.Models.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }
    }
}
