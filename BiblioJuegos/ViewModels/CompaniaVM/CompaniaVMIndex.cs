using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiblioJuegos.ViewModels.CompaniaVM
{
    public class CompaniaVMIndex
    {
        public int Id { get; set; }
        [DisplayName("Ruta de la imagen")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string ImagenURL { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Descripcion { get; set; }
    }
}