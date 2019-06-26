using BiblioJuegos.BOL;
using BiblioJuegos.DAL.IRepo;
using BiblioJuegos.ViewModels.CompaniaVM;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioJuegos.Controllers
{
    public class CompaniaController : Controller
    {
        private readonly ICompaniaRepo _repo;

        public CompaniaController(ICompaniaRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companias = await _repo.ObtenerTodas();

            var companiaModel = companias.Select(x => new CompaniaVMIndex()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenURL = x.ImagenURL
            });

            return View(companiaModel);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(CompaniaVMIndex compania)
        {
            if (ModelState.IsValid)
            {
                var companiaModel = new Compania()
                {
                    Nombre = compania.Nombre,
                    Descripcion = compania.Descripcion,
                    ImagenURL = compania.ImagenURL
                };

                await _repo.Agregar(companiaModel);
                return RedirectToAction("Index");
            }

            return View(compania);
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var compania = await _repo.ObtenerPorId(id);

            var companiaModel = new CompaniaVMIndex
            {
                Id = compania.Id,
                Nombre = compania.Nombre,
                Descripcion = compania.Descripcion,
                ImagenURL = compania.ImagenURL
            };

            return View(companiaModel);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(CompaniaVMIndex compania)
        {
            if (ModelState.IsValid)
            {
                var companiaModel = new Compania()
                {
                    Id = compania.Id,
                    Nombre = compania.Nombre,
                    ImagenURL = compania.ImagenURL,
                    Descripcion = compania.Descripcion
                };

                await _repo.Actualizar(companiaModel);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var compania = await _repo.ObtenerPorId(id);

            var companiaModel = new CompaniaVMDetalles()
            {
                Id = compania.Id,
                Nombre = compania.Nombre,
                Descripcion = compania.Descripcion,
                ImagenURL = compania.ImagenURL,
                AgregadoEn = compania.AgregadoEn
            };

            return View(companiaModel);
        }

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
                TempData["ErrorCompania"] =
                    "Esta compañía está vinculada con un videojuego. Desvincúlela para eliminarla.";
                return RedirectToAction("Index");
            }
        }
    }
}