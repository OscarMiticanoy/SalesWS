using System.ComponentModel.DataAnnotations;

namespace SalesWS.DTOs
{
    public class SalesDatePrediction
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder {  get; set; }
    }
}
