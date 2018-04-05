using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Compañia
    {

        Dictionary<float, Registro> registros=new Dictionary<float, Registro>();
        Dictionary<float,Cliente> clientes=new Dictionary<float, Cliente>();
        Dictionary<float, Sucursal> sucursales = new Dictionary<float, Sucursal>();


        public Compañia()
        {
        }

        public void CrearSucursal()
        {
            if (!sucursales.ContainsKey(1)) sucursales.Add(1, new Sucursal(1));
            else sucursales.Add(sucursales.Count + 1, new Sucursal(sucursales.Count + 1));
            Console.WriteLine("Sucursal Id:" + sucursales.Count + " creada.");
        }
        public int ArrendarVehiculo(float idSucursal, string tipo, Cliente cliente, DateTime termino) 
        {
            int i;
            Vehiculos veh;
            for (i = 0; i < sucursales[idSucursal].Vehiculos.Count; i++)
            {
                if (sucursales[idSucursal].Vehiculos[i].Tipo.Equals(tipo)) break;
            }
            veh = sucursales[idSucursal].Vehiculos[i];
            if (!sucursales.ContainsKey(idSucursal)) return 0;
            if (sucursales[idSucursal].StockVehiculos[i] < 1) return 1;
            

            sucursales[idSucursal].StockVehiculos[i] -= 1;
            
            float totalprecio = veh.PrecioArriendo;
            List<Accesorios> accesorios = new List<Accesorios>();
            registros.Add(registros.Count + 1, new Registro(cliente, veh, accesorios, termino, totalprecio));
            return 2;
        }

        public void VerStockVehiculosSucursal(float idSucursal)
        {
            foreach (float i in sucursales[idSucursal].StockVehiculos.Keys)
            {
                Console.WriteLine(sucursales[idSucursal].Vehiculos[i].Tipo + ": " + sucursales[idSucursal].StockVehiculos[i]);
            }
        }

        public void programa()
        {
            int decision;
            CrearSucursal();

            //Console.WriteLine("Sucursal creada, ahora puede decidir que realizar a continuacion:\n(1) Crear Sucursal\n" +
               // "(2) Agregar Vehiculo a Sucursal\n(3) Gestionar Arriendo\n(4) Salir");
/*
            while (true)
            {
                decision = Int32.Parse(Console.ReadLine());

                if (decision == 1)
                {
                    Console.WriteLine("Creacion de Sucursal:\n Ingrese Nombre de sucursal:");
                    NombreSucursal = Console.ReadLine();
                    Console.WriteLine("\n Ingrese Capacidad de sucursal:");
                    CapacidadSucursal = Int32.Parse(Console.ReadLine());
                    sucursal = new Sucursal( NombreSucursal);
                    Sucursales.Add(sucursal);
                }

                if (decision == 4)
                {
                    break;
                }

            }*/
            Console.WriteLine(sucursales[1].Id);
            Console.ReadLine();
            
        }

    }
}
