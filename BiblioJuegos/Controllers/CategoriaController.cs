using BiblioJuegos.BOL;
using BiblioJuegos.DAL.IRepo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BiblioJuegos.ViewModels.CategoriaVM;
using ReflectionIT.Mvc.Paging;

namespace BiblioJuegos.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepo _repo;

        public CategoriaController(ICategoriaRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index(int page  = 1)
        {
            var categorias = _repo.OrdenarPorNombre();

            var categoriasLista = (IOrderedQueryable<CategoriaVMIndex>) categorias.Select(x => new CategoriaVMIndex()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                ImagenURL = x.ImagenURL,
                Descripcion = x.Descripcion
            });
            var modeloARetornar = await PagingList.CreateAsync(categoriasLista, 5, page);

            return View(modeloARetornar);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(CategoriaVMIndex categoriaVM)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria()
                {
                    Nombre = categoriaVM.Nombre,
                    Descripcion = categoriaVM.Descripcion,
                    ImagenURL = categoriaVM.ImagenURL
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

            var categoriaViwModel = new CategoriaVMIndex()
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                ImagenURL = categoria.ImagenURL
            };
            return View(categoriaViwModel);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(CategoriaVMIndex categoriaVM)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria
                {
                    Id = categoriaVM.Id,
                    Nombre = categoriaVM.Nombre,
                    Descripcion = categoriaVM.Descripcion,
                    ImagenURL = categoriaVM.ImagenURL
                };
                await _repo.Actualizar(categoria);

                return RedirectToAction("Index");
            }

            return View(categoriaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var categoria = await _repo.ObtenerPorId(id);

            var categoriaViewModel = new CategoriaVMDetalles()
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                ImagenURL = categoria.ImagenURL,
                AgregadoEn = categoria.AgregadoEn
            };

            return View(categoriaViewModel);
        }

        [HttpGet]



        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _repo.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorCategoria"] =
                    "Esta categoría está vinculada con un videojuego. Desvincúlela para eliminarla.";
                return RedirectToAction("Index");
            }
        }
    }
}
