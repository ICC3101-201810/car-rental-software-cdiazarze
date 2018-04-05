using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Persona :Cliente
    {
        Dictionary<string, bool> licencia= new Dictionary<string, bool>();

        public Persona (string miRut, float miID) : base(miRut, miID)
        {
            licencia.Add("Moto", (rand.Next() >= 0.5));
            licencia.Add("Auto", (rand.Next() >= 0.5));
            licencia.Add("Camion", (rand.Next() >= 0.5));
            licencia.Add("MaquinariaPesada", (rand.Next() >= 0.5));
            licencia.Add("Bus", (rand.Next() >= 0.5));
            licencia.Add("Acuatico", (rand.Next() >= 0.5));

        }
        public Dictionary<string, bool> Licencia { get; }
    }
}
