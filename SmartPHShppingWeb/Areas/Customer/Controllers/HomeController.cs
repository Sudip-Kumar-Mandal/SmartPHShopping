using Microsoft.AspNetCore.Mvc;
using SmartPHShoppingWeb.Models;
using SmartPHShoppingWeb.Repository.IRepository;
using System.Diagnostics;

namespace SmartPHShoppingWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "Category");
            return View(product);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Bought");
        }

        public IActionResult Bought()
        {
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
    }
}
