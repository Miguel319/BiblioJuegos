using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;

namespace BiblioJuegos.DAL.IRepo
{
    public interface ICompaniaRepo
    {
        Task<Compania> ObtenerPorId(int id);
        Task<IEnumerable<Compania>> ObtenerTodas();
        Task Agregar(Compania Compania);
        Task Actualizar(Compania Compania);
        Task Eliminar(int id);
    }
}
