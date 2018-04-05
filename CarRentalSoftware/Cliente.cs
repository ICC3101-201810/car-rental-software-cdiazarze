using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    public abstract class Cliente
    {
        string Rut;
        float Id;
        protected Random rand =new Random();

        public Cliente(string miRut, float miID)
        {
            Rut = miRut;
             Id = miID;

        }
        public string rut { get; }
        public float id { get; }
    }
}
