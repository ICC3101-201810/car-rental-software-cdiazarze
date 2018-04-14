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
       protected float precioarr;
       protected List<float> precioarriendo;
       protected List<string> modelo_tipo;
        public Vehiculos(string miTipo, float miPrecioArr)
        {
            tipo = miTipo;
            precioarr = miPrecioArr;
            precioarriendo = new List<float>();
        }
        public string Tipo { get => tipo; set => tipo = value; }
        public List<float> Precioarriendo { get => precioarriendo; set => precioarriendo = value; }
        public List<string> Modelo_Tipo(){ return modelo_tipo; }
    }
}
