using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Agrupacion: Cliente
    {
        Dictionary<string, bool> Autorizacion = new Dictionary<string, bool>();

        public Agrupacion(string miRut, float miID) : base(miRut, miID)
        {
            Autorizacion.Add("Moto", (rand.Next() >= 0.5));
            Autorizacion.Add("Auto", (rand.Next() >= 0.5));
            Autorizacion.Add("Camion", (rand.Next() >= 0.5));
            Autorizacion.Add("MaquinariaPesada", (rand.Next() >= 0.5));
            Autorizacion.Add("Bus", (rand.Next() >= 0.5));
            Autorizacion.Add("Acuatico", (rand.Next() >= 0.5));
        }
    }
}
