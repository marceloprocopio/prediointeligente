using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace WebAPI.DataAccessLayer.Entidades
{
	public class AmbienteTrabalho
	{
		[BsonElement("Id")]
		public string Id { get; set; }
		[BsonElement("IdPredio")]
		public string IdPredio { get; set; }
		[BsonElement("Nome")]
		public string Nome { get; set; }
		[BsonElement("Sensores")]
		public List<Sensor> Sensores { get; set; }
		[BsonElement("Janelas")]
		public List<Janela> Janelas { get; set; }
		[BsonElement("Lampadas")]
		public List<Lampada> Lampadas { get; set; }
		[BsonElement("CondicionadoresAr")]
		public List<ArCondicionado> CondicionadoresAr { get; set; }
		[BsonElement("UmidificadoresAr")]
		public List<UmidificadorAr> UmidificadoresAr { get; set; }
		[BsonElement("Localizacao")]
		public Localizacao Localizacao { get; set; }
		[BsonElement("CarimboDataHora")]
		public DateTime CarimboDataHora { get; set; }
    }
}
