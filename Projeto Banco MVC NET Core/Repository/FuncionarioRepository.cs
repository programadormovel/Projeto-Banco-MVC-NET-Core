using Projeto_Banco_MVC_NET_Core.Data;
using Projeto_Banco_MVC_NET_Core.Models;

namespace Projeto_Banco_MVC_NET_Core.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //Injeção de Dependência
        private readonly BancoContext _bancoContext;

        public FuncionarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public FuncionarioModel Adicionar(FuncionarioModel funcionario)
        {
            _bancoContext.Funcionario.Add(funcionario);
            _bancoContext.SaveChanges();

            return funcionario;
        }

        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionario.ToList();
        }
    }
}
