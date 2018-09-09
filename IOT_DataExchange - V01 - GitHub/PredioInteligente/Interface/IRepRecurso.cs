using System.Collections.Generic;
using System.Threading.Tasks;

namespace PredioInteligente.Interface
{
	public interface IRepRecurso<T>
	{
		Task<T> Inserir(T t);
		Task<List<T>> ListarTodos();
		Task<List<T>> ListarTodos(string idContainer);
		Task<T> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(T t);
	}
}
