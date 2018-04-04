using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Persona :Cliente
    {
        Dictionary<string, bool> Licencia= new Dictionary<string, bool>();

        public Persona (string miRut, float miID) : base(miRut, miID)
        {
            Licencia.Add("Moto", (rand.Next() >= 0.5));
            Licencia.Add("Auto", (rand.Next() >= 0.5));
            Licencia.Add("Camion", (rand.Next() >= 0.5));
            Licencia.Add("MaquinariaPesada", (rand.Next() >= 0.5));
            Licencia.Add("Bus", (rand.Next() >= 0.5));
            Licencia.Add("Acuatico", (rand.Next() >= 0.5));

        }
    }
}
