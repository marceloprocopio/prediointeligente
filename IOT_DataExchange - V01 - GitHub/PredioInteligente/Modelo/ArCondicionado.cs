/*
 * Fonte:
 *		INSTITUTO NACIONAL DE METROLOGIA, QUALIDADE E TECNOLOGIA
 *		PROGRAMA BRASILEIRO DE ETIQUETAGEM
 *		EFICIÊNCIA ENERGÉTICA - CONDICIONADORES DE AR - CRITÉRIOS 2015
 *		CATEGORIA 4 - CAPACIDADE DE REFRIGERAÇÃO A PARTIR DE 21100 kJ/h
 *		Data atualização: 20/4/2017
 * 
 * */
 
using System;

namespace PredioInteligente.Modelo
{
	public class ArCondicionado
	{
		public string Id { get; set; }
		public string Estado { get; set; }
		public string Fabricante { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string Versao { get; set; }
		public string Modo { get; set; }
		public string EspecificacaoTecnica { get; set; }
		public Localizacao Localizacao { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
