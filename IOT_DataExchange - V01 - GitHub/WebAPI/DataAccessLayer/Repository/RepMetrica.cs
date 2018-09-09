using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepMetrica : IRepMetrica
	{
		private static IMongoCollection<Metrica> mongoCollection;

		public RepMetrica()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Metrica>.GetMongoCollection();
			}
		}

		public void Atualizar(Metrica metrica)
		{
			FilterDefinition<Metrica> filter = Builders<Metrica>.Filter.Eq("Id", metrica.Id);
			metrica.CarimboDataHora = DBConfig<Metrica>.GetCurrentDateTimeServer();
			mongoCollection.ReplaceOne(filter, metrica);
		}

		public Metrica Encontrar(string id)
		{
			FilterDefinition<Metrica> filter = Builders<Metrica>.Filter.Eq("Id", id);
			return mongoCollection.Find(filter).FirstOrDefault();
		}

		public void Excluir(string id)
		{
			FilterDefinition<Metrica> filter = Builders<Metrica>.Filter.Eq("Id", id);
			mongoCollection.FindOneAndDelete(filter);
		}

		public void Inserir(Metrica metrica)
		{
			metrica.CarimboDataHora = DBConfig<Metrica>.GetCurrentDateTimeServer();
			metrica.Id = DBConfig<Metrica>.GerarIdentificadorUnico(0, 0, metrica.CarimboDataHora);
			mongoCollection.InsertOne(metrica);
		}

		public IEnumerable<Metrica> ListarTodos()
		{
			return mongoCollection.Find(x => true).ToList();
		}
	}
}
