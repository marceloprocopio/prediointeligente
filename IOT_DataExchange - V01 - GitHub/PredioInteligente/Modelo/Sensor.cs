using System;
using System.Collections.Generic;

namespace PredioInteligente.Modelo
{
	public class Sensor
	{
		public string Id { get; set; }
		public string Estado { get; set; }
		public String EspecificacaoTecnica { get; set; }
		public Localizacao Localizacao { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
