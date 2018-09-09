using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepPortao : IRepPortao
	{
		private static IMongoCollection<Portao> mongoCollection;

		public RepPortao()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Portao>.GetMongoCollection();
			}
		}

		public async Task Atualizar(Portao portao)
		{
			if (portao != null)
			{
				FilterDefinition<Portao> filter = Builders<Portao>.Filter.Eq("Id", portao.Id);
				portao.CarimboDataHora = DBConfig<Portao>.GetCurrentDateTimeServer();
				await mongoCollection.ReplaceOneAsync(filter, portao);
			}
		}

		public async Task<Portao> Encontrar(string objectId)
		{
			FilterDefinition<Portao> filter = Builders<Portao>.Filter.Eq("Id", new ObjectId(objectId));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task Excluir(string objectId)
		{
			FilterDefinition<Portao> filter = Builders<Portao>.Filter.Eq("Id", new ObjectId(objectId));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(Portao portao)
		{
			portao.CarimboDataHora = DBConfig<Portao>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(portao);
		}

		public async Task<IEnumerable<Portao>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}
	}
}
