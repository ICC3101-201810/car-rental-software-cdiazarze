using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    
    class Registro
    {
        Cliente cliente;
        Vehiculos vehiculo;
        List<Accesorios> accesorios;
        DateTime fecha;
        DateTime terminocontrato;
        float totalprecio;
        Sucursal sucursal;
        string fallo="Arrendado";

        public Registro(Cliente miCliente, Vehiculos miVehiculo, Sucursal miSucursal, List<Accesorios> miAccesorios, DateTime miTerminoContrato, float miTotalPrecio)
        {
            cliente = miCliente;
            vehiculo = miVehiculo;
            sucursal = miSucursal;
            accesorios = miAccesorios;
            fecha = DateTime.Now;
            terminocontrato = miTerminoContrato;
            totalprecio = miTotalPrecio;
        }


        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Vehiculos Vehiculo { get => vehiculo; set => vehiculo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Terminocontrato { get => terminocontrato; set => terminocontrato = value; }
        public float Totalprecio { get => totalprecio; set => totalprecio = value; }
        public string Fallo { get => fallo; set => fallo= value; }
        public List<Accesorios> Accesorios { get => accesorios; set => accesorios = value; }

        public void ImprimirRegistro()
        {
            Console.WriteLine("Cliente: " + cliente.Nombre);
            Console.WriteLine("Vehiculo: " + vehiculo.Tipo);
            Console.WriteLine("Sucursal: " + sucursal.Id);
            Console.Write("Accesorios: ");
            foreach (Accesorios acc in accesorios) Console.Write(acc.Nombre + ",");
            Console.WriteLine("\nInicio: " + fecha);
            Console.WriteLine("Termino: " + terminocontrato);
            Console.WriteLine("Total servicio: " + totalprecio+"\n");
        }
        public void ImprimirRegistroenlinea()
        {
            string acce="";
            foreach (Accesorios acc in accesorios) acce=acce+acc.Nombre + ",";
            Console.WriteLine($"{cliente.Nombre,-30}{"|",1}{vehiculo.Tipo,-25}{"|",1}{acce,-30}{"|",1}{fecha,-20}{"|",1}{terminocontrato,-20}{"|",1}{totalprecio,-6}{"|",1}{fallo,-15}");
        }

    }
}
