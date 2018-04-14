using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Bus:Vehiculos
    {
        
        public Bus(string miTipo, float miPrecioArriendo) : base(miTipo, miPrecioArriendo)
        {
            modelo_tipo=new List<string>(new string[]{ "Liviano", "Normal", "Lujo" });
            for (int j = 0; j < modelo_tipo.Count; j++) precioarriendo.Add(precioarr);
        }
        public List<string> ModelosDisponibles() { return modelo_tipo; }
    }
}
