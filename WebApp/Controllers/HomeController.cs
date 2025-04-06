using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.ViewModels;


namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        //Construtor
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        //Action
        [HttpGet]
        public IActionResult Index()
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
