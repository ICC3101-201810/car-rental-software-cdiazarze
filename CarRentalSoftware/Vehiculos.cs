using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public abstract class Vehiculos
    {
        protected string tipo;
        protected float precioarriendo;

        public Vehiculos()
        {
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
        public float PrecioArriendo
        {
            get
            {
                return this.precioarriendo;
            }
            set
            {
                this.precioarriendo = value;
            }
        }
    }
}
