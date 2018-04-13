using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public abstract class Vehiculos
    {
       protected string tipo;
       protected float precioarriendo;
       protected Random rand; 
       protected string modelo; 

        public Vehiculos(string miTipo, float miPrecioArriendo, Random miRand)
        {
            tipo = miTipo;
            precioarriendo = miPrecioArriendo;
            rand = miRand;
        }
        public string Linea() { return modelo; }
        public string Tipo { get => tipo; set => tipo = value; }
        public float Precioarriendo { get => precioarriendo; set => precioarriendo = value; }
    }
}
