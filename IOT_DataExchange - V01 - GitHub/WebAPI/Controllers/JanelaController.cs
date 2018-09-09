using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[Controller]")]
	public class JanelaController : Controller
	{
		private IRepJanela Janelas;

		public JanelaController(IRepJanela _rep)
		{
			Janelas = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<Janela>> ListarTodos()
		{
			return await Janelas.ListarTodos();
		}

		[HttpGet("{id}", Name = "Janela")]
		public IActionResult Encontrar(string id)
		{
			Task<Janela> janela = Janelas.Encontrar(id);
			if (janela == null)
				return NotFound();
			return new ObjectResult(janela);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Janela janela)
		{
			if (janela == null)
				return BadRequest();
			Janelas.Inserir(janela);
			return CreatedAtRoute("Janela", new { Controller = "Controller", id = janela.Id }, janela);
		}

		[HttpPut]
		public IActionResult Atualizar(string id, [FromBody] Janela janela)
		{
			if (janela == null)
				return BadRequest();
			Janelas.Atualizar(janela);
			return CreatedAtRoute("Janela", new { Controller = "Controller", id = janela.Id }, janela);
		}

		[HttpDelete("{id}")]
		public async Task Excluir(string id)
		{
			await Janelas.Excluir(id);
		}
	}
}
