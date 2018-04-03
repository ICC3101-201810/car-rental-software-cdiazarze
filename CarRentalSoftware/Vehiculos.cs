using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Vehiculos
    {
        string tipo;
        string patente;
        
        public Vehiculos(string miTipo)
        {
            tipo = miTipo;
        }
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
    }
}
