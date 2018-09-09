using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
    public class ColaboradorController : Controller
    {
		private IRepColaborador Colaboradores;

		public ColaboradorController(IRepColaborador _rep)
		{
			Colaboradores = _rep;
		}

		[HttpGet]
		public Task<IEnumerable<Colaborador>> ListarTodos()
		{
			return Colaboradores.ListarTodos();
		}

		[HttpGet("{cpf}", Name = "Colaborador")]
		public IActionResult Encontrar(string cpf)
		{
			Task<Colaborador> colaborador = Colaboradores.Encontrar(cpf);
			if (colaborador == null)
			{
				return NotFound();
			}
			return new ObjectResult(colaborador);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Colaborador colaborador)
		{
			if (colaborador == null)
				return BadRequest();
			Colaboradores.Inserir(colaborador);
			return CreatedAtRoute("Colaborador", new { Controller = "Colaborador", cpf = colaborador.CPF }, colaborador);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] Colaborador colaborador)
		{
			if (colaborador == null)
				return BadRequest();
			Colaboradores.Atualizar(colaborador);
			return CreatedAtRoute("Colaborador", new { Controller = "Colaborador", cpf = colaborador.CPF }, colaborador);
		}

		[HttpDelete("{cpf}")]
		public async Task Excluir(string cpf)
		{
			await Colaboradores.Excluir(cpf);
		}
    }
}
