﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWPF
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tamano { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string ImagenPath { get; set; }
    }
}
