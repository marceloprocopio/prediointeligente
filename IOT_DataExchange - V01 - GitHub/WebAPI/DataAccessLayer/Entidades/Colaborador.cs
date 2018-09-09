using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class Colaborador 
    {
		[BsonId()]
		public ObjectId Id { get; set; }
		[BsonElement("CPF")]
		[BsonRequired()]
		public string CPF { get; set; }
		[BsonElement("Nome")]
		[BsonRequired()]
		public string Nome { get; set; }
		[BsonElement("Apelido")]
		public string Apelido { get; set; }
		[BsonElement("Sexo")]
		public string Sexo { get; set; }
		[BsonElement("CarimboDataHora")]
		public BsonDateTime CarimboDataHora { get; set; }
    }
}
