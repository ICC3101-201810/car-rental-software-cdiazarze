using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Sucursal
    {
        List<Vehiculos> Vehiculos= new List<Vehiculos>();
        List<Accesorios> Accesorios = new List<Accesorios>();
        List<Cliente> Clientes = new List<Cliente>();
        List<Registro> Registros = new List<Registro>();

        int capacidad;
        string nombre; 

        public Sucursal(int miCapacidad, string miNombre)
        {
            capacidad = miCapacidad;
            nombre = miNombre;
        }

        public bool AgregarVehiculos(Vehiculos vehiculo)
        {
            if (capacidad > 0)
            {
                Vehiculos.Add(vehiculo);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public int Capacidad
        {
            get
            {
                return this.capacidad;
            }
            set
            {
                this.capacidad = value;
            }
        }
    }
}
