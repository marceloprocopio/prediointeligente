using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class Predio
	{
		[BsonElement("Id")]
		public string Id { get; set; }
		[BsonElement("Nome")]
		public string Nome { get; set; }
		[BsonElement("Endereco")]
		public string Endereco { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
    }
}
