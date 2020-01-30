using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Northwind.Context;

namespace NorthwindWeb
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      string databasePath = Path.Combine("..", "Northwind.db");
      services.AddDbContext<NorthwindDbContext>(options =>
        options.UseSqlite($"DataSource={databasePath}")
      );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseRouting();
      app.UseHttpsRedirection();
      app.UseDefaultFiles(); //index.html, default.html, etc
      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        // endpoints.MapGet("/", async context =>
        //       {
        //         await context.Response.WriteAsync("Hello World!");
        //       });

        endpoints.MapRazorPages();
      });
    }
  }
}
