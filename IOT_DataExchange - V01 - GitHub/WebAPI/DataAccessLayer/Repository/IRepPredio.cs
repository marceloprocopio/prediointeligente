using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepPredio
    {
		void Inserir(Predio predio);
		IEnumerable<Predio> ListarTodos();
		Predio Encontrar(string id);
		void Excluir(string id);
		void Atualizar(Predio predio);
    }
}
