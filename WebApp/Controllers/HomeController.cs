using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApp.Context;
using WebApp.Entities;
using WebApp.Models;
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
        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View("Formulario");
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
        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel viewModel) 
        {
            //Transferiu Dados da ViewModel para a entidade CLiente
            var newcliente = new Cliente();
           
            newcliente.Nome = viewModel.Nome;
            newcliente.Sobrenome = viewModel.Sobrenome;
            newcliente.Email = viewModel.Email;
            newcliente.Cpf = viewModel.Cpf;
            newcliente.DataNascimento = viewModel.DataNascimento;

            //Adiciona
            _dataContext.Clientes.Add(newcliente);
            //Salvar Alteração
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
