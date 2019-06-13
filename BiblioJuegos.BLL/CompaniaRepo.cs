using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using BiblioJuegos.DAL.IRepo;
using Microsoft.EntityFrameworkCore;

namespace BiblioJuegos.BLL
{
    public class CompaniaRepo : BaseRepo, ICompaniaRepo
    {
        public CompaniaRepo(BiblioJuegosContext context) : base(context) { }

        public async Task<Compania> ObtenerPorId(int id) =>
            await _context.Companias.FindAsync(id);

        public async Task<IEnumerable<Compania>> ObtenerTodas() =>
            await _context.Companias.ToListAsync();

        public async Task Agregar(Compania Compania)
        {
            await _context.Companias.AddAsync(Compania);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Compania Compania)
        {
            _context.Entry(Compania).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Companias.Remove(await ObtenerPorId(id));
            await _context.SaveChangesAsync();
        }
    }
}
