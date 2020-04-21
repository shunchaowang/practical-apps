using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using Northwind.Context;

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
      return null;
    }

    public async Task<IActionResult> CategoryDetail(int? id)
    {
      return null;
    }
  }
}