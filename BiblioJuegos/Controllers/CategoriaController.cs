using BiblioJuegos.BOL;
using BiblioJuegos.DAL.IRepo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BiblioJuegos.ViewModels.CategoriaVM;

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

            var categoriasLista = categorias.Select(x => new CategoriaVMIndex()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                ImagenURL = x.ImagenURL,
                Descripcion = x.Descripcion
            });

            return View(categoriasLista);
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
        public async Task<IActionResult> Eliminar(int id)
        {
            await _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}