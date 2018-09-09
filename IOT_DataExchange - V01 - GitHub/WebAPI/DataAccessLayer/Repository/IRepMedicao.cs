using System.Collections.Generic;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepMedicao
    {
		void Inserir(Medicao medicao);
		IEnumerable<Medicao> ListarTodos();
		Medicao Encontrar(string id);
		void Excluir(string id);
		void Atualizar(Medicao medicao);
    }
}
