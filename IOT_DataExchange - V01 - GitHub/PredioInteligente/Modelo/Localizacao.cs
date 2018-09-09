using System;

namespace PredioInteligente.Modelo
{
	public class Localizacao
	{
		public string Id { get; set; }
		public int Andar { get; set; }
		public int Corredor { get; set; }
		public int Numero { get; set; }
		public Double Longitude { get; set; }
		public Double Latitude { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
