using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class PredioController : Controller
	{
		private IRepPredio Predios;

		public PredioController(IRepPredio _rep)
		{
			Predios = _rep;
		}

		[HttpGet]
		public IEnumerable<Predio> ListarTodos()
		{
			return Predios.ListarTodos();
		}

		[HttpGet("{id}", Name = "Predio")]
		public IActionResult Encontrar(string id)
		{
			Predio predio = Predios.Encontrar(id);
			if (predio == null)
				return NotFound();
			return new ObjectResult(predio);
		}

		[ProducesResponseType(201, Type = typeof(Predio))]
		[ProducesResponseType(400)]
		[HttpPost]
		public IActionResult Inserir([FromBody] Predio predio)
		{
			if (predio == null)
				return BadRequest();
			Predios.Inserir(predio);
			return CreatedAtRoute("Predio", new { Controller = "Predio", id = predio.Id }, predio);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] Predio predio)
		{
			if (predio == null)
				return BadRequest();
			Predios.Atualizar(predio);
			return CreatedAtRoute("Predio", new { Controller = "Predio", id = predio.Id }, predio);
		}

		[HttpDelete]
		public void Excluir(string id)
		{
			Predios.Excluir(id);
		}
    }
}
