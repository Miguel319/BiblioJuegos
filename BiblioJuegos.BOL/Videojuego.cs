using System;
using System.ComponentModel;

namespace BiblioJuegos.BOL
{
    public class Videojuego
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string ImagenURL{ get; set; }
        public DateTime AgregadoEn { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Compania Compania { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Plataforma Plataforma { get; set; }

    }
}
