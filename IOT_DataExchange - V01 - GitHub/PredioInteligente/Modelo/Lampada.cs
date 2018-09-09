using System;

namespace PredioInteligente.Modelo
{
	public class Lampada
	{
		public string Id { get; set; }
		public string Estado { get; set; }
		public Localizacao Localizacao { get; set; }
		public float Temperatura { get; set; }
		public int HorasDeUso { get; set; }
		public float Potencia { get; set; }
		public float Luminosidade { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
