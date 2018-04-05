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
                    Stockvehiculos[i] = Stockvehiculos[i]+ cantidad;
                    return true;
                }
            }
            return false;
        }

        public bool ComprarVehiculo(string tipo, float precioarriendo, int cantidad)
        {
            vehiculos.Add(vehiculos.Count + 1, new Vehiculos(tipo, precioarriendo));
            Stockvehiculos.Add(vehiculos.Count, cantidad);
            return true;
        }

        public void ImprimirFlota()
        {
            if (stockvehiculos.Count < 1) Console.WriteLine("Esta sucursal no posee flota");
            else
            {
                foreach (float i in stockvehiculos.Keys)
                {
                    Console.WriteLine("("+i+") "+vehiculos[i].Tipo + ": " + stockvehiculos[i]);
                }
                Console.WriteLine("\n");
            }
        }
        public bool VerificarExistevehiculo(string tipo)
        {
            foreach (float i in vehiculos.Keys) if (vehiculos[i].Tipo.Equals(tipo)) return true;
            return false;
        }


        public Dictionary<float, int> Stockvehiculos { get => stockvehiculos; set => stockvehiculos = value; }
        public float Id { get => this.id; set => this.id = value; }
        public Dictionary<float, Vehiculos> Vehiculos { get => vehiculos; set => vehiculos = value; }
    }
}
