using System.Collections.Generic;
using Northwind.Model;

namespace NorthwindMvc.Models
{
  public class CategoryIndexViewModel
  {
    public IList<Category> Categories { get; set; }
  }
}