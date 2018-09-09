using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepSensor : IRepSensor
	{
		private static IMongoCollection<Sensor> mongoCollection;

		public RepSensor()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Sensor>.GetMongoCollection() ;
			}
		}

		public async Task Atualizar(Sensor sensor)
		{
			FilterDefinition<Sensor> filter = Builders<Sensor>.Filter.Eq("Id", sensor.Id);
			sensor.CarimboDataHora = DBConfig<Sensor>.GetCurrentDateTimeServer();
			await mongoCollection.ReplaceOneAsync(filter, sensor);
		}

		public async Task<Sensor> Encontrar(string id)
		{
			FilterDefinition<Sensor> filter = Builders<Sensor>.Filter.Eq("Id", id);
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();

		}

		public async Task Excluir(string id)
		{
			FilterDefinition<Sensor> filter = Builders<Sensor>.Filter.Eq("Id", id);
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Inserir(Sensor sensor)
		{
			sensor.CarimboDataHora = DBConfig<Sensor>.GetCurrentDateTimeServer();
			sensor.Id = DBConfig<Sensor>.GerarIdentificadorUnico(sensor.Localizacao.Latitude, sensor.Localizacao.Longitude, sensor.Localizacao.CarimboDataHora);
			await mongoCollection.InsertOneAsync(sensor);
		}

		public async Task<IEnumerable<Sensor>> ListarTodos()
		{
			return await mongoCollection.Find(x => true).ToListAsync();
		}
	}
}
