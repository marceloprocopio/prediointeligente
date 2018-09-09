namespace PredioInteligente.Modelo
{
	public class Predio
	{
		public Predio()
		{
			this.Localizacao = new Localizacao();
		}
		public string Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public Localizacao Localizacao { get; set; }
		public System.DateTime CarimboDataHora { get; set; }
	}
}
