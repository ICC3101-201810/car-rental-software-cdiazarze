﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Agrupacion: Cliente
    {
        string[] nombres = { "Arauco", "ONU", "UNICEF", "Copec", "Don Pollo", "COANIQUEM", "NACIONAL", "Rebel Alliance", "Todos por un Ewok", "Corporation SA", "AS Inversions", "Panama Papers", "Ruby", "Gold Diamond", "Xerox S.A" };

        Dictionary<string, bool> autorizacion = new Dictionary<string, bool>();

        public Agrupacion(string miRut, float miId, int miTipo) : base(miRut, miId, miTipo)
        {
            nombre = nombres[rand.Next(0, nombres.Length)];
            edad = rand.Next(18, 80);
            edad = rand.Next(18, 80);
            autorizacion.Add("Moto", (rand.Next() >= 0.5));
            autorizacion.Add("Auto", (rand.Next() >= 0.5));
            autorizacion.Add("Camioneta", (rand.Next() >= 0.5));
            autorizacion.Add("Camion", (rand.Next() >= 0.5));
            autorizacion.Add("MaquinariaPesada", (rand.Next() >= 0.5));
            autorizacion.Add("Bus", (rand.Next() >= 0.5));
            autorizacion.Add("Acuatico", (rand.Next() >= 0.5));
        }

        public override Dictionary<string, bool> Permisoconducir() { return autorizacion; }
    }
}
