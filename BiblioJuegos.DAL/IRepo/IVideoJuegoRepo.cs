using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;

namespace BiblioJuegos.DAL.IRepo
{
    public interface IVideojuegoRepo
    {
        Task<Videojuego> ObtenerPorId(int id);
        Task<IEnumerable<Videojuego>> ObtenerTodos();
        Task Agregar(Videojuego VideoJuego);
        Task Actualizar(Videojuego VideoJuego);
        Task Eliminar(int id);
    }
}
