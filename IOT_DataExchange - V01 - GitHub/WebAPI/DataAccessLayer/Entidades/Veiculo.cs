using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class Veiculo
	{
		[BsonId()]
		public string Id { get; set; }
		[BsonElement("Marca")]
		public string Marca { get; set; }
		[BsonElement("Modelo")]
		public string Modelo { get; set; }
		[BsonElement("Versao")]
		public string Versao { get; set; }
		[BsonElement("Renavam")]
		public string Renavam { get; set; }
		[BsonElement("")]
		public string NumeroChassi { get; set; }
		[BsonElement("DataFabricacao")]
		public DateTime DataFabricacao { get; set; }
		[BsonElement("DataModelo")]
		public DateTime DataModelo { get; set; }
		[BsonElement("Kilometragem")]
		public float Kilometragem { get; set; }
		[BsonElement("Proprietario")]
		public Colaborador Proprietario { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
