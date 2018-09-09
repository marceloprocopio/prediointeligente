using System;
using System.Collections.Generic;

namespace PredioInteligente.Modelo
{
	public class AmbienteTrabalho
	{
		public AmbienteTrabalho()
		{
			if (Sensores == null)
				Sensores = new List<Sensor>();
			if (Lampadas == null)
				Lampadas = new List<Lampada>();
			if (CondicionadoresAr == null)
				CondicionadoresAr = new List<ArCondicionado>();
			if (Localizacao == null)
				Localizacao = new Localizacao();
		}
		public string Id { get; set; }
		public string IdPredio { get; set; }
		public string Nome { get; set; }
		public List<Sensor> Sensores { get; set; }
		public List<Janela> Janelas { get; set; }
		public List<Lampada> Lampadas { get; set; }
		public List<ArCondicionado> CondicionadoresAr { get; set; }
		public List<UmidificadorAr> UmidificadoresAr { get; set; }
		public Localizacao Localizacao { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
