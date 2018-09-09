using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepColaborador : IRepColaborador
	{
		private static IMongoCollection<Colaborador> mongoCollection;

		public RepColaborador()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<Colaborador>.GetMongoCollection();
			}
		}

		public async Task Inserir(Colaborador colaborador)
		{
			colaborador.CarimboDataHora = DBConfig<Colaborador>.GetCurrentDateTimeServer();
			await mongoCollection.InsertOneAsync(colaborador);
		}

		public async Task<Colaborador> Encontrar(string cpf)
		{
			FilterDefinition<Colaborador> filter = Builders<Colaborador>.Filter.Eq("CPF", cpf);
			return await mongoCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Colaborador>> ListarTodos()
		{
			try
			{
				return await mongoCollection.Find(x => true).ToListAsync();
			}
			catch(Exception e)
			{
				throw (e);
			}
			
		}

		public async Task Excluir(string cpf)
		{
			FilterDefinition<Colaborador> filter = Builders<Colaborador>.Filter.Eq("CPF", cpf);
			await mongoCollection.DeleteOneAsync(filter);
		}

		public async Task Atualizar(Colaborador colaborador)
		{
			if (colaborador != null)
			{
				FilterDefinition<Colaborador> filter = Builders<Colaborador>.Filter.Eq("CPF", colaborador.CPF);
				Colaborador colaboradorParaAtualizar = await mongoCollection.Find(filter).FirstOrDefaultAsync();
				colaborador.Id = colaboradorParaAtualizar.Id;
				colaborador.CarimboDataHora = DBConfig<Colaborador>.GetCurrentDateTimeServer();
				await mongoCollection.ReplaceOneAsync(filter, colaborador, new UpdateOptions { IsUpsert = true });
			}
		}
	}
}
