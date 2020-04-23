using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using NorthwindMvc.Models;
using Northwind.Context;
using Northwind.Model;

namespace NorthwindMvc.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ILogger<CategoryController> logger;
    private readonly NorthwindDbContext dbContext;

    public CategoryController(ILogger<CategoryController> logger, NorthwindDbContext dbContext)
    {
      this.logger = logger;
      this.dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
      var model = new CategoryIndexViewModel
      {
        Categories = await dbContext.Categories.ToListAsync(),
      };
      return View(model);
    }

    public async Task<IActionResult> CategoryDetail(int? id)
    {
      if (!id.HasValue)
      {
        return NotFound("You must pass a category ID in the route.");
      }
      var model = await dbContext.Categories.SingleOrDefaultAsync(c => c.CategoryID == id);
      if (model == null)
      {
        return NotFound($"Category with ID of {id} not found.");
      }

      return View(model);
    }
  }
}