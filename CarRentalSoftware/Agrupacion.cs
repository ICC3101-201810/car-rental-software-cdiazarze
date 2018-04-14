using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public abstract class Agrupacion: Cliente
    {
        

        public Agrupacion(string miRut, float miId, int miTipo,Random rand) : base(miRut, miId, miTipo,rand)
        {

            autorizacion.Add("Moto", true);
            autorizacion.Add("Auto", true);
            autorizacion.Add("Camioneta", true);
            autorizacion.Add("Camion", true);
            autorizacion.Add("MaquinariaPesada", true);
            autorizacion.Add("Bus", true);
            autorizacion.Add("Acuatico", true);
        }

        //public override Dictionary<string, bool> Permisoconducir() { return autorizacion; }
    }
}
