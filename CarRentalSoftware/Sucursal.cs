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
        Dictionary<int,Accesorios> accesorios = new Dictionary<int, Accesorios>
        {
            {1,new Accesorios("GPS",10)},
            {2,new Accesorios("Wifi",12)},
            {3,new Accesorios("Radio Powe",8)},
            {4,new Accesorios("Rueda extra",5)},
            {5,new Accesorios("Cortinas",2)},
            {6,new Accesorios("Silla salva hermanitos",20)},
        };

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

        public bool ComprarVehiculo(string tipo, float precioarriendo, int cantidad, Random rand)
        {

            if (tipo.Equals("Auto")) vehiculos.Add(vehiculos.Count + 1, new Auto (tipo, precioarriendo,rand));
            else if (tipo.Equals("Camioneta")) vehiculos.Add(vehiculos.Count + 1, new Camioneta(tipo, precioarriendo, rand));
            else if (tipo.Equals("Camion")) vehiculos.Add(vehiculos.Count + 1, new Camion(tipo, precioarriendo, rand));
            else if (tipo.Equals("Moto")) vehiculos.Add(vehiculos.Count + 1, new Moto(tipo, precioarriendo, rand));
            else if (tipo.Equals("Acuatico")) vehiculos.Add(vehiculos.Count + 1, new Acuatico(tipo, precioarriendo, rand));
            else if (tipo.Equals("MaquinariaPesada")) vehiculos.Add(vehiculos.Count + 1, new MaquinariaPesada(tipo, precioarriendo, rand));
            else vehiculos.Add(vehiculos.Count + 1, new Bus(tipo, precioarriendo, rand));
            Stockvehiculos.Add(vehiculos.Count, cantidad);
            return true;
        }

        public void ImprimirFlota()
        {
            if (stockvehiculos.Count < 1) Console.WriteLine("Esta sucursal no posee flota");
            else
            {
                Console.WriteLine("Flota en sucursal:\n");
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
        public void RecibirVehiculo(string tipo)
        {
            foreach (float i in vehiculos.Keys)
            {
                if (vehiculos[i].Tipo.Equals(tipo))
                {
                    Stockvehiculos[i] +=1;
                }
            }
        }

        public Dictionary<float, int> Stockvehiculos { get => stockvehiculos; set => stockvehiculos = value; }
        public float Id { get => this.id; set => this.id = value; }
        public Dictionary<float, Vehiculos> Vehiculos { get => vehiculos; set => vehiculos = value; }
        public Dictionary<int, Accesorios> Accesorios { get => accesorios; set => accesorios = value; }
    }
}
