using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepSmartPhone
    {
		Task Inserir(SmartPhone smartPhone);
		Task<IEnumerable<SmartPhone>> ListarTodos();
		Task<SmartPhone> Encontrar(string id);
		Task Excluir(string id);
		Task Atualizar(SmartPhone smartPhone);
    }
}
