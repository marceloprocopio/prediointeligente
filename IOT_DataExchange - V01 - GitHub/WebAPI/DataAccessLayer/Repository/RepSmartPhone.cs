using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepSmartPhone : IRepSmartPhone
	{
		private static IMongoCollection<SmartPhone> mongoCollection;

		public RepSmartPhone()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<SmartPhone>.GetMongoCollection();
			}
		}
		public async Task Atualizar(SmartPhone smartPhone)
		{
			FilterDefinition<SmartPhone> filter = Builders<SmartPhone>.Filter.Eq("Id", smartPhone.Id);
			smartPhone.CarimboDataHora = DBConfig<SmartPhone>.GetCurrentDateTimeServer();
			await mongoCollection.ReplaceOneAsync(filter, smartPhone);
		}

		public async Task<SmartPhone> Encontrar(string id)
		{
			FilterDefinition<SmartPhone> filter = Builders<SmartPhone>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<SmartPhone>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}

		public async Task Excluir(string id)
		{
			FilterDefinition<SmartPhone> filter = Builders<SmartPhone>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(SmartPhone smartPhone)
		{
			smartPhone.CarimboDataHora = DBConfig<SmartPhone>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(smartPhone);
		}
	}
}
