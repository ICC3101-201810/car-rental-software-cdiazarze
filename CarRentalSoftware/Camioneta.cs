﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Camioneta :Vehiculos
    {
        public Camioneta(string miTipo, float miPrecioArriendo, Random miRand) : base(miTipo, miPrecioArriendo, miRand) { }
    }
}
