using Cody_v2.Repositories.Entities;
using Cody_v2.Services.Helpers;
using Cody_v2.Services.Interfaces;
using Cody_v2.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cody_v2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager= userManager;
        }

        public async Task<IActionResult> Index()
        {
            //var isAdmin=User.IsInRole(RoleName.Administrator);
            //var user =await _userManager.FindByNameAsync(this.User?.Identity?.Name);
            //var roles = await _userManager.GetRolesAsync(user);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        ////[HttpPost]
        //public async Task<IActionResult> Create(Product product )
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //try
        //    //{
        //        product = new Product();    
        //        product.Id = Guid.NewGuid();
        //        product.Name = null;
        //        product.Description = "Điện thoại Mô tô rô la";
        //        product.Price = 1000000;
        //        var rowE =await _productService.Insert(product);
        //        _logger.LogInformation("insert OK");
        //        return Ok("insert OK");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    _logger.LogInformation("Đây là error: \n"+ ex.Message);
        //    //    return Ok("Insert false");
        //    //}
            
            
        //    //}
        //    //return BadRequest("Can not insert");
        //}

        public async Task<IActionResult> ShowTables()
        {
            return View();
        }
    }
}