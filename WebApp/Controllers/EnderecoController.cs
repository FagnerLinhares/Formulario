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

        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            var endereco = _dataContext.Enderecos.FirstOrDefault(c => c.Id == id);
            if (endereco == null)
            {
                return RedirectToAction("Index");
            }

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
        public IActionResult Cadastro()
        {
            return View();
        }

        /*
        [HttpPost]
public IActionResult Editar(EnderecoViewModel enderecoViewModel)
{
    if (!ModelState.IsValid)
        return View(enderecoViewModel);

    if (enderecoViewModel.Id <= 0)
        return BadRequest("ID inválido.");

    var enderecoBancoAntigo = _dataContext.Enderecos.FirstOrDefault(c => c.Id == enderecoViewModel.Id);
    if (enderecoBancoAntigo == null)
        return NotFound();

    enderecoBancoAntigo.Rua = enderecoViewModel.Rua;
    enderecoBancoAntigo.Bairro = enderecoViewModel.Bairro;
    enderecoBancoAntigo.Cep = enderecoViewModel.Cep;
    enderecoBancoAntigo.Numero = enderecoViewModel.Numero;

    try
    {
        _dataContext.Enderecos.Update(enderecoBancoAntigo);
        _dataContext.SaveChanges();
        return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        ModelState.AddModelError("", "Erro ao atualizar o endereço.");
        return View(enderecoViewModel);
    }
}
        */


        //Recebe Dados
        [HttpPost]
        public IActionResult Editar(EnderecoViewModel enderecoViewModel)
        {       
            if (!ModelState.IsValid)
            {
                return View(enderecoViewModel);
            }

            if (enderecoViewModel.Id <= 0)
            {
                return BadRequest("ID ou Cadastro não encontrado.");
            }

            var enderecoBancoAntigo = _dataContext.Enderecos.FirstOrDefault(c => c.Id == enderecoViewModel.Id);
            if (enderecoBancoAntigo == null)
            { 
                return BadRequest("O ID passado é Inválido.");
            }

            enderecoBancoAntigo.Rua = enderecoViewModel.Rua;
            enderecoBancoAntigo.Bairro = enderecoViewModel.Bairro;
            enderecoBancoAntigo.Cep = enderecoViewModel.Cep;
            enderecoBancoAntigo.Numero = enderecoViewModel.Numero;

            _dataContext.Enderecos.Update(enderecoBancoAntigo);

            _dataContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Excluir(int id)
        {
            
            var endereco = _dataContext.Enderecos.FirstOrDefault(x => x.Id == id);
            
            _dataContext.Enderecos.Remove(endereco);

            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detalhe(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            var endereco = _dataContext.Enderecos.FirstOrDefault(x => x.Id == id);
            if (endereco == null)
            {
                return RedirectToAction("Index");
            }
                

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
        public IActionResult Cadastro(EnderecoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model == null)
            {
                return RedirectToAction("Cadastro");
            }

            var newendereco = new Endereco();

            if (newendereco == null)
            {
                return RedirectToAction("Cadastro");
            }

            newendereco.Rua = model.Rua;
            newendereco.Bairro = model.Bairro;
            newendereco.Cep = model.Cep;
            newendereco.Numero = model.Numero;

            _dataContext.Enderecos.Add(newendereco);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
