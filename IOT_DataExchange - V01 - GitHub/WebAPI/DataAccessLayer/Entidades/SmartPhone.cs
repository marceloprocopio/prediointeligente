using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
    public class SmartPhone
    {
		[BsonId()]
		public String Id { get; set; }
		[BsonElement("Numero")]
		public string Numero { get; set; }
		[BsonElement("Proprietario")]
		public Colaborador Proprietario { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
