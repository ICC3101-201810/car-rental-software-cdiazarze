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
        string[] nombres = { "Juan", "Carlos", "Claudio", "Diego", "Matias", "Andrea", "Maria", "Pedro", "Javier", "Julio", "Alexis", "Andres", "Elisa", "Gracia", "Sofia" };
        string[] apellidos = { "Diaz", "Soto", "Vazquez", "Silva", "Alvear", "Jordan", "Fuentes", "Mismo", "Bond", "Amigo", "Lloron","Sanchez","Correa","Guasch","Recabarren" };
        //Dictionary<string, bool> licencia= new Dictionary<string, bool>();

        public Persona(string miRut, float miId, int miTipo, Random rand) : base(miRut, miId,miTipo, rand)
        {

            nombre = nombres[rand.Next(0, nombres.Length)]+" "+ apellidos[rand.Next(0, apellidos.Length)]; 
            edad = rand.Next(18, 80);
            licencia["MaquinariaPesada"]= false;
            licencia["Bus"] = false;

        }

        //public override Dictionary<string, bool> Permisoconducir() { return licencia; }
        
    }
}
