using System;
using System.ComponentModel;

namespace BiblioJuegos.ViewModels.CompaniaVM
{
    public class CompaniaVMDetalles
    {
        public int Id { get; set; }
        public string ImagenURL { get; set; }
        public DateTime AgregadoEn { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
    }
}