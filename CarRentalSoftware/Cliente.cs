using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public abstract class Cliente
    {
        string rut;
        float id;
        protected Random rand =new Random();

        public Cliente(string miRut, float miID)
        {
            rut = miRut;
             id = miID;

        }
        public string Rut
        {
            get
            {
                return this.rut;
            }
            set
            {
                this.rut = value;
            }
        }
        public float ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

    }
}
