using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepPortao
    {
		Task Inserir(Portao portao);
		Task<IEnumerable<Portao>> ListarTodos();
		Task<Portao> Encontrar(string objectId);
		Task Excluir(string objectId);
		Task Atualizar(Portao portao);
    }
}
