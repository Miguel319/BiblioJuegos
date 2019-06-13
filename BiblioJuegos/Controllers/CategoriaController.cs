using BiblioJuegos.BOL;
using BiblioJuegos.DAL.IRepo;
using BiblioJuegos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioJuegos.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepo _repo;

        public CategoriaController(ICategoriaRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _repo.ObtenerTodas();

            var categoriasLista = categorias.Select(x => new CategoriaVM()
            {
                Id = x.Id,
                Nombre = x.Nombre
            });

            return View(categoriasLista);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(CategoriaVM categoriaVM)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria()
                {
                    Nombre = categoriaVM.Nombre,
                };

                await _repo.Agregar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoriaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var categoria = await _repo.ObtenerPorId(id);

            var categoriaViwModel = new CategoriaVM()
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
            return View(categoriaViwModel);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(CategoriaVM categoriaVM)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria
                {
                    Id = categoriaVM.Id,
                    Nombre = categoriaVM.Nombre
                };
                await _repo.Actualizar(categoria);

                return RedirectToAction("Index");
            }

            return View(categoriaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}