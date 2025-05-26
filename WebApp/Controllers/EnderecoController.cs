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

        public IActionResult Index1()
        {
            var listaEnderecoBanco = _dataContext.Enderecos.ToList();
            var listaEnderecoViewModel = new List<EnderecoViewModel>();
            foreach (var item in listaEnderecoBanco)
            {
                listaEnderecoViewModel.Add(new EnderecoViewModel
                {
                    Id = item.Id,
                    Rua = item.Rua,
                    Bairro = item.Bairro,
                    Cep = item.Cep,
                    Numero = item.Numero,
                });

            }
            return View(listaEnderecoViewModel);
        }

        public IActionResult EditarEnd(int id)
        {
            var endereco = _dataContext.Enderecos.FirstOrDefault(c => c.Id == id);
            var enderecoViewModel = new EnderecoViewModel
            {
                Id = endereco.Id,
                Rua = endereco.Rua,
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Numero = endereco.Numero,
            };

            return View(enderecoViewModel);
        }


        [HttpGet]
        public IActionResult CadastroEndereco()
        {
            return View();
        }

        //Recebe Dados
        [HttpPost]
        public IActionResult EditarEnd(EnderecoViewModel enderecoViewModel)
        {

            var enderecoBancoAntigo = _dataContext.Enderecos.FirstOrDefault(c => c.Id == enderecoViewModel.Id);

            enderecoBancoAntigo.Rua = enderecoViewModel.Rua;
            enderecoBancoAntigo.Bairro = enderecoViewModel.Bairro;
            enderecoBancoAntigo.Cep = enderecoViewModel.Cep;
            enderecoBancoAntigo.Numero = enderecoViewModel.Numero;

            _dataContext.Enderecos.Update(enderecoBancoAntigo);

            _dataContext.SaveChanges();

            return RedirectToAction("Index1");

        }

        public IActionResult ExcluirEnd(int id)
        {
            var endereco = _dataContext.Enderecos.FirstOrDefault(x => x.Id == id);
            _dataContext.Enderecos.Remove(endereco);

            _dataContext.SaveChanges();
            return RedirectToAction("Index1");
        }

        public IActionResult DetalheEnd(int id)
        {
            var endereco = _dataContext.Enderecos.FirstOrDefault(x => x.Id == id);
            var enderecoViewModel = new EnderecoViewModel
            {
                Id = endereco.Id,
                Rua = endereco.Rua,
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Numero = endereco.Numero,
            };
            return View(enderecoViewModel);
        }

        [HttpPost]
        public IActionResult CadastroEndereco(EnderecoViewModel model)
        {
            var newendereco = new Endereco();

            newendereco.Rua = model.Rua;
            newendereco.Bairro = model.Bairro;
            newendereco.Cep = model.Cep;
            newendereco.Numero = model.Numero;

            _dataContext.Enderecos.Add(newendereco);
            _dataContext.SaveChanges();

            return RedirectToAction("Index1");
        }
    }

}
