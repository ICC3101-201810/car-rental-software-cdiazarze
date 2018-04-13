using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class MaquinariaPesada :Vehiculos
    {
        public MaquinariaPesada(string miTipo, float miPrecioArriendo, Random miRand) : base(miTipo, miPrecioArriendo, miRand)
        {
        }
    }
}
