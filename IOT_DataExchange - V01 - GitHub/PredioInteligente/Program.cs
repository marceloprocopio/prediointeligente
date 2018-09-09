using PredioInteligente.Interface;
using PredioInteligente.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PredioInteligente
{
	class Program
	{
		private static int QtePredios = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QtePredios"]);
		private static int QteAmbientes = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QteAmbientes"]);
		private static int QteSensores = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QteSensores"]);
		private static int QteJanelas = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QteJanelas"]);
		private static int QteLampadas = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QteLampadas"]);
		private static int QteCondicionadoresDeAr = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QteCondicionadoresDeAr"]);
		private static int QteUmidificadoresDeAr = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["QteUmidificadoresDeAr"]);
		private static int QteMedicoes = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["QteMedicoes"]);

		private static string LocalRegistroCarimboDataHoraProcessamento = @"C:\Projetos\CEFET\99 - Monografia\Tema_ComunicacaoDistribuida\MIT\03 - Testes\RegistroCarimboDataHoraProcessamento\CargaPredio_V02";

		private static IList<Predio> Predios;
		private static IList<AmbienteTrabalho> Ambientes;
		private static IList<Metrica> Metricas;

		private static IRepRecurso<Predio> repPredio = new RepRecurso<Predio>();
		private static IRepRecurso<AmbienteTrabalho> repAmbiente = new RepRecurso<AmbienteTrabalho>();
		private static IRepRecurso<Metrica> repMetrica = new RepRecurso<Metrica>();
		private static IRepRecurso<Medicao> repMedicao = new RepRecurso<Medicao>();

		private static DateTime dataHora;

		static void Main(string[] args)
		{
			try
			{
				dataHora = DateTime.Now;

				ExecutarCarga();
				ListarPredios();
				ExecutarMedicoes();
				//ExecutarCenario5().Wait();



				Console.WriteLine("Execução Finalizada com Sucesso.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.InnerException);
			}

			Console.ReadLine();
		}

		#region CarregamentoPredio

		private static void ExecutarCarga()
		{
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "======================");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Prédios " + QtePredios);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Ambientes " + QteAmbientes);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Sensores " + QteSensores);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Janelas " + QteJanelas);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Lâmpadas" + QteLampadas);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Condicionadores de Ar " + QteCondicionadoresDeAr);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Umidificadores de Ar " + QteUmidificadoresDeAr);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Quantidade de Medições " + QteMedicoes);
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "----------------------");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Inicio Carregamento Prédio");
			CarregarDados();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "Fim");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "----------------------");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "======================");
		}

		private static void CarregarDados()
		{
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento predios");
			CarregarPredio().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento ambientes");
			CarregarAmbientes().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento sensores");
			CarregarSensores().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Início carregamento Janelas");
			CarregarJanelas().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento lampadas");
			CarregarLampadas().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento Condicionadores de Ar");
			CarregarCondicionadoresAr().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento Umidificadores de Ar");
			CarregarUmidificadoresAr().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio carregamento Métricas");
			CarregarMetricas().Wait();
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");
		}

		private static async Task CarregarPredio()
		{
			int i;
			string sufixo;
			Predios = await repPredio.ListarTodos();
			if (Predios.Count == 0)
			{
				for (i = 1; i <= QtePredios; i++)
				{
					sufixo = i.ToString().PadLeft(QtePredios.ToString().Length, '0');
					Predios.Add(await repPredio.Inserir(new Predio {
						Nome = "Prédio " + sufixo,
						Endereco = "Avenida " + sufixo + ", número " + sufixo,
						Localizacao = new Localizacao
						{
							Andar = 0,
							Corredor = 0,
							Numero = 0,
							Longitude = GerarLongitude(),
							Latitude = GerarLatitude(),
							X = 0,
							Y = 0,
							Z = 0
						}

					}));

				}
			}
		}

		private static async Task CarregarPredio(string id)
		{
			Predio predio = await repPredio.Encontrar(id);
			if (predio == null)
			{
				Console.WriteLine("Prédio não encontrado.");
			}
			else
			{
				Ambientes = await repAmbiente.ListarTodos();
			}
		}

		private static async Task CarregarAmbientes()
		{
			int j;
			int qteAmbientesNoPredio;
			string sufixo;
			Random random = new Random();
			if (Predios == null)
			{
				CarregarPredio().Wait();
			}
			Ambientes = await repAmbiente.ListarTodos();
			if (Ambientes.Count == 0)
			{
				foreach (Predio p in Predios)
				{
					qteAmbientesNoPredio = QteAmbientes;
					for (j = 1; j <= qteAmbientesNoPredio; j++)
					{
						sufixo = j.ToString().PadLeft(QteAmbientes.ToString().Length, '0');
						Ambientes.Add(await repAmbiente.Inserir(
							new AmbienteTrabalho
							{
								IdPredio = p.Id,
								Nome = "Ambiente " + sufixo,
								Localizacao = new Localizacao
								{
									Andar = GerarAndar(),
									Corredor = GerarCorredor(),
									Numero = GerarNumero(),
									Longitude = GerarLongitude(),
									Latitude = GerarLatitude(),
									X = GerarX(),
									Y = GerarY(),
									Z = GerarZ()
								},
								Sensores = new List<Sensor>(),
								Janelas = new List<Janela>(),
								Lampadas = new List<Lampada>(),
								CondicionadoresAr = new List<ArCondicionado>(),
								UmidificadoresAr = new List<UmidificadorAr>()
							}
						));
					}
				}
			}

		}

		private static async Task CarregarSensores()
		{
			int i;
			int qteSensoresNoAmbiente;
			string sufixo;
			Random random = new Random();
			if (Ambientes == null)
			{
				CarregarAmbientes().Wait();
			}
			foreach (AmbienteTrabalho a in Ambientes)
			{
				if (a.Sensores.Count == 0)
				{
					qteSensoresNoAmbiente = random.Next(1, QteSensores);
					for (i = 1; i <= qteSensoresNoAmbiente; i++)
					{
						sufixo = i.ToString().PadLeft(QteSensores.ToString().Length, '0');
						a.Sensores.Add(
							new Sensor {
								EspecificacaoTecnica = "Sensor " + sufixo,
								Estado = "LIGADO",
								Localizacao = new Localizacao {
									Andar = a.Localizacao.Andar,
									Corredor = a.Localizacao.Corredor,
									Numero = a.Localizacao.Numero,
									Latitude = a.Localizacao.Latitude,
									Longitude = a.Localizacao.Longitude,
									X = a.Localizacao.X,
									Y = a.Localizacao.Y,
									Z = a.Localizacao.Z
								}
							});
					}
					await repAmbiente.Atualizar(a);
				}
			}
		}

		private static async Task CarregarJanelas()
		{
			int i;
			int qteJanelasNoAmbiente;
			string sufixo;
			Random random = new Random();
			if (Ambientes == null)
			{
				CarregarAmbientes().Wait();
			}
			foreach (AmbienteTrabalho a in Ambientes)
			{
				if (a.Janelas.Count == 0)
				{
					qteJanelasNoAmbiente = random.Next(1, QteJanelas);
					for (i = 1; i <= qteJanelasNoAmbiente; i++)
					{
						sufixo = i.ToString().PadLeft(QteJanelas.ToString().Length, '0');
						a.Janelas.Add(
							new Janela
							{
								EspecificacaoTecnica = "Janela " + sufixo,
								Estado = "FECHADA",
								Localizacao = new Localizacao
								{
									Andar = a.Localizacao.Andar,
									Corredor = a.Localizacao.Corredor,
									Numero = a.Localizacao.Numero,
									Latitude = a.Localizacao.Latitude,
									Longitude = a.Localizacao.Longitude,
									X = a.Localizacao.X,
									Y = a.Localizacao.Y,
									Z = a.Localizacao.Z
								}
							});
					}
					await repAmbiente.Atualizar(a);
				}
			}
		}

		private static async Task CarregarLampadas()
		{
			int i;
			int qteLampadasNoAmbiente;
			string sufixo;
			Random random = new Random();
			if (Ambientes == null)
			{
				CarregarAmbientes().Wait();
			}
			foreach (AmbienteTrabalho a in Ambientes)
			{
				if (a.Lampadas.Count == 0)
				{
					qteLampadasNoAmbiente = random.Next(1, QteLampadas);
					for (i = 1; i <= qteLampadasNoAmbiente; i++)
					{
						sufixo = i.ToString().PadLeft(QteLampadas.ToString().Length, '0');
						a.Lampadas.Add(
							new Lampada
							{
								HorasDeUso = 0,
								Luminosidade = 100,
								Potencia = 80,
								Temperatura = 0,
								Estado = "DESLIGADA",
								Localizacao = new Localizacao
								{
									Andar = a.Localizacao.Andar,
									Corredor = a.Localizacao.Corredor,
									Numero = a.Localizacao.Numero,
									Latitude = a.Localizacao.Latitude,
									Longitude = a.Localizacao.Longitude,
									X = a.Localizacao.X,
									Y = a.Localizacao.Y,
									Z = a.Localizacao.Z
								}
							});
					}
					await repAmbiente.Atualizar(a);
				}
			}
		}

		private static async Task CarregarCondicionadoresAr()
		{
			int i;
			int qteCondicionadoresArNoAmbiente;
			string sufixo;
			Random random = new Random();
			if (Ambientes == null)
			{
				CarregarAmbientes().Wait();
			}
			foreach (AmbienteTrabalho a in Ambientes)
			{
				if (a.CondicionadoresAr.Count == 0)
				{
					qteCondicionadoresArNoAmbiente = random.Next(1, QteCondicionadoresDeAr);
					for (i = 1; i <= qteCondicionadoresArNoAmbiente; i++)
					{
						sufixo = i.ToString().PadLeft(QteLampadas.ToString().Length, '0');
						a.CondicionadoresAr.Add(
							new ArCondicionado
							{
								EspecificacaoTecnica = "Ar Condicionado " + sufixo,
								Fabricante = "Fabricante do Ar Condicionado " + sufixo,
								Marca = "Marca do Ar Condicionado " + sufixo,
								Modelo = "Modelo do Ar Condicionado " + sufixo,
								Versao = "Modelo do Ar Condicionado " + sufixo,
								Modo = "Não definido",
								Estado = "LIGADO",
								Localizacao = new Localizacao
								{
									Andar = a.Localizacao.Andar,
									Corredor = a.Localizacao.Corredor,
									Numero = a.Localizacao.Numero,
									Latitude = a.Localizacao.Latitude,
									Longitude = a.Localizacao.Longitude,
									X = a.Localizacao.X,
									Y = a.Localizacao.Y,
									Z = a.Localizacao.Z
								}
							});
					}
					await repAmbiente.Atualizar(a);
				}
			}
		}

		private static async Task CarregarUmidificadoresAr()
		{
			int i;
			int qteUmidificadoresArNoAmbiente;
			string sufixo;
			Random random = new Random();
			if (Ambientes == null)
			{
				CarregarAmbientes().Wait();
			}
			foreach (AmbienteTrabalho a in Ambientes)
			{
				if (a.UmidificadoresAr.Count == 0)
				{
					qteUmidificadoresArNoAmbiente = random.Next(1, QteCondicionadoresDeAr);
					for (i = 1; i <= qteUmidificadoresArNoAmbiente; i++)
					{
						sufixo = i.ToString().PadLeft(QteLampadas.ToString().Length, '0');
						a.UmidificadoresAr.Add(
							new UmidificadorAr
							{
								EspecificacaoTecnica = "Umidificador de Ar " + sufixo,
								Fabricante = "Fabricante do Umidificador  de Ar " + sufixo,
								Marca = "Marca do Umidificador  de Ar " + sufixo,
								Modelo = "Modelo do Umidificador  de Ar " + sufixo,
								Estado = "LIGADO",
								Localizacao = new Localizacao
								{
									Andar = a.Localizacao.Andar,
									Corredor = a.Localizacao.Corredor,
									Numero = a.Localizacao.Numero,
									Latitude = a.Localizacao.Latitude,
									Longitude = a.Localizacao.Longitude,
									X = a.Localizacao.X,
									Y = a.Localizacao.Y,
									Z = a.Localizacao.Z
								}
							});
					}
					await repAmbiente.Atualizar(a);
				}
			}
		}

		private static async Task CarregarMetricas()
		{
			Metricas = await repMetrica.ListarTodos();
			if (Metricas.Count == 0)
			{
				Metricas.Add(await repMetrica.Inserir(new Metrica { Descricao = "Umidade de Ar em %" }));
				Metricas.Add(await repMetrica.Inserir(new Metrica { Descricao = "Temperatura em C" }));
				Metricas.Add(await repMetrica.Inserir(new Metrica { Descricao = "Intensidade Luminosa em Candela" }));
			}
		}
		#endregion

		#region Cenario5

		private static async Task ExecutarCenario5()
		{
			Predio predio = await RecuperarPredio("19386024475097740386024475097720180827200422867");
			IList<AmbienteTrabalho> ambientes;
			if (predio == null)
			{
				Console.WriteLine("Prédio não encontrado");
			}
			else
			{
				ambientes = await RecuperarAmbientes(predio.Id);
				if (ambientes == null)
				{
					Console.WriteLine("O prédio " + predio.Nome + " está vazio.");
				}
				else
				{
					if (ambientes.Count == 0)
					{
						Console.WriteLine("O Prédio " + predio.Nome + " está vazio.");
					}
					else
					{

						Console.WriteLine("ID do prédio: " + predio.Id);
						Console.WriteLine("Nome do prédio: " + predio.Nome);

						foreach (AmbienteTrabalho ambiente in ambientes)
						{
							Console.WriteLine("ID do ambiente: " + ambiente.Id);
							Console.WriteLine("Nome do ambiente: " + ambiente.Nome);
						}

					}
				}

			}
		}

		private static async Task<Predio> RecuperarPredio(string id)
		{
			return await repPredio.Encontrar(id);
		}

		private static async Task<IList<AmbienteTrabalho>> RecuperarAmbientes(string idPredio)
		{
			return await repAmbiente.ListarTodos(idPredio);
		}

		#endregion

		#region RedeSensores
		private static void ExecutarMedicoes()
		{
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "======================");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "----------------------");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio Execução de Medições");

			int idxAmbiente;
			int idxSensor;
			Random random = new Random();
			for (int i = 1; i <= QteMedicoes; i++)
			{
				idxAmbiente = random.Next(Ambientes.Count);
				idxSensor = random.Next(Ambientes[idxAmbiente].Sensores.Count);

				RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio Medições no Ambiente " + Ambientes[idxAmbiente].Nome + " pelo sensor " + Ambientes[idxAmbiente].Sensores[idxSensor].EspecificacaoTecnica);
				ExecutarMedicao(Ambientes[idxAmbiente].Sensores[idxSensor]);
				RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");
			}

			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "----------------------");
			RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, "======================");
		}

		private static void ExecutarMedicao(Sensor sensor)
		{
			Random random = new Random();
			Medicao medicao = new Medicao
			{
				Sensor = sensor
			};
			foreach (Metrica metrica in Metricas)
			{

				RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Inicio Medição de " + metrica.Descricao);
				medicao.Metrica = metrica;
				medicao.Valor = random.NextDouble().ToString();
				medicao.DataHora = DateTime.Now;
				SalvarMedicao(medicao).Wait();
				RegistrarCarimboDataHoraProcessamento(LocalRegistroCarimboDataHoraProcessamento, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " - Fim");
			}
		}

		private static async Task SalvarMedicao(Medicao medicao)
		{
			await repMedicao.Inserir(medicao);
		}

		#endregion

		private static void ExecutarConsulta()
		{
		}

		private static void ListarPredios()
		{
			Console.WriteLine("================");
			Console.WriteLine("Lista de Prédios");
			Console.WriteLine("================");

			foreach (Predio p in Predios)
			{
				Console.WriteLine("---------------------------");
				Console.WriteLine("Nome: " + p.Nome);
				Console.WriteLine("---------------------------");
			}

			Console.WriteLine("================");
			Console.WriteLine("FIM - Lista de Prédios");
			Console.WriteLine("================");
		}

		private static void ListarAmbientes()
		{
			// To Do
		}

		private static Double GerarLatitude()
		{
			int i;
			double resultado;
			Random random = new Random();
			i = random.Next(-90, 90);
			if (i > 0)
				resultado = i - random.NextDouble();
			else
				resultado = i + random.NextDouble();
			return resultado;
		}

		private static Double GerarLongitude()
		{
			int i;
			double resultado;
			Random random = new Random();
			i = random.Next(-180, 180);
			if (i > 0)
				resultado = i - random.NextDouble();
			else
				resultado = i + random.NextDouble();
			return resultado;
		}

		private static int GerarAndar()
		{
			// To do
			return 0;
		}

		private static int GerarCorredor()
		{
			// To do
			return 0;
		}

		private static int GerarNumero()
		{
			// To do
			return 0;
		}

		private static int GerarX()
		{
			return 0;
		}

		private static int GerarY()
		{
			return 0;
		}

		private static int GerarZ()
		{
			return 0;
		}

		private static void RegistrarCarimboDataHoraProcessamento(string local, string msg)
		{
			string nomeArquivo;
			nomeArquivo =
				dataHora.Year +
				dataHora.Month.ToString().PadLeft(2, '0') +
				dataHora.Day.ToString().PadLeft(2, '0') +
				dataHora.Hour.ToString().PadLeft(2, '0') +
				dataHora.Minute.ToString().PadLeft(2, '0') +
				dataHora.Second.ToString().PadLeft(2, '0');
			Console.WriteLine(msg);
			System.IO.File.AppendAllText(local + @"\" + nomeArquivo + ".log", msg + "\n", System.Text.Encoding.Default);
		}
	}
}
