using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.DataAccessLayer.Entidades
{
    public class Lampada
    {
		[BsonId]
		public string Id { get; set; }
		[BsonElement("Estado")]
		public string Estado { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("Ligada")]
		public bool Ligada { get; set; }
		[BsonElement("Temperatura")]
		public float Temperatura { get; set; }
		[BsonElement("HoraDeUso")]
		public int HorasDeUso { get; set; }
		[BsonElement("Potencia")]
		public float Potencia { get; set; }
		[BsonElement("Luminosidade")]
		public float Luminosidade { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
	}
}
