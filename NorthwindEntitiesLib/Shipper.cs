using System.Collections.Generic;

namespace Northwind.Model
{
  public class Shipper
  {
    public int ShipperID { get; set; }
    public string ShipperName { get; set; }
    public string Phone { get; set; }

    // related entities
    public ICollection<Order> Orders { get; set; }
  }
}
