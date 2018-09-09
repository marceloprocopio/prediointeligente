using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepJanela : IRepJanela
	{
		private static IMongoCollection<Janela> mongoCollection;

		public RepJanela()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Janela>.GetMongoCollection();
			}
		}

		public async Task Atualizar(Janela janela)
		{
			if (janela != null)
			{
				FilterDefinition<Janela> filter = Builders<Janela>.Filter.Eq("Id", janela.Id);
				janela.CarimboDataHora = DBConfig<Janela>.GetCurrentDateTimeServer();
				await mongoCollection.ReplaceOneAsync(filter, janela);
			}
		}

		public async Task<Janela> Encontrar(string id)
		{
			FilterDefinition<Janela> filter = Builders<Janela>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task Excluir(string id)
		{
			FilterDefinition<Janela> filter = Builders<Janela>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(Janela janela)
		{
			janela.CarimboDataHora = DBConfig<Janela>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(janela);
		}

		public async Task<IEnumerable<Janela>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}
	}
}
