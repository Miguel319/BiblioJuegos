using System;
using System.ComponentModel;

namespace BiblioJuegos.BOL
{
    public class Videojuego
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string ImagenURL{ get; set; }
        public DateTime AgregadoEn { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Compania Compania { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Plataforma Plataforma { get; set; }


        public Videojuego() => AgregadoEn = DateTime.Now;

    }
}
