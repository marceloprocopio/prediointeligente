using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepLocalizacao
    {
		Task Inserir(Localizacao localizacao);
		Task<IEnumerable<Localizacao>> ListarTodos();
		Task<Localizacao> Encontrar(string objectId);
		Task Excluir(string objectId);
		Task Atualizar(Localizacao localizacao);
    }
}
