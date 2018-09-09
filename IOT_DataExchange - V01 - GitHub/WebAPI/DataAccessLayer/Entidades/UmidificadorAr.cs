/*
 * Fonte:
 * https://www.americanas.com.br/produto/124008864/umidificador-de-ar-digital-elgin-2-litros-bivolt?pfm_carac=umidificador%20de%20ar&pfm_index=0&pfm_page=search&pfm_pos=grid&pfm_type=search_page%20
 * e
 * https://produto.mercadolivre.com.br/MLB-1032079478-umidificador-de-ar-e-ionizador-ultrasonico-2l-bivolt-g-lif-_JM
 * 
 * */
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class UmidificadorAr
	{
		[BsonId()]
		public string Id { get; set; }
		[BsonElement("Estado")]
		public string Estado { get; set; }
		[BsonElement("Codigo")]
		public string Codigo { get; set; }
		[BsonElement("Fabricante")]
		public string Fabricante { get; set; }
		[BsonElement("Marca")]
		public string Marca { get; set; }
		[BsonElement("Modelo")]
		public string Modelo { get; set; }
		[BsonElement("Autonomia")]
		public string Autonomia { get; set; }
		[BsonElement("CapacidadeAguaReservatorio")]
		public string CapacidadeAguaReservatorio { get; set; }
		[BsonElement("Motor")]
		public string Motor { get; set; }
		[BsonElement("Portatil")]
		public bool Portatil { get; set; }
		[BsonElement("Silecioso")]
		public bool Silecioso { get; set; }
		[BsonElement("PossuiLubrificacao")]
		public bool PossuiLubrificacao { get; set; }
		[BsonElement("DesligamentoAutomatico")]
		public bool DesligamentoAutomatico { get; set; }
		[BsonElement("Vaporizador")]
		public bool Vaporizador { get; set; }
		[BsonElement("Voltagem")]
		public string Voltagem { get; set; }
		[BsonElement("Potencia")]
		public string Potencia { get; set; }
		[BsonElement("Cor")]
		public string Cor { get; set; }
		[BsonElement("Acessorios")]
		public string Acessorios { get; set; }
		[BsonElement("DimensoesComprimento")]
		public string DimensoesComprimento { get; set; }
		[BsonElement("DimensoesLargura")]
		public string DimensoesLargura { get;  set; }
		[BsonElement("DimensoesAltura")]
		public string DimensoesAltura { get; set; }
		[BsonElement("PesoLiquido")]
		public string PesoLiquido { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
