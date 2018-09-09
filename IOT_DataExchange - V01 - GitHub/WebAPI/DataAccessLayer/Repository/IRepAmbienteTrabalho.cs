using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepAmbienteTrabalho
    {
		void Inserir(AmbienteTrabalho ambienteTrabalho);
		IEnumerable<AmbienteTrabalho> ListarTodos();
		IEnumerable<AmbienteTrabalho> ListarTodos(string idPredio);
		AmbienteTrabalho Encontrar(string id);
		void Excluir(string id);
		void Atualizar(AmbienteTrabalho ambienteTrabalho);
    }
}
