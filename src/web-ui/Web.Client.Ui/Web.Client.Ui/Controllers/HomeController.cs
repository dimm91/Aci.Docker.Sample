using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Web.Client.Ui.Models;
using Web.Client.Ui.Services;

namespace Web.Client.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        private readonly UserService _userService;

        public HomeController(ProductService productService, UserService userService, IConfiguration config, ILogger<HomeController> logger)
        {
            _logger = logger;
            _productService = productService;
            _userService = userService;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            _logger.LogInformation($"ENV: {env} --- HOST: {_productService.ApiHost}");
            
            var homeViewModel = new HomeViewModel();

            var products = await _productService.GetProducts();

            var users = await _userService.GetUsers();

            var dnsHosName = Dns.GetHostName();
            var environment = _config["Environment"];

            ViewData["Environment"] = $"{environment} - {dnsHosName}";

            homeViewModel.Products = products;
            homeViewModel.Users = users;

            return View(homeViewModel);
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
    }
}