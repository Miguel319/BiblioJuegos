using System.Linq;
using System.Threading.Tasks;
using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using BiblioJuegos.ViewModels.PlataformaVM;
using Microsoft.AspNetCore.Mvc;

namespace BiblioJuegos.Controllers
{
    public class PlataformaController : Controller
    {
        private readonly IPlataformaRepo _repo;

        public PlataformaController(IPlataformaRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var plataformas = await _repo.ObtenerTodas();

            var plataformaModel = plataformas.Select(x => new PlataformaVMIndex()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenURL = x.ImagenURL
            });

            return View(plataformaModel);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(PlataformaVMIndex plataforma)
        {
            if (ModelState.IsValid)
            {
                var plataformaModel = new Plataforma()
                {
                    Nombre = plataforma.Nombre,
                    Descripcion = plataforma.Descripcion,
                    ImagenURL = plataforma.ImagenURL
                };

                await _repo.Agregar(plataformaModel);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var plataforma = await _repo.ObtenerPorId(id);

            var plataformaModel = new PlataformaVMIndex()
            {
                Id = plataforma.Id,
                Nombre = plataforma.Nombre,
                Descripcion = plataforma.Descripcion,
                ImagenURL = plataforma.ImagenURL
            };

            return View(plataformaModel);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(PlataformaVMIndex plataforma)
        {
            if (ModelState.IsValid)
            {
                var plataformaModel = new Plataforma()
                {
                    Id = plataforma.Id,
                    Nombre = plataforma.Nombre,
                    Descripcion = plataforma.Descripcion,
                    ImagenURL = plataforma.ImagenURL
                };
                await _repo.Actualizar(plataformaModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var plataforma = await _repo.ObtenerPorId(id);

            var plataformaModel = new PlataformaVMDetalles()
            {
                Id = plataforma.Id,
                Nombre = plataforma.Nombre,
                Descripcion = plataforma.Descripcion,
                ImagenURL = plataforma.ImagenURL,
                AgregadoEn = plataforma.AgregadoEn
            };

            return View(plataformaModel);
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
                TempData["ErrorPlataforma"] =
                    "Esta plataforma está vinculada con un videojuego. Desvincúlela para eliminarla.";
                return RedirectToAction("Index");
            }
        }
    }
}