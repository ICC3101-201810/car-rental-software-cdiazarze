using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Vehiculos
    {
        string tipo;
        string patente;
        float precioarriendo;
        
        public Vehiculos(string miTipo, float miPrecioArriendo)
        {
            tipo = miTipo;
            precioarriendo = miPrecioArriendo;
        }
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
    }
}
