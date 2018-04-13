using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Bus:Vehiculos
    {
        string[] modelo_tipo = { "Liviano", "Normal", "Lujo" };
        public Bus(string miTipo, float miPrecioArriendo, Random miRand) : base(miTipo, miPrecioArriendo, miRand)
        {
            modelo = modelo_tipo[rand.Next(1, 4)-1];
        }
    }
}
