
namespace CarDealer.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SaleDto
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public decimal Discount { get; set; }
    }
}
