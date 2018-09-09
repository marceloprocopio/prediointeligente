using System;
using System.Collections.Generic;
using MongoDB.Driver;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
	public class RepAmbienteTrabalho : IRepAmbienteTrabalho
	{
		private IMongoCollection<AmbienteTrabalho> mongoCollection;
		
		public RepAmbienteTrabalho()
		{
			if (mongoCollection == null)
			{
				mongoCollection = DBConfig<AmbienteTrabalho>.GetMongoCollection();
			}
		}

		public void Atualizar(AmbienteTrabalho ambienteTrabalho)
		{
			FilterDefinition<AmbienteTrabalho> filter = Builders<AmbienteTrabalho>.Filter.Eq("Id", ambienteTrabalho.Id);
			ambienteTrabalho.CarimboDataHora = DBConfig<AmbienteTrabalho>.GetCurrentDateTimeServer();
			foreach (Sensor s in ambienteTrabalho.Sensores)
			{
				s.CarimboDataHora = DBConfig<Sensor>.GetCurrentDateTimeServer();
				if (s.Id == null)
					s.Id = DBConfig<Sensor>.GerarIdentificadorUnico(Math.Abs(s.Localizacao.Latitude), Math.Abs(s.Localizacao.Longitude), s.CarimboDataHora);
				s.Localizacao.CarimboDataHora = DBConfig<Sensor>.GetCurrentDateTimeServer();
				if (s.Localizacao.Id == null)
					s.Localizacao.Id = DBConfig<Sensor>.GerarIdentificadorUnico(Math.Abs(s.Localizacao.Latitude), Math.Abs(s.Localizacao.Longitude), s.Localizacao.CarimboDataHora);
			}

			foreach (Janela j in ambienteTrabalho.Janelas)
			{
				j.CarimboDataHora = DBConfig<Janela>.GetCurrentDateTimeServer();
				if (j.Id == null)
					j.Id = DBConfig<Janela>.GerarIdentificadorUnico(Math.Abs(j.Localizacao.Latitude), Math.Abs(j.Localizacao.Longitude), j.CarimboDataHora);
				j.Localizacao.CarimboDataHora = DBConfig<Janela>.GetCurrentDateTimeServer();
				if (j.Localizacao.Id == null)
					j.Localizacao.Id = DBConfig<Janela>.GerarIdentificadorUnico(Math.Abs(j.Localizacao.Latitude), Math.Abs(j.Localizacao.Longitude), j.Localizacao.CarimboDataHora);
			}

			foreach (Lampada l in ambienteTrabalho.Lampadas)
			{
				l.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				if (l.Id == null)
					l.Id = DBConfig<Lampada>.GerarIdentificadorUnico(Math.Abs(l.Localizacao.Latitude), Math.Abs(l.Localizacao.Longitude), l.CarimboDataHora);
				l.Localizacao.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				if (l.Localizacao.Id == null)
					l.Localizacao.Id = DBConfig<Lampada>.GerarIdentificadorUnico(Math.Abs(l.Localizacao.Latitude), Math.Abs(l.Localizacao.Longitude), l.Localizacao.CarimboDataHora);
			}

			foreach (ArCondicionado a in ambienteTrabalho.CondicionadoresAr)
			{
				a.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				if (a.Id == null)
					a.Id = DBConfig<Lampada>.GerarIdentificadorUnico(Math.Abs(a.Localizacao.Latitude), Math.Abs(a.Localizacao.Longitude), a.CarimboDataHora);
				a.Localizacao.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				if (a.Localizacao.Id == null)
					a.Localizacao.Id = DBConfig<Lampada>.GerarIdentificadorUnico(Math.Abs(a.Localizacao.Latitude), Math.Abs(a.Localizacao.Longitude), a.Localizacao.CarimboDataHora);
			}

			foreach (UmidificadorAr u in ambienteTrabalho.UmidificadoresAr)
			{
				u.CarimboDataHora = DBConfig<UmidificadorAr>.GetCurrentDateTimeServer();
				if (u.Id == null)
					u.Id = DBConfig<UmidificadorAr>.GerarIdentificadorUnico(Math.Abs(u.Localizacao.Latitude), Math.Abs(u.Localizacao.Longitude), u.CarimboDataHora);
				u.Localizacao.CarimboDataHora = DBConfig<UmidificadorAr>.GetCurrentDateTimeServer();
				if (u.Localizacao.Id == null)
					u.Localizacao.Id = DBConfig<UmidificadorAr>.GerarIdentificadorUnico(Math.Abs(u.Localizacao.Latitude), Math.Abs(u.Localizacao.Longitude), u.Localizacao.CarimboDataHora);
			}
			mongoCollection.ReplaceOne(filter, ambienteTrabalho);
		}

		public AmbienteTrabalho Encontrar(string id)
		{
			FilterDefinition<AmbienteTrabalho> filter = Builders<AmbienteTrabalho>.Filter.Eq("Id", id);
			return mongoCollection.Find(filter).FirstOrDefault();
		}

		public void Excluir(string id)
		{
			FilterDefinition<AmbienteTrabalho> filter = Builders<AmbienteTrabalho>.Filter.Eq("Id", id);
			mongoCollection.DeleteOne(filter);
		}

		public void Inserir(AmbienteTrabalho ambienteTrabalho)
		{
			ambienteTrabalho.CarimboDataHora = DBConfig<AmbienteTrabalho>.GetCurrentDateTimeServer();
			ambienteTrabalho.Id = DBConfig<AmbienteTrabalho>.GerarIdentificadorUnico(Math.Abs(ambienteTrabalho.Localizacao.Latitude), Math.Abs(ambienteTrabalho.Localizacao.Longitude), ambienteTrabalho.CarimboDataHora);

			ambienteTrabalho.Localizacao.CarimboDataHora = DBConfig<Predio>.GetCurrentDateTimeServer();
			ambienteTrabalho.Localizacao.Id = DBConfig<Predio>.GerarIdentificadorUnico(Math.Abs(ambienteTrabalho.Localizacao.Latitude), Math.Abs(ambienteTrabalho.Localizacao.Longitude), ambienteTrabalho.Localizacao.CarimboDataHora);

			foreach (Sensor s in ambienteTrabalho.Sensores)
			{
				s.CarimboDataHora = DBConfig<Sensor>.GetCurrentDateTimeServer();
				s.Id = DBConfig<Sensor>.GerarIdentificadorUnico(Math.Abs(s.Localizacao.Latitude), Math.Abs(s.Localizacao.Longitude), s.CarimboDataHora);
				s.Localizacao.CarimboDataHora = DBConfig<Sensor>.GetCurrentDateTimeServer();
				s.Localizacao.Id = DBConfig<Sensor>.GerarIdentificadorUnico(Math.Abs(s.Localizacao.Latitude), Math.Abs(s.Localizacao.Longitude), s.Localizacao.CarimboDataHora);
			}

			foreach (Janela j in ambienteTrabalho.Janelas)
			{
				j.CarimboDataHora = DBConfig<Janela>.GetCurrentDateTimeServer();
				j.Id = DBConfig<Janela>.GerarIdentificadorUnico(Math.Abs(j.Localizacao.Latitude), Math.Abs(j.Localizacao.Longitude), j.CarimboDataHora);
				j.Localizacao.CarimboDataHora = DBConfig<Janela>.GetCurrentDateTimeServer();
				j.Localizacao.Id = DBConfig<Janela>.GerarIdentificadorUnico(Math.Abs(j.Localizacao.Latitude), Math.Abs(j.Localizacao.Longitude), j.Localizacao.CarimboDataHora);
			}

			foreach (Lampada l in ambienteTrabalho.Lampadas)
			{
				l.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				l.Id = DBConfig<Lampada>.GerarIdentificadorUnico(Math.Abs(l.Localizacao.Latitude), Math.Abs(l.Localizacao.Longitude), l.CarimboDataHora);
				l.Localizacao.CarimboDataHora = DBConfig<Lampada>.GetCurrentDateTimeServer();
				l.Localizacao.Id = DBConfig<Lampada>.GerarIdentificadorUnico(Math.Abs(l.Localizacao.Latitude), Math.Abs(l.Localizacao.Longitude), l.Localizacao.CarimboDataHora);
			}

			foreach (ArCondicionado a in ambienteTrabalho.CondicionadoresAr)
			{
				a.CarimboDataHora = DBConfig<ArCondicionado>.GetCurrentDateTimeServer();
				a.Id = DBConfig<ArCondicionado>.GerarIdentificadorUnico(Math.Abs(a.Localizacao.Latitude), Math.Abs(a.Localizacao.Longitude), a.CarimboDataHora);
				a.Localizacao.CarimboDataHora = DBConfig<ArCondicionado>.GetCurrentDateTimeServer();
				a.Localizacao.Id = DBConfig<ArCondicionado>.GerarIdentificadorUnico(Math.Abs(a.Localizacao.Latitude), Math.Abs(a.Localizacao.Longitude), a.Localizacao.CarimboDataHora);
			}

			foreach (UmidificadorAr u in ambienteTrabalho.UmidificadoresAr)
			{
				u.CarimboDataHora = DBConfig<UmidificadorAr>.GetCurrentDateTimeServer();
				u.Id = DBConfig<UmidificadorAr>.GerarIdentificadorUnico(Math.Abs(u.Localizacao.Latitude), Math.Abs(u.Localizacao.Longitude), u.CarimboDataHora);
				u.Localizacao.CarimboDataHora = DBConfig<UmidificadorAr>.GetCurrentDateTimeServer();
				u.Localizacao.Id = DBConfig<UmidificadorAr>.GerarIdentificadorUnico(Math.Abs(u.Localizacao.Latitude), Math.Abs(u.Localizacao.Longitude), u.Localizacao.CarimboDataHora);
			}

			mongoCollection.InsertOne(ambienteTrabalho);
		}

		public IEnumerable<AmbienteTrabalho> ListarTodos()
		{
			return mongoCollection.Find(x => true).ToList();
		}

		public IEnumerable<AmbienteTrabalho> ListarTodos(string idPredio)
		{
			FilterDefinition<AmbienteTrabalho> filter = Builders<AmbienteTrabalho>.Filter.Eq("IdPredio", idPredio);
			return mongoCollection.Find(filter).ToList();
		}
	}
}
