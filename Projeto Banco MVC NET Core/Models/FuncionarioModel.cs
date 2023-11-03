using System.ComponentModel.DataAnnotations;

namespace Projeto_Banco_MVC_NET_Core.Models
{

	public class FuncionarioModel
	{
		[Display(Name = "Id do Funcionário")]
		[Key]
		public Int32 IdFuncionario { get; set; }
		[Required(ErrorMessage = "Campo nome é obrigatório")]
		public string Nome { get; set; }
		[Required(ErrorMessage = "Campo sobrenome é obrigatório")]
		public string Sobrenome { get; set; }
		[Required(ErrorMessage = "Campo cidade é obrigatório")]
		public string Cidade { get; set; }
		[Required(ErrorMessage = "Campo endereço é obrigatório")]
		[Display(Name = "Endereço")]
		public string Endereco { get; set; }
		[Required(ErrorMessage = "Campo e-mail é obrigatório")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }
		[Display(Name = "Nome da Imagem")]
		public string? NomeImagem { get; set; }
		[Display(Name = "Imagem")]
		public byte[]? Imagem { get; set; }
	}
}
