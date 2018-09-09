using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepUmidificadorAr
    {
		Task Inserir(UmidificadorAr umidificadorAr);
		Task<IEnumerable<UmidificadorAr>> ListarTodos();
		Task<UmidificadorAr> Encontrar(string id);
		Task Exluir(string id);
		Task Atualizar(UmidificadorAr umidificadorAr);
    }
}
