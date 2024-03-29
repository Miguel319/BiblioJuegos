﻿using System;
using System.ComponentModel;
using BiblioJuegos.BOL;

namespace BiblioJuegos.ViewModels.VideojuegoVM
{
    public class VideojuegoVMDetalles
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public DateTime Lanzamiento { get; set; }
        [DisplayName("Ruta de la imagen")]
        public string ImagenURL { get; set; }
        public DateTime AgregadoEn { get; set; }
        [DisplayName("Categoría")]
        public string Categoria { get; set; }
        [DisplayName("Compañía")]
        public string Compania { get; set; }
        public string Plataforma { get; set; }
    }
}