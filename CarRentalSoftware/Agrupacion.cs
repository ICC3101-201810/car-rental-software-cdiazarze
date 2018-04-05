using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Agrupacion: Cliente
    {
        Dictionary<string, bool> autorizacion = new Dictionary<string, bool>();

        public Agrupacion(string miRut, float miID) : base(miRut, miID)
        {
            autorizacion.Add("Moto", (rand.Next() >= 0.5));
            autorizacion.Add("Auto", (rand.Next() >= 0.5));
            autorizacion.Add("Camion", (rand.Next() >= 0.5));
            autorizacion.Add("MaquinariaPesada", (rand.Next() >= 0.5));
            autorizacion.Add("Bus", (rand.Next() >= 0.5));
            autorizacion.Add("Acuatico", (rand.Next() >= 0.5));
        }
        public Dictionary<string, bool> Autorizacion { get; }
    }
}
