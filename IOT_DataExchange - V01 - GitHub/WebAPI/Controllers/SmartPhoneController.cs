using WebAPI.DataAccessLayer.Entidades;
using WebAPI.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class SmartPhoneController : Controller
    {
		private IRepSmartPhone SmartPhones;

		public SmartPhoneController(IRepSmartPhone _rep)
		{
			SmartPhones = _rep;
		}

		[HttpGet]
		public async Task<IEnumerable<SmartPhone>> ListarTodos()
		{
			return await SmartPhones.ListarTodos();
		}

		[HttpGet("{id}", Name = "SmartPhone")]
		public IActionResult Encontrar(string id)
		{
			Task<SmartPhone> smartPhone = SmartPhones.Encontrar(id);
			if (smartPhone == null)
				return NotFound();
			return new ObjectResult(smartPhone);
		}

		[HttpPost]
		public IActionResult Create([FromBody] SmartPhone smartPhone)
		{
			if (smartPhone == null)
				return BadRequest();
			SmartPhones.Inserir(smartPhone);
			return CreatedAtRoute("SmartPhone", new { Controller = "SmartPhone", id = smartPhone.Id }, smartPhone);
		}

		[HttpPut("{id}")]
		public IActionResult Update(string id, [FromBody] SmartPhone smartPhone)
		{
			if (smartPhone == null)
				return BadRequest();
			Task<SmartPhone> smartPhoneParaAtualizar = SmartPhones.Encontrar(id);
			if (smartPhoneParaAtualizar == null)
				return NotFound();
			SmartPhones.Atualizar(smartPhone);
			return CreatedAtRoute("SmartPhone", new { Controller = "SmartPhone", id = smartPhone.Id }, smartPhone);
		}

		[HttpDelete("{id}")]
		public async Task Delete(string id)
		{
			await SmartPhones.Excluir(id);
		}


    }
}
