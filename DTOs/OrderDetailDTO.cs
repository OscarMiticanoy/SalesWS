using SalesWS.Contexts;

namespace SalesWS.DTOs
{
    public class OrderDetailDTO
    {
        public int Orderid { get; set; }

        public int Productid { get; set; }

        public decimal Unitprice { get; set; }

        public short Qty { get; set; }

        public decimal Discount { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual ProductIdDTO Product { get; set; } = null!;
    }
}
