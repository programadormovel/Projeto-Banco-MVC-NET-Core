using Microsoft.EntityFrameworkCore;
using Projeto_Banco_MVC_NET_Core.Models;

namespace Projeto_Banco_MVC_NET_Core.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext(DbContextOptions<BancoContext> options) : base(options) {
		}

		public DbSet<FuncionarioModel> Funcionario { get; set; }
	}
}
