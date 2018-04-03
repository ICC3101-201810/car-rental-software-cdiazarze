using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int CapacidadSucursal;
            string NombreSucursal;
            List<Sucursal> Sucursales= new List<Sucursal>();
            int decision;
            Sucursal sucursal;
            Console.WriteLine("Inicio Programa\n");
            Console.WriteLine("Creacion de sucursal:\n Ingrese nombre de la sucursal:");
            CapacidadSucursal = Console.Read();
            Console.WriteLine("Creacion de Sucursal:\n Ingrese Nombre de sucursal:");
            NombreSucursal = Console.ReadLine();
            sucursal = new Sucursal(CapacidadSucursal, NombreSucursal);

            Sucursales.Add(sucursal);

            while (true) {
                Console.WriteLine("Sucursal creada, ahora puede decidir que realizar a continuacion:\n(1) Crear Sucursal\n" +
                    "(2) Agregar Vehiculo a Sucursal\n(3) Gestionar Arriendo\n(4) Salir");
                decision = Console.Read();

                if (decision == 1)
                {
                    Console.WriteLine("Creacion de Sucursal:\n Ingrese Nombre de sucursal:");
                    NombreSucursal = Console.ReadLine();
                    Console.WriteLine("\n Ingrese Capacidad de sucursal:");
                    CapacidadSucursal = (int)Console.Read();
                    sucursal = new Sucursal(CapacidadSucursal, NombreSucursal);
                    Sucursales.Add(sucursal);
                }

                if (decision == 4)
                {
                    break;
                }
               
            }
            Console.WriteLine(Sucursales[0].Nombre);
            Console.WriteLine(Sucursales[1].Nombre);
        }
    }
}
