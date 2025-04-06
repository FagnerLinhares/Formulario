using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Entities;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DataContext _dataContext;

        public ClienteController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Lista
        public IActionResult Index()
        {
            var listaClienteBanco = _dataContext.Clientes.ToList();
            var listaClienteViewModel = new List<ClienteViewModel>();
            foreach (var item in listaClienteBanco) 
            {
                listaClienteViewModel.Add(new ClienteViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Sobrenome = item.Sobrenome,
                    DataNascimento = item.DataNascimento,
                    Cpf = item.Cpf,
                    Email = item.Email
                });
            
            }
            return View(listaClienteViewModel);
        }

        public IActionResult Editar(int id)
        {
            var cliente = _dataContext.Clientes.FirstOrDefault(c => c.Id == id);
            var clienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Sobrenome= cliente.Sobrenome,
                DataNascimento= cliente.DataNascimento,
                Cpf = cliente.Cpf,
                Email = cliente.Email
            };

            return View(clienteViewModel);
        }

        //Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(ClienteViewModel clienteViewModel) {
            
            var clienteBancoAntigo = _dataContext.Clientes.FirstOrDefault(c => c.Id == clienteViewModel.Id);

            clienteBancoAntigo.Nome = clienteViewModel.Nome;
            clienteBancoAntigo.Sobrenome = clienteViewModel.Sobrenome;
            clienteBancoAntigo.DataNascimento = clienteViewModel.DataNascimento;
            clienteBancoAntigo.Cpf = clienteViewModel.Cpf;
            clienteBancoAntigo.Email = clienteViewModel.Email;

            _dataContext.Clientes.Update(clienteBancoAntigo);

            _dataContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Excluir(int id)
        {
            var cliente = _dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            _dataContext.Clientes.Remove(cliente);

            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detalhe(int id) 
        {
            var cliente = _dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            var clienteViewModel = new ClienteViewModel {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                DataNascimento = cliente.DataNascimento,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
            };
            return View(clienteViewModel);
        }

        //Recebe dados
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


            return RedirectToAction("Index");
        }

    }
}
