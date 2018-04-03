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
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

    }

}
