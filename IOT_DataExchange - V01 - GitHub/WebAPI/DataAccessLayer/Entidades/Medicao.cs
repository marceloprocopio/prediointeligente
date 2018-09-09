using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
    public class Medicao
    {
		[BsonElement("Id")]
		public string Id { get; set; }
		[BsonElement("DataHora")]
		public string DataHora { get; set; }
		[BsonElement("Valor")]
		public string Valor { get; set; }
		[BsonElement("Metrica")]
		public Metrica Metrica { get; set; }
		[BsonElement("Sensor")]
		public Sensor Sensor { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
