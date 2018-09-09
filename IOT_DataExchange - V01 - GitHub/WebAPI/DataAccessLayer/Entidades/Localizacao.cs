using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class Localizacao
	{
		[BsonElement("Id")]
		public string Id { get; set; }
		[BsonElement("Andar")]
		public int Andar { get; set; }
		[BsonElement("Corredor")]
		public int Corredor { get; set; }
		[BsonElement("Numero")]
		public int Numero { get; set; }
		[BsonElement("Longitude")]
		public float Longitude { get; set; }
		[BsonElement("Latitude")]
		public float Latitude { get; set; }
		[BsonElement("X")]
		public int X { get; set; }
		[BsonElement("Y")]
		public int Y { get; set; }
		[BsonElement("Z")]
		public int Z { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
