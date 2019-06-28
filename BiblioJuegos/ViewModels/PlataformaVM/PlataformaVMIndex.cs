using System.ComponentModel;

namespace BiblioJuegos.ViewModels.PlataformaVM
{
    public class PlataformaVMIndex
    {
        public int Id { get; set; }
        public string ImagenURL { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

    }
}
