using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public class MaquinariaPesada: Vehiculos
    {
        public MaquinariaPesada()
        {
            tipo = "MaquinariaPesada";
            precioarriendo = 1000;
        }
    }
}
