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
        public string Titulo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime Lanzamiento { get; set; }
        public string ImagenURL { get; set; }
        public DateTime AgregadoEn { get; set; }
        [DisplayName("Categorías")]
        public IEnumerable<Categoria> Categorias { get; set; }
        public int CategoriaId { get; set; }
        [DisplayName("Compañías")]
        public IEnumerable<Compania> Companias { get; set; }
        public int CompaniaId { get; set; }
        public IEnumerable<Plataforma> Plataformas { get; set; }
        public int PlataformaId { get; set; }
    }
}
