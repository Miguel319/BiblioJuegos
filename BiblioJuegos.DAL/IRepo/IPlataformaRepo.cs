using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;

namespace BiblioJuegos.DAL
{
    public interface IPlataformaRepo
    {
        Task<Plataforma> ObtenerPorId(int id);
        Task<IEnumerable<Plataforma>> ObtenerTodas();
        Task Agregar(Plataforma Plataforma);
        Task Actualizar(Plataforma Plataforma);
        Task Eliminar(int id);
    }
}
