using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepLampada
    {
		Task Inserir(Lampada lampada);
		Task<IEnumerable<Lampada>> ListarTodos();
		Task<Lampada> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(Lampada lampada);
    }
}
