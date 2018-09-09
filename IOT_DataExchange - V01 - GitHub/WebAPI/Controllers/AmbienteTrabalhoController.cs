using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
    public class AmbienteTrabalhoController : Controller
    {
		private IRepAmbienteTrabalho AmbientesTrabalho;

		public AmbienteTrabalhoController(IRepAmbienteTrabalho _rep)
		{
			AmbientesTrabalho = _rep;
		}

		[HttpGet]
		public IEnumerable<AmbienteTrabalho> ListarTodos()
		{
			return AmbientesTrabalho.ListarTodos();
		}

		[HttpGet]
		[Route("predio/{idPredio}")]
		public IEnumerable<AmbienteTrabalho> ListarTodos(string idPredio)
		{
			return AmbientesTrabalho.ListarTodos(idPredio);
		}

		[HttpGet("{id}", Name = "AmbienteTrabalho")]
		public IActionResult Encontrar(string id)
		{
			AmbienteTrabalho ambienteTrabalho = AmbientesTrabalho.Encontrar(id);
			if (ambienteTrabalho == null)
				return NotFound();
			return new ObjectResult(ambienteTrabalho);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] AmbienteTrabalho ambienteTrabalho)
		{
			if (ambienteTrabalho == null)
				return BadRequest();
			AmbientesTrabalho.Inserir(ambienteTrabalho);
			return CreatedAtRoute("AmbienteTrabalho", new { Controller = "AmbienteTrabalho", id = ambienteTrabalho.Id }, ambienteTrabalho);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] AmbienteTrabalho ambienteTrabalho)
		{
			if (ambienteTrabalho == null)
				return BadRequest();
			AmbientesTrabalho.Atualizar(ambienteTrabalho);
			return CreatedAtRoute("AmbienteTrabalho", new { Controller = "AmbienteTrabalho", id = ambienteTrabalho.Id }, ambienteTrabalho);
		}

		[HttpDelete]
		public void Excluir(string id)
		{
			AmbientesTrabalho.Excluir(id);
		}
	}
}
