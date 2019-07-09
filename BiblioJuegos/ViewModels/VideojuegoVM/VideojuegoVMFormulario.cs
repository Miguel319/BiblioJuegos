using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BiblioJuegos.BOL;

namespace BiblioJuegos.ViewModels.VideojuegoVM
{
    public class VideojuegoVMFormulario
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Titulo { get; set; }
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime Lanzamiento { get; set; }
        [DisplayName("Ruta de la imagen")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string ImagenURL { get; set; }
        public DateTime AgregadoEn { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public IEnumerable<Categoria> Categorias { get; set; }
        public int CategoriaId { get; set; }
        [DisplayName("Compañías")]
        public IEnumerable<Compania> Companias { get; set; }
        public int CompaniaId { get; set; }
        public IEnumerable<Plataforma> Plataformas { get; set; }
        public int PlataformaId { get; set; }
    }
}
