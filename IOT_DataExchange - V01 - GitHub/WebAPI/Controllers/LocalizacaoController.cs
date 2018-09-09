using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class LocalizacaoController : Controller
    {
		private IRepLocalizacao Localizacoes;

		public LocalizacaoController(IRepLocalizacao _rep)
		{
			Localizacoes = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<Localizacao>> ListarTodos()
		{
			return await Localizacoes.ListarTodos();
		}

		[HttpGet("id", Name = "Localizacao")]
		public IActionResult Encontrar(string id)
		{
			Task<Localizacao> localizacao = Localizacoes.Encontrar(id);
			if (localizacao == null)
				return NotFound();
			return new ObjectResult(localizacao);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Localizacao localizacao)
		{
			if (localizacao == null)
				return BadRequest();
			return CreatedAtRoute("Localizacao", new { Controller = "Localizacao", id = localizacao.Id }, localizacao);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(string id, [FromBody] Localizacao localizacao)
		{
			if (localizacao == null)
				return BadRequest();
			Localizacoes.Atualizar(localizacao);
			return CreatedAtRoute("Localizacao", new { Controller = "Localizacao", id = localizacao.Id }, localizacao);
		}

		[HttpDelete("{id}")]
		public async Task Excluir(string id)
		{
			await Localizacoes.Excluir(id);
		}

    }
}
