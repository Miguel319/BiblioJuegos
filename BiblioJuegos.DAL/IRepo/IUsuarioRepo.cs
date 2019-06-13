using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;

namespace BiblioJuegos.DAL.IRepo
{
    public interface IUsuarioRepo
    {
        Task<Usuario> ObtenerPorId(int id);
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task Agregar(Usuario Usuario);
        Task Actualizar(Usuario Usuario);
        Task Eliminar(int id);
    }
}
