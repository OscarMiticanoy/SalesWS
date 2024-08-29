using System;
using System.Collections.Generic;

namespace SalesWS.Contexts;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public int Supplierid { get; set; }

    public int Categoryid { get; set; }

    public decimal Unitprice { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
