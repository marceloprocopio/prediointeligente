using System;

namespace PredioInteligente.Modelo
{
	public class Janela
	{
		public string Id { get; set; }
		public string Estado { get; set; }
		public string EspecificacaoTecnica { get; set; }
		public Localizacao Localizacao { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
