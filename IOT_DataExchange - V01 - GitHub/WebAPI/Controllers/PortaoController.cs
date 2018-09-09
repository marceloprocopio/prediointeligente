using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class PortaoController : Controller
    {
		private IRepPortao Portoes;

		public PortaoController(IRepPortao _rep)
		{
			Portoes = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<Portao>> ListarTodos()
		{
			return await Portoes.ListarTodos();
		}

		[HttpGet("{id}", Name = "Portao")]
		public IActionResult Encontrar(string id)
		{
			Task<Portao> portao = Portoes.Encontrar(id);
			if (portao == null)
				return NotFound();
			return new ObjectResult(portao);
		}

		[HttpPost]
		public IActionResult Inserir([FromHeader] Portao portao)
		{
			if (portao == null)
				return BadRequest();
			Portoes.Inserir(portao);
			return CreatedAtRoute("Localizacao", new { Controller = "Localizacao", id = portao.Id }, portao);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar([FromBody] Portao portao)
		{
			if (portao == null)
				return BadRequest();
			Portoes.Atualizar(portao);
			return CreatedAtRoute("Portao", new { Controller = "Portao", id = portao.Id }, portao);
		}

		[HttpDelete("{id}")]
		public async Task Excluir(string id)
		{
			await Portoes.Excluir(id);
		}
    }
}
