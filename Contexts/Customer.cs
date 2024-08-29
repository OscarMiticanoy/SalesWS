using System;
using System.Collections.Generic;

namespace SalesWS.Contexts;

public partial class Customer
{
    public int Custid { get; set; }

    public string Companyname { get; set; } = null!;

    public string Contactname { get; set; } = null!;

    public string Contacttitle { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Fax { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
