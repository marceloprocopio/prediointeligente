using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepArCondicionado
    {
		Task Inserir(ArCondicionado arCondicionado);
		Task<IEnumerable<ArCondicionado>> ListarTodos();
		Task<ArCondicionado> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(ArCondicionado arCondicionado);
    }
}
