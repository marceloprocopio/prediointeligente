using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepSensor
    {
		Task Inserir(Sensor sensor);
		Task<IEnumerable<Sensor>> ListarTodos();
		Task<Sensor> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(Sensor sensor);
    }
}
