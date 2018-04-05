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
            Console.WriteLine("Sucursal Id:" + sucursales.Count + " creada.\n");
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
            if (sucursales[idSucursal].Stockvehiculos[i] < 1) return 1;
            

            sucursales[idSucursal].Stockvehiculos[i] -= 1;
            
            float totalprecio = veh.Precioarriendo;
            List<Accesorios> accesorios = new List<Accesorios>();
            registros.Add(registros.Count + 1, new Registro(cliente, veh, accesorios, termino, totalprecio));
            return 2;
        }

        public void VerStockVehiculosSucursal(float idSucursal)
        {
            foreach (float i in sucursales[idSucursal].Stockvehiculos.Keys)
            {
                Console.WriteLine(sucursales[idSucursal].Vehiculos[i].Tipo + ": " + sucursales[idSucursal].Stockvehiculos[i]);
            }
        }

        public void ImprimirSucursales()
        {
            foreach (float i in sucursales.Keys)
            {
                Console.WriteLine("(" + i + ") Sucursal " + sucursales[i].Id+"\n");
            }
        }

        public void programa()
        {
            int decision0;
            int decision2;
            Console.WriteLine("Creando sucursal inicial...");
            CrearSucursal();
            Console.WriteLine("Agregando vehiculos...");
            sucursales[1].ComprarVehiculo("Auto", 400);
            sucursales[1].AumentarFlota("Auto", 14);
            sucursales[1].ComprarVehiculo("Camioneta", 500);
            sucursales[1].AumentarFlota("Camioneta", 17);
            sucursales[1].ComprarVehiculo("Acuatico", 600);
            sucursales[1].AumentarFlota("Acuatico", 8);
            sucursales[1].ComprarVehiculo("Bus", 800);
            sucursales[1].AumentarFlota("Bus", 3);
            sucursales[1].ComprarVehiculo("MaquinariaPesada", 1000);
            sucursales[1].AumentarFlota("MaquinariaPesada", 2);
            sucursales[1].ComprarVehiculo("Moto", 300);
            sucursales[1].AumentarFlota("Moto", 13);



            Console.WriteLine("Sucursal incializada, ahora puede decidir que realizar a continuacion:\n");
            while (true)
            {
                Console.WriteLine("Menu:\n(1) Crear Nueva Sucursal\n" +"(2) Agregar Vehiculo a Sucursal\n(3) Gestionar Arriendo\n(4) Salir\n");

                decision0 = Int32.Parse(Console.ReadLine());

                if (decision0 == 1)
                {
                    CrearSucursal();
                }
                if (decision0 == 2)
                {
                    Console.WriteLine("Elegir sucursal a agregar vehiculo:\n");
                    ImprimirSucursales();
                    decision2 = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
                    if (sucursales[decision2].Vehiculos.Count < 1) Console.WriteLine("Esta sucursal aun no posee flota\n");
                    else
                    {
                        Console.WriteLine("Inventario Actual:\n");
                        sucursales[decision2].ImprimirFlota();
                    }

                }
                if (decision0 == 4)
                {
                    break;
                }

            }
            Console.WriteLine(sucursales[1].Id);
            Console.WriteLine(sucursales[2].Id);
            Console.ReadLine();
            
        }

    }
}
