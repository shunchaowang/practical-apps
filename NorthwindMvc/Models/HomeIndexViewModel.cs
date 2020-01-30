using System.Collections.Generic;
using Northwind.Context;
using Northwind.Model;

namespace NorthwindMvc.Models
{
  public class HomeIndexViewModel
  {
    public int VisitorCount;
    public IList<Category> Categories { get; set; }
    public IList<Product> Products { get; set; }
  }
}