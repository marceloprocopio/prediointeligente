using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class VeiculoController : Controller
	{
		private IRepVeiculo Veiculos;

		public VeiculoController(IRepVeiculo _rep)
		{
			Veiculos = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<Veiculo>> ListarTodos()
		{
			return await Veiculos.ListarTodos();
		}

		[HttpGet("{id}", Name = "Veiculo")]
		public IActionResult Encontrar(string id)
		{
			Task<Veiculo> veiculo = Veiculos.Encontrar(id);
			if (veiculo == null)
				return NotFound();
			return new ObjectResult(veiculo);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] Veiculo veiculo)
		{
			if (veiculo == null)
				return BadRequest();
			Veiculos.Inserir(veiculo);
			return CreatedAtRoute("Veiculo", new { Controller = "Veiculo", id = veiculo.Id }, veiculo);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(string id, [FromBody] Veiculo veiculo)
		{
			if (veiculo == null)
				return BadRequest();
			Veiculos.Atualizar(veiculo);
			return CreatedAtRoute("Veiculo", new { Controller = "Veiculo", id = veiculo.Id }, veiculo);
		}

		[HttpDelete("{id}")]
		public async Task Excluir(string id)
		{
			await Veiculos.Excluir(id);
		}

    }
}
