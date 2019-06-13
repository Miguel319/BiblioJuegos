using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using BiblioJuegos.DAL.IRepo;
using Microsoft.EntityFrameworkCore;

namespace BiblioJuegos.BLL
{
    public class UsuarioRepo : BaseRepo, IUsuarioRepo
    {
        public UsuarioRepo(BiblioJuegosContext context) : base(context) { }

        public async Task<Usuario> ObtenerPorId(int id) =>
            await _context.Usuarios.FindAsync(id);

        public async Task<IEnumerable<Usuario>> ObtenerTodos() =>
            await _context.Usuarios.ToListAsync();

        public async Task Agregar(Usuario Usuario)
        {
            await _context.Usuarios.AddAsync(Usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Usuario Usuario)
        {
            _context.Entry(Usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Usuarios.Remove(await ObtenerPorId(id));
            await _context.SaveChangesAsync();
        }
    }
}
