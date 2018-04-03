using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Sucursal
    {
        List<Vehiculos> Vehiculos= new List<Vehiculos>();
        List<Accesorios> Accesorios = new List<Accesorios>();
        int capacidad;

        public Sucursal(int miCapacidad)
        {
            capacidad = miCapacidad;
        }

        public bool AgregarVehiculos(Vehiculos vehiculo)
        {
            if (capacidad > 0)
            {
                Vehiculos.Add(vehiculo);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
