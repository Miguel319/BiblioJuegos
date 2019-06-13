﻿using System;
using System.ComponentModel;

namespace BiblioJuegos.BOL
{
    public class Videojuego
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Lanzamiento")]
        public DateTime Lanzamiento { get; set; }
        public DateTime AgregadoEn { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Compania Compania { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Plataforma Plataforma { get; set; }

    }
}