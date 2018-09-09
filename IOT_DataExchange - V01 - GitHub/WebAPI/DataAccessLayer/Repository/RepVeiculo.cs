using System.Collections.Generic;
using WebAPI.DataAccessLayer.Entidades;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepVeiculo : IRepVeiculo
	{
		private static IMongoCollection<Veiculo> mongoCollection;

		public RepVeiculo()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Veiculo>.GetMongoCollection();
			}
		}
		public async Task Atualizar(Veiculo veiculo)
		{
			FilterDefinition<Veiculo> filter = Builders<Veiculo>.Filter.Eq("Id", veiculo.Id);
			veiculo.CarimboDataHora = DBConfig<Veiculo>.GetCurrentDateTimeServer();
			await mongoCollection.ReplaceOneAsync(filter, veiculo);
		}

		public async Task<Veiculo> Encontrar(string id)
		{
			FilterDefinition<Veiculo> filter = Builders<Veiculo>.Filter.Eq("Id", new ObjectId(id));
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Veiculo>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}

		public async Task Excluir(string id)
		{
			FilterDefinition<Veiculo> filter = Builders<Veiculo>.Filter.Eq("Id", new ObjectId(id));
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(Veiculo veiculo)
		{
			veiculo.CarimboDataHora = DBConfig<Veiculo>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(veiculo);
		}
	}
}
