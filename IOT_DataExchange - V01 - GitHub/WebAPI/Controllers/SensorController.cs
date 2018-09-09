using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class SensorController : Controller
    {
		private IRepSensor Sensores;

		public SensorController(IRepSensor _rep)
		{
			Sensores = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<Sensor>> ListarTodos()
		{
			return await Sensores.ListarTodos();
		}

		[HttpGet("{id}", Name = "Sensor")]
		public IActionResult Encontrar(string id)
		{
			Task<Sensor> sensor = Sensores.Encontrar(id);
			if (sensor == null)
				return NotFound();
			return new ObjectResult(sensor);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Sensor sensor)
		{
			if (sensor == null)
				return BadRequest();
			Sensores.Inserir(sensor);
			return CreatedAtRoute("Sensor", new { Controller = "Sensor", id = sensor.Id }, sensor);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] Sensor sensor)
		{
			if (sensor == null)
				return BadRequest();
			Sensores.Atualizar(sensor);
			return CreatedAtRoute("Sensor", new { Controller = "Sensor", id = sensor.Id }, sensor);
		}

		[HttpDelete]
		public async Task Excluir(string id)
		{
			await Sensores.Excluir(id);
		}
		
    }
}
