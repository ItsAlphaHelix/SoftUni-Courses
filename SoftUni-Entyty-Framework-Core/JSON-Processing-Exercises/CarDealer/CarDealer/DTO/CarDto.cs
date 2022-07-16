
namespace CarDealer.DTO
{
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int TravelledDistance { get; set; }

        public List<int> PartsId { get; set; }
    }
}
