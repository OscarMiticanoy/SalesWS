namespace SalesWS.DTOs
{
    public class ProductDTO
    {
        public int Productid { get; set; }
        public string Productname { get; set; } = null!;
        public int Supplierid { get; set; }
        public int Categoryid { get; set; }
        public decimal Unitprice { get; set; }
        public bool Discontinued { get; set; }

    }
}
