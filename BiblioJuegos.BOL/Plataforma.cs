﻿using System;

namespace BiblioJuegos.BOL
{
    public class Plataforma
    {
        public int Id { get; set; }
        public string ImagenURL { get; set; }
        public DateTime AgregadoEn { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}