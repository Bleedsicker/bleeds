using System;
using System.Collections.Generic;
using System.Linq;
namespace Domain;

public class OrderProduct
{
    public decimal UnitPrice { get; set; }

    public long ProductId { get; set; }

    public long OrderId { get; set; }

    public long Quantity { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}
