using System;
using System.Collections.Generic;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepPredio : IRepPredio
	{
		private static IMongoCollection<Predio> mongoCollection;

		public RepPredio()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Predio>.GetMongoCollection();
			}
		}

		public void Atualizar(Predio predio)
		{
			if (predio != null)
			{
				FilterDefinition<Predio> filter = Builders<Predio>.Filter.Eq("Id", predio.Id);
				predio.CarimboDataHora = DBConfig<Predio>.GetCurrentDateTimeServer();
				mongoCollection.ReplaceOne(filter, predio);
			}
		}

		public Predio Encontrar(string id)
		{
			FilterDefinition<Predio> filter = Builders<Predio>.Filter.Eq("Id", id);
			return mongoCollection.Find(filter).FirstOrDefault();
		}

		public void Excluir(string id)
		{
			FilterDefinition<Predio> filter = Builders<Predio>.Filter.Eq("Id", id);
			mongoCollection.DeleteOne(filter);
		}

		public void Inserir(Predio predio)
		{
			predio.CarimboDataHora = DBConfig<Predio>.GetCurrentDateTimeServer();
			predio.Id = DBConfig<Predio>.GerarIdentificadorUnico(Math.Abs(predio.Localizacao.Latitude), Math.Abs(predio.Localizacao.Longitude), predio.CarimboDataHora);
			predio.Localizacao.CarimboDataHora = DBConfig<Predio>.GetCurrentDateTimeServer();
			predio.Localizacao.Id = DBConfig<Predio>.GerarIdentificadorUnico(Math.Abs(predio.Localizacao.Latitude), Math.Abs(predio.Localizacao.Longitude), predio.Localizacao.CarimboDataHora);
			mongoCollection.InsertOne(predio);
		}

		public IEnumerable<Predio> ListarTodos()
		{
			return mongoCollection.Find(x => true).ToList();
		}
	}
}
