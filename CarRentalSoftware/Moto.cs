using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Moto :Vehiculos
    {
        public Moto(string miTipo, float miPrecioArriendo, Random miRand) : base(miTipo, miPrecioArriendo, miRand) { }
    }
}
