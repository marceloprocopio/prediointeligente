using System;
namespace PredioInteligente.Modelo
{
	public class Medicao
	{
		public string Id { get; set; }
		public string Valor { get; set; }
		public Metrica Metrica { get; set; }
		public Sensor Sensor { get; set; }
		public DateTime DataHora { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
