using System;

namespace BiblioJuegos.BOL
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombeUsuario { get; set; }
        public string ImagenURL { get; set; }
        public string Contra { get; set; }
        public DateTime AgregadoEn { get; set; }

        public Usuario() => AgregadoEn = DateTime.Now;
    }
}
