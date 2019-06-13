using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using Microsoft.EntityFrameworkCore;

namespace BiblioJuegos.BLL
{
    public class PlataformaRepo : BaseRepo, IPlataformaRepo
    {
        public PlataformaRepo(BiblioJuegosContext context) : base(context) { }

        public async Task<Plataforma> ObtenerPorId(int id) =>
            await _context.Plataformas.FindAsync(id);

        public async Task<IEnumerable<Plataforma>> ObtenerTodas() =>
            await _context.Plataformas.ToListAsync();

        public async Task Agregar(Plataforma Plataforma)
        {
            await _context.Plataformas.AddAsync(Plataforma);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Plataforma Plataforma)
        {
            _context.Entry(Plataforma).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Plataformas.Remove(await ObtenerPorId(id));
            await _context.SaveChangesAsync();
        }
    }
}
