using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
    public class Janela
	{
		[BsonId()]
		public string Id { get; set; }
		[BsonElement("Estado")]
		public string Estado { get; set; }
		[BsonElement("EspecificacaoTecnica")]
		public string EspecificacaoTecnica { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
