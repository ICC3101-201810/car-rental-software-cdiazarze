using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Compañia
    {

        Dictionary<float, Registro> registros = new Dictionary<float, Registro>();
        Dictionary<float, Cliente> clientes = new Dictionary<float, Cliente>();
        Dictionary<float, Sucursal> sucursales = new Dictionary<float, Sucursal>();
        Dictionary<float, string> vehiculossucursales=new Dictionary<float,string>(); 
        

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
            int decision0=0;
            int decision2=0;
            int id = 0;
            string tipo;
            int cantidad=0;
            float precioarriendo=0;

            Console.WriteLine("Creando sucursal inicial...");
            CrearSucursal();
            Console.WriteLine("Agregando vehiculos...");
            sucursales[1].ComprarVehiculo("Auto", 400,15);
            vehiculossucursales.Add(1, "Auto");
            sucursales[1].ComprarVehiculo("Camioneta", 500,18);
            vehiculossucursales.Add(2, "Camioneta");
            sucursales[1].ComprarVehiculo("Acuatico", 600,9);
            vehiculossucursales.Add(3, "Acuatico");
            sucursales[1].ComprarVehiculo("Bus", 800,4);
            vehiculossucursales.Add(4, "Bus");
            sucursales[1].ComprarVehiculo("Retro", 1000,3);
            vehiculossucursales.Add(5, "Retro");
            sucursales[1].ComprarVehiculo("Moto", 300,14);
            vehiculossucursales.Add(6, "Moto");



            Console.WriteLine("Sucursal incializada, ahora puede decidir que realizar a continuacion:\n");
            while (true)
            {
                Console.WriteLine("Menu:\n(1) Crear Nueva Sucursal\n(2) Ver flota de sucursal\n"+
                    "(3) Agregar nuevo vehiculo a sucursal\n" +"(4) Incrementar flota actual de sucursal\n" +
                    "(5) Gestionar Arriendo\n(6) Salir\n");

                decision0=VerifyInt(decision0);

                if (decision0 == 1)
                {
                    CrearSucursal();
                }
                else if (decision0 == 2)
                {
                    Console.WriteLine("Elegir sucursal a revisar flota:\n");
                    ImprimirSucursales();
                    decision2 = VerifyInt(decision2);
                    Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
                    sucursales[decision2].ImprimirFlota();
                }
                else if (decision0 == 3)
                {
                    Console.WriteLine("Elegir sucursal a agregar nuevo vehiculo:\n");
                    ImprimirSucursales();

                    decision2 = VerifyInt(decision2);

                    Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
                    Console.WriteLine("Flota actual en sucursal:\n");
                    sucursales[decision2].ImprimirFlota();
                    Console.WriteLine("Ingrese Tipo: ");
                    tipo = Console.ReadLine();
                    if (sucursales[decision2].VerificarExistevehiculo(tipo)) Console.WriteLine("Vehiculo ya existe en la flota. Debe seleccionar Incrementar Flota Actual");
                    else
                    { 
                        if(!vehiculossucursales.ContainsValue(tipo)) vehiculossucursales.Add(vehiculossucursales.Count + 1, tipo);
                        Console.WriteLine("Ingrese Precio de arriendo: ");
                        precioarriendo = Verifyfloat(precioarriendo);
                        Console.WriteLine("Ingrese Cantidad comprada: ");
                        cantidad = VerifyInt(cantidad);
                        sucursales[decision2].ComprarVehiculo(tipo, precioarriendo,cantidad);
                    }
                }
                else if (decision0 == 4)
                {
                    Console.WriteLine("Elegir sucursal a incrementar flota:\n");
                    ImprimirSucursales();
                    decision2 = VerifyInt(decision2);
                    Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
                    if (sucursales[decision2].Vehiculos.Count < 1) Console.WriteLine("Esta sucursal aun no posee flota\n");
                    else
                    {
                        Console.WriteLine("Inventario Actual:\n");
                        sucursales[decision2].ImprimirFlota();
                        Console.WriteLine("Ingrese (id) Tipo: ");
                        id = VerifyInt(id);
                        tipo = sucursales[decision2].Vehiculos[id].Tipo;
                        Console.WriteLine("Ingrese Cantidad comprada: ");
                        cantidad = VerifyInt(cantidad);
                        sucursales[decision2].AumentarFlota(tipo, cantidad);
                        Console.WriteLine("Nuevo Inventario:\n");
                        sucursales[decision2].ImprimirFlota();
                    }
                }
                else break;
                

            }
            
        }
        public int VerifyInt(int numberout)
        {
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out numberout)) Console.WriteLine("Formato erroneo, ingrese nuevamente:");
                else break;
            }
            return numberout;
        }
        public float Verifyfloat(float numberout)
        {
            while (true)
            {
                if (!float.TryParse(Console.ReadLine(), out numberout)) Console.WriteLine("Formato erroneo, ingrese nuevamente:");
                else break;
            }
            return numberout;
        }
    }
}
