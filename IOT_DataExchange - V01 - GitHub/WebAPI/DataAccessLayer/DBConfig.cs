using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace WebAPI.DataAccessLayer
{
    public class DBConfig<T>
    {
		private static string ConnectionString = "mongodb://localhost:27017";
		private static string Database = "PredioInteligente_V5";
		private static DBConfig<T> _db;
		private static IMongoClient mongoClient;
		private static IMongoDatabase mongoDatabase;

		private static IMongoDatabase GetMongoDatabase()
		{
			if (mongoDatabase == null)
			{
				mongoDatabase = GetMongoClient().GetDatabase(Database);
			}
			return mongoDatabase;
		}

		private static IMongoClient GetMongoClient()
		{
			if (mongoClient == null)
			{
				mongoClient = new MongoClient(ConnectionString);
			}
			return mongoClient;
		}

		public static DBConfig<T> DataBase
		{
			get
			{
				if (_db == null)
				{
					_db = new DBConfig<T>();
				}
				return _db;
			}
		}

		public static IMongoCollection<T> GetMongoCollection()
		{
			return GetMongoDatabase().GetCollection<T>(typeof(T).Name);
		}

		public static DateTime GetCurrentDateTimeServer()
		{
			BsonDocumentCommand<BsonDocument> serverStatusCmd = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "serverStatus", 1 } });
			var result = GetMongoClient().GetDatabase(Database).RunCommand(serverStatusCmd);
			return result["localTime"].ToLocalTime();
		}

		static public string GerarIdentificadorUnico(Double latitude, Double longitude, DateTime dataHora)
		{
			return latitude.ToString().Replace(",", "") + longitude.ToString().Replace(",", "") +
									dataHora.Year +
									dataHora.Month.ToString().PadLeft(2, '0') +
									dataHora.Day.ToString().PadLeft(2, '0') +
									dataHora.Hour.ToString().PadLeft(2, '0') +
									dataHora.Minute.ToString().PadLeft(2, '0') +
									dataHora.Second.ToString().PadLeft(2, '0') +
									dataHora.Millisecond.ToString();
		}
	}
}
