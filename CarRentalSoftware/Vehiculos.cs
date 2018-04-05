using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public class Vehiculos
    {
        string tipo;
        float precioarriendo;
        

        public Vehiculos(string miTipo, float miPrecioArriendo)
        {
            tipo = miTipo;
            precioarriendo = miPrecioArriendo;
        } 
        public string Tipo { get; set; }
        public float PrecioArriendo { get; set; }
    }
}
