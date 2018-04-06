using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Agrupacion: Cliente
    {
        string[] nombres = { "Arauco", "ONU", "UNICEF", "Copec", "Don Pollo", "COANIQUEM", "NACIONAL", "Rebel Alliance", "Todos por un Ewok", "Corporation SA", "AS Inversions", "Panama Papers", "Ruby", "Gold Diamond", "Xerox S.A" };
        Dictionary<string, bool> autorizacion = new Dictionary<string, bool>();

        public Agrupacion(string miRut, float miId, int miTipo,Random rand) : base(miRut, miId, miTipo,rand)
        {
            nombre = nombres[rand.Next(0, nombres.Length)];
            edad = rand.Next(18, 80);
            autorizacion.Add("Moto", (rand.NextDouble() >= 0.5));
            autorizacion.Add("Auto", (rand.NextDouble() >= 0.5));
            autorizacion.Add("Camioneta", (rand.NextDouble() >= 0.5));
            autorizacion.Add("Camion", (rand.NextDouble() >= 0.5));
            autorizacion.Add("MaquinariaPesada", (rand.NextDouble() >= 0.5));
            autorizacion.Add("Bus", (rand.NextDouble() >= 0.5));
            autorizacion.Add("Acuatico", (rand.NextDouble() >= 0.5));
        }

        public override Dictionary<string, bool> Permisoconducir() { return autorizacion; }
    }
}
