using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepJanela
    {
		Task Inserir(Janela janela);
		Task<IEnumerable<Janela>> ListarTodos();
		Task<Janela> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(Janela janela);
    }
}
