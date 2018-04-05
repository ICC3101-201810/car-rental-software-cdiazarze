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
        public string Rut { get => rut; set => rut = value; }
        public float Id { get => id; set => id = value; }
    }
}
