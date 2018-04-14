using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Camioneta :Vehiculos
    {
        public Camioneta(string miTipo, float miPrecioArriendo) : base(miTipo, miPrecioArriendo) {
            modelo_tipo = new List<string>(new string[] { "Unico" });
            for (int j = 0; j < modelo_tipo.Count; j++) precioarriendo.Add(precioarr);
        }
    }
}
