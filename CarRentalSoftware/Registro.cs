using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    
    class Registro
    {
        Cliente Cliente;
        Vehiculos Vehiculo;
        List<Accesorios> Accesorios;
        DateTime Fecha;
        DateTime TerminoContrato;
        float TotalPrecio;

        public Registro(Cliente miCliente, Vehiculos miVehiculo, List<Accesorios> miAccesorios, DateTime miTerminoContrato, float miTotalPrecio)
        {
            Cliente = miCliente;
            Vehiculo = miVehiculo;
            Accesorios = miAccesorios;
            Fecha = DateTime.Now;
            TerminoContrato = miTerminoContrato;
            TotalPrecio = miTotalPrecio;
        }
        public Cliente cliente { get; }
        public Vehiculos vehiculo { get; }
        public List<Accesorios> accesorios { get; }
        public DateTime fecha { get; }
        public DateTime terminocontrato { get; }
        public float totalprecio { get; }
    }
}
