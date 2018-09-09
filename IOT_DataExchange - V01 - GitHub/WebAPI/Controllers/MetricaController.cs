using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class MetricaController : Controller
    {
		private IRepMetrica Metricas;

		public MetricaController(IRepMetrica _rep)
		{
			Metricas = _rep;
		}

		[HttpGet]
		public IEnumerable<Metrica> ListarTodos()
		{
			return Metricas.ListarTodos();
		}

		[HttpGet("{id}")]
		public IActionResult Encontrar(string id)
		{
			Metrica metrica = Metricas.Encontrar(id);
			if (metrica == null)
				return NotFound();
			return new ObjectResult(metrica);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Metrica metrica)
		{
			if (metrica == null)
				return BadRequest();
			Metricas.Inserir(metrica);
			//return CreatedAtRoute("Metrica", new { Controller = "Metrica", id = metrica.Id }, metrica);
			return new ObjectResult(metrica);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] Metrica metrica)
		{
			if (metrica == null)
				return BadRequest();
			Metricas.Atualizar(metrica);
			return CreatedAtRoute("Metrica", new { Controller = "Metrica", id = metrica.Id }, metrica);
		}

		[HttpDelete]
		public void Excluir(string id)
		{
			Metricas.Excluir(id);
		}

    }
}
