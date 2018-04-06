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
        int tipo;
        protected int edad;
        protected string nombre;
        float id;
        protected Random rand =new Random();

       

        public Cliente(string miRut, float miId, int miTipo)
        {
            rut = miRut;
            id = miId;
            tipo = miTipo;

        }
        public abstract Dictionary<string, bool> Permisoconducir();
        public string Rut { get => rut; set => rut = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public float Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}
