using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Northwind.Context;

namespace NorthwindMvc.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private NorthwindDbContext dbContext;

    public HomeController(ILogger<HomeController> logger, NorthwindDbContext dbContext)
    {
      _logger = logger;
      this.dbContext = dbContext; ;
    }

    public IActionResult Index()
    {
      var model = new HomeIndexViewModel
      {
        VisitorCount = (new Random()).Next(1, 1001),
        Categories = dbContext.Categories.ToList(),
        Products = dbContext.Products.ToList(),
      };
      return View(model);
    }

    [Route("private")]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
