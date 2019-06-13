using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;

namespace BiblioJuegos.DAL.IRepo
{
    public interface ICategoriaRepo
    {
        Task<Categoria> ObtenerPorId(int id);
        Task<IEnumerable<Categoria>> ObtenerTodas();
        Task Agregar(Categoria categoria);
        Task Actualizar(Categoria categoria);
        Task Eliminar(int id);
    }
}
