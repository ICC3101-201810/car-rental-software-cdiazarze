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

        public Registro(Cliente miCliente, Vehiculos miVehiculo, List<Accesorios> miAccesorios, DateTime miTerminoContrato, float miTotalPrecio)
        {
            cliente = miCliente;
            vehiculo = miVehiculo;
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
        internal List<Accesorios> Accesorios { get => accesorios; set => accesorios = value; }
    }
}
