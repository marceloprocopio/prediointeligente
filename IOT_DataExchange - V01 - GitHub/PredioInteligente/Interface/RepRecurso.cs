using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PredioInteligente.Interface
{
	public class RepRecurso<T> : IRepRecurso<T>
	{
		static string controllerString;
		static string uriString = "http://localhost:56461/";
		static string dataFormat = "application/json";

		static HttpClient client;

		public RepRecurso()
		{
			if (client == null)
			{
				client = new HttpClient();
				client.BaseAddress = new Uri(uriString);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(dataFormat));
				client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));
				controllerString = "api/" + typeof(T).Name;
			}
		}

		public async Task Atualizar(T t)
		{
			string json = JsonConvert.SerializeObject(t);
			HttpContent body = new StringContent(json, Encoding.UTF8, dataFormat);

			HttpResponseMessage response = await client.PutAsync(controllerString, body);

			response.EnsureSuccessStatusCode();
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				t = JsonConvert.DeserializeObject<T>(data);
			}

		}

		public async Task<T> Encontrar(string id)
		{
			T t;
			HttpResponseMessage response = await client.GetAsync(controllerString + @"/" + id);
			string data = await response.Content.ReadAsStringAsync();
			t = JsonConvert.DeserializeObject<T>(data);
			return t;
		}

		public Task Excluir(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<T> Inserir(T t)
		{
			string json = JsonConvert.SerializeObject(t);
			HttpContent body = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await client.PostAsync(controllerString, body);

			response.EnsureSuccessStatusCode();
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				t = JsonConvert.DeserializeObject<T>(data);
			}
			return t;
		}

		public async Task<List<T>> ListarTodos()
		{
			List<T> tList = null;
			HttpResponseMessage response = await client.GetAsync(controllerString);
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				tList = JsonConvert.DeserializeObject<List<T>>(data);
			}
			return tList;
		}

		public async Task<List<T>> ListarTodos(string idContainer)
		{
			List<T> tList = null;
			HttpResponseMessage response = await client.GetAsync(controllerString);
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				tList = JsonConvert.DeserializeObject<List<T>>(data);
			}
			return tList;
		}
	}
}
