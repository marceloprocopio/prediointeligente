using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
    public class RepLampada : IRepLampada 
    {
		private static IMongoCollection<Lampada> mongoCollection;

		public RepLampada()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Lampada>.GetMongoCollection(); 
			}
		}

		public async Task Inserir(Lampada lampada)
		{
			lampada.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(lampada);
		}

		public async Task<Lampada> Encontrar(string id)
		{
			FilterDefinition<Lampada> filter = Builders<Lampada>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Lampada>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}

		public async Task Excluir(string id)
		{
			FilterDefinition<Lampada> filter = Builders<Lampada>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Atualizar(Lampada lampada)
		{
			if (lampada != null)
			{
				FilterDefinition<Lampada> filter = Builders<Lampada>.Filter.Eq("Id", lampada.Id);
				lampada.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				await mongoCollection.ReplaceOneAsync(filter, lampada);
			}
		}

    }
}
