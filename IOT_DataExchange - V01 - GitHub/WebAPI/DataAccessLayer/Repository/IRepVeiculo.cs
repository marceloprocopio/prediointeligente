using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepVeiculo
    {
		Task Inserir(Veiculo veiculo);
		Task<IEnumerable<Veiculo>> ListarTodos();
		Task<Veiculo> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(Veiculo veiculo);
    }
}
