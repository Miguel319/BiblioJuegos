using BiblioJuegos.DAL;

namespace BiblioJuegos.BLL
{
    public class BaseRepo
    {
        protected BiblioJuegosContext _context;

        public BaseRepo(BiblioJuegosContext context) => _context = context;
    }
}
