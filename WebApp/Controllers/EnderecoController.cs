using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Entities;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly DataContext _dataContext;
        //Construtor
        public EnderecoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CadastroEndereco()
        {
            return View("FormularioEnd");
        }
        //Recebe Dados
        [HttpPost]
        public IActionResult Ficha(EnderecoViewModel model)
        {
            var newend = new Endereco();

            newend.Rua = model.Rua;
            newend.Bairro = model.Bairro;
            newend.Cep = model.Cep;
            newend.Numero = model.Numero;

            _dataContext.Add(newend);
            _dataContext.SaveChanges();

            return View("Privacy");
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
