using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class ArCondicionadoController : Controller
    {
		private IRepArCondicionado CondicionadoresDeAr;

		public ArCondicionadoController(IRepArCondicionado _rep)
		{
			CondicionadoresDeAr = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<ArCondicionado>> ListarTodos()
		{
			return await CondicionadoresDeAr.ListarTodos();
		}

		[HttpGet("{id}", Name = "ArCondicionado")]
		public IActionResult Encontrar(string id)
		{
			Task<ArCondicionado> arCondicionado = CondicionadoresDeAr.Encontrar(id);
			if (arCondicionado == null)
				return NotFound();
			return new ObjectResult(arCondicionado);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] ArCondicionado arCondicionado)
		{
			if (arCondicionado == null)
				return BadRequest();
			CondicionadoresDeAr.Inserir(arCondicionado);
			return CreatedAtRoute("ArCondicionado", new { Controller = "ArCondicionado", id = arCondicionado.Id }, arCondicionado);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] ArCondicionado arCondicionado)
		{
			if (arCondicionado == null)
				return BadRequest();
			CondicionadoresDeAr.Atualizar(arCondicionado);
			return CreatedAtRoute("ArCondicionado", new { Controller = "ArCondicionado", id = arCondicionado.Id }, arCondicionado);
		}

		[HttpDelete]
		public async Task Excluir(string id)
		{
			await CondicionadoresDeAr.Excluir(id);
		}

    }
}
