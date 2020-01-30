using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Context;
using Northwind.Model;

namespace NorthwindFeatures.Pages
{
  public class EmployeesPageModel : PageModel
  {
    private NorthwindDbContext dbContext;
    public IEnumerable<Employee> Employees { get; set; }
    public EmployeesPageModel(NorthwindDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void OnGet()
    {
      Employees = dbContext.Employees.ToArray();
    }
  }
}
