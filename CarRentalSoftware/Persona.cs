using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Persona :Cliente
    {
        //arreglos solo para generar nombres aleatorios de personas
        string[] nombres = { "Juan", "Carlos", "Claudio", "Diego", "Sebastian", "Andrea", "Maria", "Pedro", "Javier", "Cristobal", "Catalina", "Andres", "Elisa", "Gracia", "Alejandra" };
        string[] apellidos = { "Diaz", "Soto", "Gonzalez", "Errazuriz", "Alvear", "Jordan", "Fuentes", "Queteimporta", "Bond", "Amigo", "Lloron","Silva","Correa","Guasch","Recabarren" };

        Dictionary<string, bool> licencia= new Dictionary<string, bool>();

        public Persona(string miRut, float miId, int miTipo) : base(miRut, miId,miTipo)
        {
            nombre = nombres[rand.Next(0, nombres.Length)]+" "+ apellidos[rand.Next(0, apellidos.Length)]; 
            edad = rand.Next(18, 80);
            licencia.Add("Moto", (rand.Next() >= 0.5));
            licencia.Add("Auto", (rand.Next() >= 0.5));
            licencia.Add("Camioneta", (rand.Next() >= 0.5));
            licencia.Add("Camion", (rand.Next() >= 0.5));
            licencia.Add("MaquinariaPesada", (rand.Next() >= 0.5));
            licencia.Add("Bus", (rand.Next() >= 0.5));
            licencia.Add("Acuatico", (rand.Next() >= 0.5));

        }

        public override Dictionary<string, bool> Permisoconducir() { return licencia; }
    }
}
