using BiblioJuegos.BOL;
using BiblioJuegos.DAL;
using BiblioJuegos.DAL.IRepo;
using BiblioJuegos.ViewModels.VideojuegoVM;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioJuegos.Controllers
{
    public class VideojuegoController : Controller
    {
        private readonly IVideojuegoRepo _videojuegoRepo;
        private readonly ICategoriaRepo _categoriaRepo;
        private readonly ICompaniaRepo _companiaRepo;
        private readonly IPlataformaRepo _plataformaRepo;

        public VideojuegoController(IVideojuegoRepo videojuegoRepo, ICategoriaRepo categoriaRepo, 
            ICompaniaRepo companiaRepo, IPlataformaRepo plataformaRepo)
        {
            _videojuegoRepo = videojuegoRepo;
            _categoriaRepo = categoriaRepo;
            _companiaRepo = companiaRepo;
            _plataformaRepo = plataformaRepo;
        }
       
        [HttpGet]
       public async Task<IActionResult> Index()
        {
            var videojuegosLista = await _videojuegoRepo.ObtenerTodos();

            var videojuegoVM =  videojuegosLista.Select(x => new VideojuegoVMIndex()
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                ImagenURL = x.ImagenURL,
                Lanzamiento = x.Lanzamiento,
                Compania = x.Compania.Nombre,
                Categoria = x.Categoria.Nombre,
                Plataforma = x.Plataforma.Nombre
            });

            return View(videojuegoVM);
        }

        [HttpGet]
        public async Task<IActionResult> Agregar()
        {
            var formulario = new VideojuegoVMFormulario()
            {
                Categorias = await _categoriaRepo.ObtenerTodas(),
                Companias = await _companiaRepo.ObtenerTodas(),
                Plataformas = await _plataformaRepo.ObtenerTodas()
            };

            return View(formulario);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(VideojuegoVMFormulario formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Categorias = await _categoriaRepo.ObtenerTodas();
                formulario.Plataformas = await _plataformaRepo.ObtenerTodas();
                formulario.Companias = await _companiaRepo.ObtenerTodas();

                var videojuego = new Videojuego()
                {
                    Titulo = formulario.Titulo,
                    Descripcion = formulario.Descripcion,
                    ImagenURL = formulario.ImagenURL,
                    Lanzamiento = formulario.Lanzamiento,
                    Categoria = formulario.Categorias.FirstOrDefault(x => x.Id == formulario.CategoriaId),
                    Compania = formulario.Companias.FirstOrDefault(x => x.Id == formulario.CompaniaId),
                    Plataforma = formulario.Plataformas.First(x => x.Id == formulario.PlataformaId)
                };

                await _videojuegoRepo.Agregar(videojuego);
                return RedirectToAction("Index");
            }

            return View(formulario);
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var videojuego = await _videojuegoRepo.ObtenerPorId(id);

            ViewBag.CategoriaSeleccionada = videojuego.Categoria.Nombre;
            ViewBag.CompaniaSeleccionada = videojuego.Compania.Nombre;
            ViewBag.PlataformaSeleccionada = videojuego.Plataforma.Nombre;

            var videojuegoAActualizar = new VideojuegoVMFormulario()
            {
                Id = videojuego.Id,
                Titulo = videojuego.Titulo,
                Descripcion = videojuego.Descripcion,
                ImagenURL = videojuego.ImagenURL,
                Lanzamiento = videojuego.Lanzamiento,
                Categorias = await _categoriaRepo.ObtenerTodas(),
                Companias = await _companiaRepo.ObtenerTodas(),
                Plataformas = await _plataformaRepo.ObtenerTodas()
            };

            return View(videojuegoAActualizar);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(VideojuegoVMFormulario formulario)
        {
            if (ModelState.IsValid)
            {
                var videojuego = new Videojuego()
                {
                    Id = formulario.Id,
                    Titulo = formulario.Titulo,
                    Descripcion = formulario.Descripcion,
                    ImagenURL = formulario.ImagenURL,
                    Lanzamiento = formulario.Lanzamiento,
                    Compania = await _companiaRepo.ObtenerPorId(formulario.CompaniaId),
                    Plataforma = await _plataformaRepo.ObtenerPorId(formulario.PlataformaId),
                    Categoria = await _categoriaRepo.ObtenerPorId(formulario.CategoriaId)
                };
                await _videojuegoRepo.Actualizar(videojuego);
                return RedirectToAction("Index");
            }

            return View(formulario);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var videojuego = await _videojuegoRepo.ObtenerPorId(id);

            var videojuegoModel = new VideojuegoVMDetalles()
            {
                Id = videojuego.Id,
                Titulo = videojuego.Titulo,
                Descripcion = videojuego.Descripcion,
                ImagenURL = videojuego.ImagenURL,
                Lanzamiento = videojuego.Lanzamiento,
                Compania = videojuego.Compania.Nombre,
                Categoria = videojuego.Categoria.Nombre,
                Plataforma = videojuego.Plataforma.Nombre
            };

            return View(videojuegoModel);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _videojuegoRepo.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorVideojuego"] = "Error al eliminar videojuego. Vuelva a intentarlo.";
                return RedirectToAction("Index");
            }
        }
    }
}