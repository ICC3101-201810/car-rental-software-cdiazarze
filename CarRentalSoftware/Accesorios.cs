using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Accesorios
    {
        string nombre;
        float precio;
       
        public Accesorios(string miNombre, float miPrecio)
        {
            nombre = miNombre;
            precio = miPrecio;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
    }

}
