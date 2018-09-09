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
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class ArCondicionado
	{
		[BsonId()]
		public string Id { get; set; }
		[BsonElement("Estado")]
		public string Estado { get; set; }
		[BsonElement("Fabricante")]
		public string Fabricante { get; set; }
		[BsonElement("Marca")]
		public string Marca { get; set; }
		[BsonElement("Modelo")]
		public string Modelo { get; set; }
		[BsonElement("Versao")]
		public string Versao { get; set; }
		[BsonElement("Modo")] // Em modo refrigerador de ar ou aquecedor de ar
		public string Modo { get; set; }
		[BsonElement("CapacidadeRefrigeracaoBTUHora")]
		public string CapacidadeRefrigeracaoBTUHora { get; set; }
		[BsonElement("CapacidadeRefrigeracaoKjHora")]
		public string CapacidadeRefrigeracaoKjHora { get; set; }
		[BsonElement("CapacidadeRefrigeracaoWatts")]
		public string CapacidadeRefrigeracaoWatts { get; set; }
		[BsonElement("PotenciaNominalWatts127Volts")]
		public string PotenciaNominalWatts127Volts { get; set; }
		[BsonElement("PotenciaNominalWatts220Volts")]
		public string PotenciaNominalWatts220Volts { get; set; }
		[BsonElement("EficienciaEnergetica127Volts")]
		public string EficienciaEnergetica127Volts { get; set; }
		[BsonElement("EficienciaEnergetica220Volts")]
		public string EficienciaEnergetica220Volts { get; set; }
		[BsonElement("FaixaClassificacao127Volts")]
		public string FaixaClassificacao127Volts { get; set; }
		[BsonElement("FaixaClassificacao220Volts")]
		public string FaixaClassificacao220Volts { get; set; }
		[BsonElement("RegistroInmetro")]
		public string RegistroInmetro { get; set; }
		[BsonElement("DataConcessao")]
		public string DataConcessao { get; set; }
		[BsonElement("DataConcelamento")]
		public string DataConcelamento { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
