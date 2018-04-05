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

        public bool ComprarVehiculo(string tipo, float precioarriendo)
        {
            foreach (float i in vehiculos.Keys)
            {
                if (vehiculos[i].Tipo.Equals(tipo)) return false;
            }
            vehiculos.Add(vehiculos.Count + 1, new Vehiculos(tipo, precioarriendo));
            Stockvehiculos.Add(vehiculos.Count, 1);
            return true;
        }

        public void ImprimirFlota()
        {
            foreach (float i in stockvehiculos.Keys)
            {
                Console.WriteLine(vehiculos[i].Tipo + ": " + stockvehiculos[i]+"\n");
            }
        }



        public Dictionary<float, int> Stockvehiculos { get => stockvehiculos; set => stockvehiculos = value; }
        public float Id { get => this.id; set => this.id = value; }
        public Dictionary<float, Vehiculos> Vehiculos { get => vehiculos; set => vehiculos = value; }
    }
}
