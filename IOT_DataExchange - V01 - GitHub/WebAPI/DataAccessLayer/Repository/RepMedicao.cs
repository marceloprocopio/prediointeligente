using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepMedicao : IRepMedicao
	{
		private IMongoCollection<Medicao> mongoCollection;

		public RepMedicao()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Medicao>.GetMongoCollection();
			}
		}

		public void Atualizar(Medicao medicao)
		{
			FilterDefinition<Medicao> filter = Builders<Medicao>.Filter.Eq("Id", medicao.Id);
			medicao.CarimboDataHora = DBConfig<Medicao>.GetCurrentDateTimeServer();
			mongoCollection.ReplaceOne(filter, medicao);
		}

		public Medicao Encontrar(string id)
		{
			FilterDefinition<Medicao> filter = Builders<Medicao>.Filter.Eq("Id", new ObjectId(id));
			return mongoCollection.Find(filter).FirstOrDefault();
		}

		public void Excluir(string id)
		{
			FilterDefinition<Medicao> filter = Builders<Medicao>.Filter.Eq("Id", new ObjectId(id));
			mongoCollection.DeleteOne(filter);
		}

		public void Inserir(Medicao medicao)
		{
			medicao.CarimboDataHora = DBConfig<Medicao>.GetCurrentDateTimeServer();
			medicao.Id = DBConfig<Medicao>.GerarIdentificadorUnico(medicao.Sensor.Localizacao.Latitude, medicao.Sensor.Localizacao.Longitude, medicao.CarimboDataHora);
			mongoCollection.InsertOne(medicao);
		}

		public IEnumerable<Medicao> ListarTodos()
		{
			return mongoCollection.Find(x => true).ToList();
		}
	}
}
