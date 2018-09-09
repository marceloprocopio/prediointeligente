using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepArCondicionado : IRepArCondicionado
	{
		private IMongoCollection<ArCondicionado> mongoCollection;

		public RepArCondicionado()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<ArCondicionado>.GetMongoCollection();
			}
		}

		public async Task Atualizar(ArCondicionado arCondicionado)
		{
			FilterDefinition<ArCondicionado> filter = Builders<ArCondicionado>.Filter.Eq("Id", arCondicionado.Id);
			arCondicionado.CarimboDataHora = DBConfig<ArCondicionado>.GetCurrentDateTimeServer();
			await mongoCollection.ReplaceOneAsync(filter, arCondicionado);

		}

		public async Task<ArCondicionado> Encontrar(string id)
		{
			FilterDefinition<ArCondicionado> filter = Builders<ArCondicionado>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task Excluir(string id)
		{
			FilterDefinition<ArCondicionado> filter = Builders<ArCondicionado>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(ArCondicionado arCondicionado)
		{
			arCondicionado.CarimboDataHora = DBConfig<ArCondicionado>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(arCondicionado);
		}

		public async Task<IEnumerable<ArCondicionado>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}
	}
}
