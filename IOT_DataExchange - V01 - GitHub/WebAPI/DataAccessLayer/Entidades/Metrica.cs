using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
    public class Metrica
    {
		[BsonElement("Id")]
		public string Id { get; set; }
		[BsonElement("Descricao")]
		public string Descricao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
