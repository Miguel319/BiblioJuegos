using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiblioJuegos.ViewModels.CategoriaVM
{
    public class CategoriaVMIndex
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DisplayName("Ruta de la imagen")]
        public string ImagenURL { get; set; }
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }
    }
}