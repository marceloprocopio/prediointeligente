using WebAPI.DataAccessLayer.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepColaborador
    {
		Task Inserir(Colaborador colaborador);
		Task<IEnumerable<Colaborador>> ListarTodos();
		Task<Colaborador> Encontrar(string cpf);
		Task Excluir(string cpf);
		Task Atualizar(Colaborador colaborador);
    }
}
