using System;
using System.ComponentModel;

namespace BiblioJuegos.ViewModels.CategoriaVM
{
    public class CategoriaVMIndex
    {
        public int Id { get; set; }
        public string ImagenURL { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
    }
}