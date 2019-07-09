using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using BiblioJuegos.DAL.IRepo;
using Microsoft.EntityFrameworkCore;

namespace BiblioJuegos.BLL
{
    public class CategoriaRepo : BaseRepo, ICategoriaRepo
    {
        public CategoriaRepo(BiblioJuegosContext context) : base(context) {}

        public async Task<Categoria> ObtenerPorId(int id) =>
            await _context.Categorias.FindAsync(id);

        public async Task<IEnumerable<Categoria>> ObtenerTodas() =>
            await _context.Categorias.AsNoTracking()
                .OrderBy(x => x.Nombre)
                .ToListAsync();

        public async Task Agregar(Categoria categoria)
        {
            categoria.AgregadoEn = DateTime.Now;
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }           

        public async Task Eliminar(int id)
        {
            _context.Categorias.Remove(await ObtenerPorId(id));
            await _context.SaveChangesAsync();
        }

        public IOrderedQueryable<Categoria> OrdenarPorNombre()
            =>  _context.Categorias.AsNoTracking().OrderBy(x => x.Nombre);
    }
}
