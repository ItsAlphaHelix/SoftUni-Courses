using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketJsonImportModel
    {
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }

        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [ForeignKey("Play")]
        public int PlayId { get; set; }
    }
}