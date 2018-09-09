using System.Collections.Generic;
using WebAPI.DataAccessLayer.Entidades;

namespace WebAPI.DataAccessLayer.Repository
{
    public interface IRepMetrica
    {
		void Inserir(Metrica metrica);
		IEnumerable<Metrica> ListarTodos();
		Metrica Encontrar(string id);
		void Excluir(string id);
		void Atualizar(Metrica metrica);
    }
}
