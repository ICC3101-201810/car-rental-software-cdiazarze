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
        Random rand;
        protected Dictionary<string, bool> licencia = new Dictionary<string, bool>();
        protected Dictionary<string, bool> autorizacion = new Dictionary<string, bool>();

        public Cliente(string miRut, float miId, int miTipo, Random miRand)
        {
            rut = miRut;
            id = miId;
            tipo = miTipo;
            rand = miRand;
            licencia.Add("Moto", (rand.NextDouble() >= 0.2));
            licencia.Add("Auto", (rand.NextDouble() >= 0.1));
            licencia.Add("Camioneta", (rand.NextDouble() >= 0.1));
            licencia.Add("Camion", (rand.NextDouble() >= 0.3));
            licencia.Add("MaquinariaPesada", (rand.NextDouble() >= 0.5));
            licencia.Add("Bus", (rand.NextDouble() >= 0.3));
            licencia.Add("Acuatico", (rand.NextDouble() >= 0.2));

        }
        public Dictionary<string, bool> Permisoconducir() { return licencia; }
        public Dictionary<string, bool> Autorizaciones() { return autorizacion; }
        public string Rut { get => rut; set => rut = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public float Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}
