using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using BiblioJuegos.DAL.IRepo;
using Microsoft.EntityFrameworkCore;

namespace BiblioJuegos.BLL
{
    public class VideojuegoRepo : BaseRepo, IVideojuegoRepo
    {
        public VideojuegoRepo(BiblioJuegosContext context) : base(context) { }

        public async Task<Videojuego> ObtenerPorId(int id) =>
            await _context.Videojuegos.FindAsync(id);

        public async Task<IEnumerable<Videojuego>> ObtenerTodos() =>
            await _context.Videojuegos.ToListAsync();

        public async Task Agregar(Videojuego Videojuego)
        {
            Videojuego.AgregadoEn = DateTime.Now;
            await _context.Videojuegos.AddAsync(Videojuego);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Videojuego Videojuego)
        {
            _context.Entry(Videojuego).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Videojuegos.Remove(await ObtenerPorId(id));
            await _context.SaveChangesAsync();
        }
    }
}
