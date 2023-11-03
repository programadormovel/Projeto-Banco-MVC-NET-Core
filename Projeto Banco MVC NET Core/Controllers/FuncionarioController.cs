using Microsoft.AspNetCore.Mvc;
using Projeto_Banco_MVC_NET_Core.Models;
using Projeto_Banco_MVC_NET_Core.Repository;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Projeto_Banco_MVC_NET_Core.Controllers
{
	public class FuncionarioController : Controller
	{
        // Injeção de Dependência
        private readonly IFuncionarioRepository _funcionarioRepository;
        private IHostingEnvironment _environment;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IHostingEnvironment environment)
        {
            _funcionarioRepository = funcionarioRepository;
            _environment = environment;
        }

		public IActionResult SelecionarFuncionarios()
		{
			List<FuncionarioModel> lista = new List<FuncionarioModel>();	

            lista = _funcionarioRepository.BuscarTodos();

			return View(lista);
		}

        // GET: Funcionario/AdicionarFuncionario
        public IActionResult AdicionarFuncionario()
        {
            var model = new FuncionarioModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarFuncionario(FuncionarioModel funcionario, IFormFile? imagemCarregada)
        {
            
            var imageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/png"
            };

            if (ModelState.IsValid)
            {
                var func = new FuncionarioModel();
                func.Nome = funcionario.Nome;
                func.Sobrenome = funcionario.Sobrenome;
                func.Cidade = funcionario.Cidade;
                func.Endereco = funcionario.Endereco;
                func.Email = funcionario.Email;

                // Carregamento de imagem
                string wwwPath = this._environment.WebRootPath;
                string path = Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = Path.GetFileName(imagemCarregada!.FileName);

                var caminhoCompleto = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    imagemCarregada.CopyTo(stream);
                    func.NomeImagem = caminhoCompleto;
                }

                func.Imagem = Util.ReadFully2(caminhoCompleto);

                _funcionarioRepository.Adicionar(func);
                return RedirectToAction("SelecionarFuncionarios");
            }
            return View(funcionario);
        }

    }
}
