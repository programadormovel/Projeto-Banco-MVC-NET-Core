using Projeto_Banco_MVC_NET_Core.Models;

namespace Projeto_Banco_MVC_NET_Core.Repository
{
    public interface IFuncionarioRepository
    {
        List<FuncionarioModel> BuscarTodos();
        FuncionarioModel Adicionar(FuncionarioModel funcionario);   
    }
}
