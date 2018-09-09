using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepLocalizacao : IRepLocalizacao
	{
		private static IMongoCollection<Localizacao> mongoCollection;

		public RepLocalizacao()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Localizacao>.GetMongoCollection();
			}
		}

		public async Task Atualizar(Localizacao localizacao)
		{
			if (localizacao != null)
			{
				FilterDefinition<Localizacao> filter = Builders<Localizacao>.Filter.Eq("Id", localizacao);
				localizacao.CarimboDataHora = DBConfig<Localizacao>.GetCurrentDateTimeServer();
				await mongoCollection.ReplaceOneAsync(filter, localizacao);
			}
		}

		public async Task<Localizacao> Encontrar(string id)
		{
			FilterDefinition<Localizacao> filter = Builders<Localizacao>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task Excluir(string id)
		{
			FilterDefinition<Localizacao> filter = Builders<Localizacao>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(Localizacao localizacao)
		{
			await mongoCollection.InsertOneAsync(localizacao);
		}

		public async Task<IEnumerable<Localizacao>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}
	}
}
