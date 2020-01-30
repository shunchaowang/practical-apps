using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Northwind.Context;
using Northwind.Model;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
  public class SuppliersModel : PageModel
  {
    private NorthwindDbContext dbContext;
    [BindProperty]
    public Supplier Supplier { get; set; }
    public IEnumerable<string> Suppliers { get; set; }
    public SuppliersModel(NorthwindDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void OnGet()
    {
      ViewData["Title"] = "Northwind Web Site - Suppliers";
      Suppliers = dbContext.Suppliers.Select(s => s.CompanyName);
    }
    public IActionResult OnPost()
    {
      if (ModelState.IsValid)
      {
        dbContext.Suppliers.Add(Supplier);
        dbContext.SaveChanges();
        return RedirectToPage("/suppliers");
      }
      return Page();
    }
  }
}