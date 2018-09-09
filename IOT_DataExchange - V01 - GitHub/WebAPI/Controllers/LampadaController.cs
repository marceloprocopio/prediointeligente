using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/controller")]
	public class LampadaController : Controller
    {
		private IRepLampada Lampadas;

		public LampadaController(IRepLampada _rep)
		{
			Lampadas = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<Lampada>> ListarTodos()
		{
			return await Lampadas.ListarTodos();
		}

		[HttpGet("{id}", Name = "Lampada")]
		public IActionResult Encontrar(string id)
		{
			Task<Lampada> lampada = Lampadas.Encontrar(id);
			if (lampada == null)
			{
				return NotFound();
			}
			return new ObjectResult(lampada);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Lampada lampada)
		{
			if (lampada == null)
				return BadRequest();
			Lampadas.Inserir(lampada);
			return CreatedAtRoute("Lampada", new { Controller = "Lampada", id = lampada.Id }, lampada);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(string id, [FromBody] Lampada lampada)
		{
			if (lampada == null)
				return BadRequest();
			Lampadas.Atualizar(lampada);
			return CreatedAtRoute("Lampada", new { Controller = "Lampada", id = lampada.Id }, lampada);
		}

		async Task Excluir(string id)
		{
			await Lampadas.Excluir(id);
		}
    }
}
