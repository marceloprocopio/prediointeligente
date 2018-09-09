using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class UmidificadorArController : Controller
    {
		private IRepUmidificadorAr UmidificadoresAr;

		public UmidificadorArController(IRepUmidificadorAr _rep)
		{
			UmidificadoresAr = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<UmidificadorAr>> ListarTodos()
		{
			return await UmidificadoresAr.ListarTodos();
		}

		[HttpGet("{id}", Name = "UmidificadorAr")]
		public IActionResult Encontrar(string id)
		{
			Task<UmidificadorAr> umidificadorAr = UmidificadoresAr.Encontrar(id);
			if (umidificadorAr == null)
				return BadRequest();
			return new ObjectResult(umidificadorAr);
		}

		[HttpPost]
		public IActionResult Inserir([FromBody] UmidificadorAr umidificadorAr)
		{
			if (umidificadorAr == null)
				return BadRequest();
			return CreatedAtRoute("UmidificadorAr", new { Controller = "UmidificadorAr", id = umidificadorAr.Id }, umidificadorAr);
		}

		[HttpPut]
		public IActionResult Atualizar([FromBody] UmidificadorAr umidificadorAr)
		{
			if (umidificadorAr == null)
				return BadRequest();
			UmidificadoresAr.Atualizar(umidificadorAr);
			return CreatedAtRoute("UmidificadorAr", new { Controller = "UmidificadorAr", id = umidificadorAr.Id }, umidificadorAr);
		}
	}
}
