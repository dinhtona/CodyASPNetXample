using Cody_v2.Repositories.Entities;
using Cody_v2.Services.Interfaces;
using Cody_v2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cody_v2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService= productService;
        }

        public async Task<IActionResult> Index()
        {
            var ls = await _productService.GetAllCurrent();
            return View(ls);
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

        //[HttpPost]
        public async Task<IActionResult> Create(Product product )
        {
            //if (ModelState.IsValid)
            //{
            //try
            //{
                product = new Product();    
                product.Id = Guid.NewGuid();
                product.Name = null;
                product.Description = "Điện thoại Mô tô rô la";
                product.Price = 1000000;
                var rowE =await _productService.Insert(product);
                _logger.LogInformation("insert OK");
                return Ok("insert OK");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogInformation("Đây là error: \n"+ ex.Message);
            //    return Ok("Insert false");
            //}
            
            
            //}
            //return BadRequest("Can not insert");
        }
    }
}