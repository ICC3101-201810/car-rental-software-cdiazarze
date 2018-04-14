using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Empresa : Agrupacion
    {
        string[] nombres = { "Arauco", "ONU", "UNICEF", "Copec", "Don Pollo", "COANIQUEM", "NACIONAL", "RebelAlliance", "EwokSA", "Corporation SA", "AS Inversions", "Panama Papers", "Ruby", "Gold Diamond", "Xerox S.A" };


        public Empresa(string miRut, float miId, int miTipo, Random rand) : base(miRut, miId, miTipo, rand)
        {
            nombre = nombres[rand.Next(0, nombres.Length)];
            edad = rand.Next(18, 80);
            autorizacion["Bus"] = (rand.NextDouble() >= 0.2);
            autorizacion["MaquinariaPesada"] = (rand.NextDouble() >= 0.37);

        }


        //public override Dictionary<string, bool> Permisoconducir() { return autorizacion; }
    }
}
