/*
 * Referência sobre WebAPI
 * 
 * 
 * MongoDB operações CRUD com C#
 * https://medium.com/@fulviocanducci/mongodb-opera%C3%A7%C3%B5es-crud-com-c-2af4e77c046
 * 
 * Read and use settings from appsettings.json without IOptions<T>?
 * https://stackoverflow.com/questions/43679665/read-and-use-settings-from-appsettings-json-without-ioptionst
 *  
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			// Criando injeção de dependência
			/*
			 *	Referência: "Dependency injection in ASP.NET Core"
			 *	URL: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.1
			 * 
			 */
			services.AddTransient<IRepAmbienteTrabalho, RepAmbienteTrabalho>();
			services.AddTransient<IRepArCondicionado, RepArCondicionado>();
			services.AddTransient <IRepColaborador, RepColaborador>();
			services.AddTransient <IRepJanela, RepJanela>();
			services.AddTransient <IRepLampada, RepLampada>();
			services.AddTransient <IRepLocalizacao, RepLocalizacao>();
			services.AddTransient <IRepMedicao, RepMedicao>();
			services.AddTransient <IRepMetrica, RepMetrica>();
			services.AddTransient <IRepPortao, RepPortao>();
			services.AddTransient<IRepPredio, RepPredio>();
			services.AddTransient <IRepSensor, RepSensor>();
			services.AddTransient <IRepSmartPhone, RepSmartPhone>();
			services.AddTransient <IRepUmidificadorAr, RepUmidificadorAr>();
			services.AddTransient <IRepVeiculo, RepVeiculo>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
			{
				routes.MapRoute("default", "{controller=AmbienteTrabalho}/{action=ListarTodos}/{id?}");
			});
        }
    }
}
