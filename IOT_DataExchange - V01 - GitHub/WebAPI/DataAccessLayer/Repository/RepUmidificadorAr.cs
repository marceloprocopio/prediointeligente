using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepUmidificadorAr : IRepUmidificadorAr
	{
		IMongoCollection<UmidificadorAr> mongoCollection;

		public RepUmidificadorAr()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<UmidificadorAr>.GetMongoCollection();
			}
		}
		public async Task Atualizar(UmidificadorAr umidificadorAr)
		{
			FilterDefinition<UmidificadorAr> filter = Builders<UmidificadorAr>.Filter.Eq("Id", umidificadorAr.Id);
			umidificadorAr.CarimboDataHora = DBConfig<UmidificadorAr>.GetCurrentDateTimeServer();
			await mongoCollection.ReplaceOneAsync(filter, umidificadorAr);
		}

		public async Task<UmidificadorAr> Encontrar(string id)
		{
			FilterDefinition<UmidificadorAr> filter = Builders<UmidificadorAr>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task Exluir(string id)
		{
			FilterDefinition<UmidificadorAr> filter = Builders<UmidificadorAr>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(UmidificadorAr umidificadorAr)
		{
			umidificadorAr.CarimboDataHora = DBConfig<UmidificadorAr>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(umidificadorAr);
		}

		public async Task<IEnumerable<UmidificadorAr>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}
	}
}
