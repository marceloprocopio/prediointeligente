using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
    public class MedicaoController : Controller
    {
		private IRepMedicao Medicoes;

		public MedicaoController(IRepMedicao _rep)
		{
			Medicoes = _rep;
		}

		[HttpGet]
		public IEnumerable<Medicao> ListarTodos()
		{
			return Medicoes.ListarTodos();
		}

		[HttpGet("{id}", Name = "Medicao")]
		public IActionResult Encontrar(string id)
		{
			Medicao medicao = Medicoes.Encontrar(id);
			if (medicao == null)
				return NotFound();
			return new ObjectResult(medicao);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Medicao medicao)
		{
			if (medicao == null)
				return BadRequest();
			Medicoes.Inserir(medicao);
			return CreatedAtRoute("Medicao", new { Controller = "Medicao", id = medicao.Id }, medicao);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] Medicao medicao)
		{
			if (medicao == null)
				return BadRequest();
			Medicoes.Atualizar(medicao);
			return CreatedAtRoute("Medicao", new { Controller = "Medicao", id = medicao.Id }, medicao);
		}

		[HttpDelete("{id}")]
		public void Excluir(string id)
		{
			Medicoes.Excluir(id);
		}

    }
}
