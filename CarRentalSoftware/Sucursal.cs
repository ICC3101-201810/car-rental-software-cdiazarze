using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Sucursal
    {
        Dictionary<float, int> stockvehiculos= new Dictionary<float, int>();
        Dictionary<float, Vehiculos> vehiculos = new Dictionary<float, Vehiculos>();
        List<Accesorios> accesorios = new List<Accesorios>();

        float id;

        public Sucursal(float miId)
        {
            id = miId;
        }


        public bool AumentarFlota(string tipo, int cantidad)
        {
            foreach (float i in vehiculos.Keys)
            {
                if (vehiculos[i].Tipo.Equals(tipo))
                {
                    stockvehiculos[i] = cantidad;
                    return true;
                }
            }
            return false;
        }

        public bool ComprarVehiculo(string tipo, float precioarriendo)
        {
            foreach (float i in vehiculos.Keys)
            {
                if (vehiculos[i].Tipo.Equals(tipo)) return false;
            }
            vehiculos.Add(vehiculos.Count + 1, new Vehiculos(tipo, precioarriendo));
            stockvehiculos.Add(vehiculos.Count, 1);
            return true;
        }

        public float Id { get; }
        public Dictionary<float,int> StockVehiculos { get; set; }
        public Dictionary<float, Vehiculos> Vehiculos { get; set; }
    }
}
