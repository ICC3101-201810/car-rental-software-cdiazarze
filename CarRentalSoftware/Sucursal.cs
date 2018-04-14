using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Sucursal
    {
        Dictionary<float, int> stockvehiculos = new Dictionary<float, int>();
        Dictionary<float, List<int>> stockvehiculos2 = new Dictionary<float, List<int>>();
        Dictionary<float, Vehiculos> vehiculos = new Dictionary<float, Vehiculos>();
        Dictionary<int, Accesorios> accesorios = new Dictionary<int, Accesorios>
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


        public bool AumentarFlota(string tipo, int cantidad, int modelo)
        {
            if (GetIndexVehicle(tipo)!=99) 
            {
                stockvehiculos2[GetIndexVehicle(tipo)][modelo - 1] += cantidad;
                return true;
            }
            return false;
        }

        public bool ComprarVehiculo(string tipo, float precioarriendo, int cantidad, int modelo)
        {
            if (!VerificarExistevehiculo(tipo))
            {
                if (tipo.Equals("Auto")) vehiculos.Add(vehiculos.Count + 1, new Auto(tipo, precioarriendo));
                else if (tipo.Equals("Camioneta")) vehiculos.Add(vehiculos.Count + 1, new Camioneta(tipo, precioarriendo));
                else if (tipo.Equals("Camion")) vehiculos.Add(vehiculos.Count + 1, new Camion(tipo, precioarriendo));
                else if (tipo.Equals("Moto")) vehiculos.Add(vehiculos.Count + 1, new Moto(tipo, precioarriendo));
                else if (tipo.Equals("Acuatico")) vehiculos.Add(vehiculos.Count + 1, new Acuatico(tipo, precioarriendo));
                else if (tipo.Equals("MaquinariaPesada")) vehiculos.Add(vehiculos.Count + 1, new MaquinariaPesada(tipo, precioarriendo));
                else vehiculos.Add(vehiculos.Count + 1, new Bus(tipo, precioarriendo));
                List<int> l = new List<int>(new int[vehiculos[vehiculos.Count].Modelo_Tipo().Count]);
                for (int i = 0; i < vehiculos[vehiculos.Count].Modelo_Tipo().Count; i++)
                {
                    if (i != modelo - 1) l[i] = 0;
                    else l[i] = cantidad;
                }
                stockvehiculos2.Add(vehiculos.Count, l);
            }
            else
            {
                Stockvehiculos2[GetIndexVehicle(tipo)][modelo - 1] += cantidad;
                vehiculos[GetIndexVehicle(tipo)].Precioarriendo[modelo-1] = precioarriendo;
            }


            return true;
        }
        public int GetIndexVehicle(string tipo)
        {
            foreach (int i in vehiculos.Keys) if (vehiculos[i].Tipo.Equals(tipo)) return i;
            return 99;
        }

        public void ImprimirFlota()
        {
            if (stockvehiculos2.Count < 1) Console.WriteLine("Esta sucursal no posee flota");
            else
            {
                Console.WriteLine("Flota en sucursal:\n");
                foreach (int i in stockvehiculos2.Keys)
                {
                    Console.Write("(" + i + ") " + vehiculos[i].Tipo + ": " + totalstockvehicle(i));
                    for (int j = 0; j < stockvehiculos2[i].Count; j++) Console.Write(" (" + vehiculos[i].Modelo_Tipo()[j] + ": " + stockvehiculos2[i][j]+")");
                    Console.Write("\n");
                }
                Console.WriteLine("\n");
            }
        }

        public void SetVehiclePrice(string tipo, int modelo, float precio)
        {
            vehiculos[GetIndexVehicle(tipo)].Precioarriendo[modelo - 1] = precio;
        }

        public int totalstockvehicle(int i)
        {
            int total = 0;
            foreach (int j in stockvehiculos2[i]) total += j;
            return total;
        }

        public void PrintVehiclesModels(string tipo)
        {
        int i = GetIndexVehicle(tipo);
        for (int j = 0; j < vehiculos[i].Modelo_Tipo().Count; j++) Console.WriteLine("(" + (j+1) + ") " + vehiculos[i].Modelo_Tipo()[j]);
        }
        public bool VerificarExistevehiculo(string tipo)
        {
            if (GetIndexVehicle(tipo)!=99) return true;
            return false;
        }
        public void RecibirVehiculo(string tipo,int modelo)
        {
            stockvehiculos2[GetIndexVehicle(tipo)][modelo-1] += 1;
        }

        public bool ExistVehicleModel(string tipo, int modelo)
        {
            int i = GetIndexVehicle(tipo);
            if (i!=99 && stockvehiculos2[i][modelo-1] > 0) return true;
            return false;
        }
        public List<string> GetVehiclesModels(string tipo)
        {
            return vehiculos[GetIndexVehicle(tipo)].Modelo_Tipo();
        }


        public Dictionary<float, int> Stockvehiculos { get => stockvehiculos; set => stockvehiculos = value; }
        public Dictionary<float, List<int>> Stockvehiculos2 { get => stockvehiculos2; set => stockvehiculos2 = value; }
        public float Id { get => this.id; set => this.id = value; }
        public Dictionary<float, Vehiculos> Vehiculos { get => vehiculos; set => vehiculos = value; }
        public Dictionary<int, Accesorios> Accesorios { get => accesorios; set => accesorios = value; }
    }
}
