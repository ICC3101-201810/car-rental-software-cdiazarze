using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSoftware
{
    class Compañia
    {
        
        Random random = new Random();
        Dictionary<float, Registro> registros = new Dictionary<float, Registro>();
        Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();
        Dictionary<float, Sucursal> sucursales = new Dictionary<float, Sucursal>();
        Dictionary<float, Registro> ArriendoNoLogrado = new Dictionary<float, Registro>();
        Dictionary<float, string> vehiculossucursales = new Dictionary<float, string>
        
        {
            {1,"Auto"},
            {2,"Moto"},
            {3,"Camioneta"},
            {4,"Camion"},
            {5,"MaquinariaPesada"},
            {6,"Bus"},
            {7,"Acuatico"},
        }; 
        

        public Compañia()
        {
        }


        //Metodos para gestionar sucursales
        public void CrearSucursal()
        {
            if (!sucursales.ContainsKey(1)) sucursales.Add(1, new Sucursal(1));
            else
            {
                sucursales.Add(sucursales.Count + 1, new Sucursal(sucursales.Count + 1));
                sucursales[sucursales.Count].Vehiculos = sucursales[sucursales.Count - 1].Vehiculos;
                sucursales[sucursales.Count].Stockvehiculos2= sucursales[sucursales.Count - 1].Stockvehiculos2;
                for (int i=1; i<= sucursales[sucursales.Count].Stockvehiculos2.Count; i++)
                {
                    for (int j = 0; j < sucursales[sucursales.Count].Stockvehiculos2[i].Count; j++) sucursales[sucursales.Count].Stockvehiculos2[i][j] = 0;
                }
            }
            Console.WriteLine("Sucursal Id:" + sucursales.Count + " creada.\n");
        }
        public int ElegirSucursal(int decision2)
        {
            ImprimirSucursales();
            decision2 = VerifyInt(decision2);
            if (decision2<=sucursales.Count) Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
            return decision2;
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
            Console.WriteLine("(" + (sucursales.Count+1) + ") Volver al menu\n");
        }


        // Metodos para gestionar arriendos de vehiculos

        public int ArrendarVehiculo(string rut, int tipocliente, int eleccionsucursal, int decvehiculo, List<Accesorios> acc, DateTime termino, int modelo)
        {

            Cliente cliente;
            float sumatotal = 0;
            bool existe = false;
            if (clientes.ContainsKey(rut))
            {
                cliente = clientes[rut];
                existe = true;
            }
            else
            {
                if (tipocliente == 1) cliente = new Persona(rut, clientes.Count + 1, 1,random);
                else if (tipocliente == 2) cliente = new Empresa(rut, clientes.Count + 1, 2,random);
                else if (tipocliente == 3) cliente = new Institucion(rut, clientes.Count + 1, 2, random);
                else  cliente = new Organizacion(rut, clientes.Count + 1, 2, random);
            }
            sumatotal += sucursales[eleccionsucursal].Vehiculos[decvehiculo].Precioarriendo[modelo-1];
            foreach (Accesorios accesorio in acc) sumatotal += accesorio.Precio;

            if (sucursales[eleccionsucursal].Stockvehiculos2[decvehiculo][modelo-1] < 1)
            {
                ArriendoNoLogrado.Add(ArriendoNoLogrado.Count + 1, new Registro(cliente, sucursales[eleccionsucursal].Vehiculos[decvehiculo], sucursales[eleccionsucursal], acc, termino, sumatotal, modelo));
                ArriendoNoLogrado[ArriendoNoLogrado.Count].Fallo = "No arrendado => No hay Stock";
                return 1;
            }
           
            if (!cliente.Permisoconducir()[sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo])
            { 
                ArriendoNoLogrado.Add(ArriendoNoLogrado.Count + 1, new Registro(cliente, sucursales[eleccionsucursal].Vehiculos[decvehiculo], sucursales[eleccionsucursal], acc, termino, sumatotal, modelo));
                ArriendoNoLogrado[ArriendoNoLogrado.Count].Fallo = "No arrendado => Licencia";
                return 2;
            }
            if(cliente.Tipo!=1 && !cliente.Autorizaciones()[sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo])
            {
                ArriendoNoLogrado.Add(ArriendoNoLogrado.Count + 1, new Registro(cliente, sucursales[eleccionsucursal].Vehiculos[decvehiculo], sucursales[eleccionsucursal], acc, termino, sumatotal, modelo));
                ArriendoNoLogrado[ArriendoNoLogrado.Count].Fallo = "No arrendado => Autorizacion";
                return 3;
            }


        //Se realiza arriendo
        sucursales[eleccionsucursal].Stockvehiculos2[decvehiculo][modelo-1] -= 1;
            registros.Add(registros.Count+1,new Registro(cliente, sucursales[eleccionsucursal].Vehiculos[decvehiculo],sucursales[eleccionsucursal], acc, termino,sumatotal, modelo));
            if (!existe) clientes.Add(rut, cliente);
            return 0;
        }

        public Dictionary<string,List<bool>> PoliticasDeArriendo(int tipocliente) //Restricciones de arriendo
        {
            Dictionary<string, List<bool>> dic = new Dictionary<string, List<bool>>();
            if (tipocliente==4){
                dic.Add("Bus", new List<bool>(new bool[] { false, true, false }));
                return dic;
            }
            return dic;
        }

        public List<float> ArriendosdeCliente(Cliente cliente)
        {
            List<float> Numerosderegistro = new List<float>();
            foreach (float idreg in registros.Keys)
            {
                if (registros[idreg].Cliente == cliente) Numerosderegistro.Add(idreg);
            }
            return Numerosderegistro;
        }

        public void ImprimirRegistroArriendoCliente(string rut)
        {
            Console.WriteLine("Registros de arriendo del cliente:\n");
            foreach (float idreg in ArriendosdeCliente(clientes[rut]))
            {
                Console.WriteLine("Registro: "+idreg);
                registros[idreg].ImprimirRegistro();
            }
            Console.WriteLine("Total: " + ArriendosdeCliente(clientes[rut]).Count);
        }
        public void ImprimirLicenciasCliente(string rut)
        {
            Console.WriteLine("Licencias Aceptadas: {");
            foreach (string lic in clientes[rut].Permisoconducir().Keys) if (clientes[rut].Permisoconducir()[lic]) Console.Write(lic + ",");
            Console.Write("}\n");
        }
        //Este manda
        public void ImprimirDatosClienteAntiguo(string rut)
        {
            Console.WriteLine("Cliente con datos en sistema (arrendo previamente):\nN° Cliente: " + clientes[rut].Id +
                "\nRut: " + rut + "\nNombre: " + clientes[rut].Nombre +"\nEdad: " + clientes[rut].Edad);
            ImprimirLicenciasCliente(rut);
            ImprimirRegistroArriendoCliente(rut);
        }



        public void programa()
        {
            string guion12 = "------------";
            string guion10 = "----------";
            string guion15 = "---------------";
            string guion20 = "--------------------";
            string guion30 = "------------------------------";
            string guion40 = "----------------------------------------";
            int decision0=0;
            int decision2=0;
            int id = 0;
            string tipo;
            int cantidad=0;
            float precioarriendo=0;
            string rut;
            int tipocliente=0;
            int eleccionsucursal=0;
            int decvehiculo = 0;
            int decacce = 0;
            int resultadoarrendar;
            int modelo = 100;
            float precio = 0;
            DateTime termino;
            

            //Console.WriteLine("Creando sucursal inicial...");
            CrearSucursal();
            //Console.WriteLine("Agregando vehiculos...");
            sucursales[1].ComprarVehiculo("Auto", 400,15,1);
            sucursales[1].ComprarVehiculo("Camioneta", 500,18,1);
            sucursales[1].ComprarVehiculo("Acuatico", 600,9, 1);
            sucursales[1].ComprarVehiculo("Bus", 800,4, 2);
            sucursales[1].ComprarVehiculo("MaquinariaPesada", 1000,3, 1);
            sucursales[1].ComprarVehiculo("Moto", 300,14, 1);
            sucursales[1].ComprarVehiculo("Camion", 900, 0, 1);



            //Console.WriteLine("Sucursal incializada, ahora puede decidir que realizar a continuacion:\n");
            Console.WriteLine($"{"  ",-3}{"Bienvenido a la CarRentalSoftware 1.0",-30}");
            Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
            while (true)
            {
               
                //Console.WriteLine($"{"Cliente",-30}{"|",1}{"Vehiculo",-30}{"|",1}{"Accesorios",-25}{"|",1}{"Inicio",-20}{"|",1}{"Termino",-20}{"|",1}{"Total",-6}{"|",1}{"Fallo",-15}");

                Console.WriteLine($"{"  ",-3}{"Menu: Ingrese opcion que desea realizar",-30}");
                Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");

                Console.WriteLine($"{" ",-5}(1) Crear Nueva Sucursal\n{" ",-5}(2) Ver flota de sucursal\n"+
                    $"{" ",-5}(3) Agregar nuevo vehiculo a sucursal\n" + $"{" ",-5}(4) Incrementar flota actual de sucursal\n" +
                    $"{" ",-5}(5) Actualizar precio vehiculo\n{" ",-5}(6) Gestionar Arriendo\n{" ",-5}(7) Devolver Vehiculo\n{" ",-5}(8) Salir\n");

                decision0=VerifyInt(decision0);

                if (decision0 == 1)
                {
                    CrearSucursal();
                }
                else if (decision0 == 2)
                {
                    Console.WriteLine($"{"  ",-3}{"Menu: Revisar flota",-30}");
                    Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
                    Console.WriteLine("Elegir sucursal a revisar flota:\n");
                    decision2 = ElegirSucursal(decision2);
                    if (decision2 <= sucursales.Count) sucursales[decision2].ImprimirFlota();
                }
                else if (decision0 == 3)
                {
                    Console.WriteLine($"{"  ",-3}{"Menu: Agregar Vehiculo",-30}");
                    Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
                    Console.WriteLine("Elegir sucursal a agregar nuevo vehiculo:\n");
                    decision2 = ElegirSucursal(decision2);
                    if (decision2 <= sucursales.Count)
                    {
                        sucursales[decision2].ImprimirFlota();
                        Console.WriteLine("Tipos posibles de vehiculos para agregar: \n");
                        foreach (float i in vehiculossucursales.Keys) Console.WriteLine("(" + i + ") " + vehiculossucursales[i]);
                        Console.WriteLine("Ingrese (id) Tipo que quiere agregar: ");
                        id = VerifyInt(id);
                        if (sucursales[decision2].VerificarExistevehiculo(vehiculossucursales[id]))
                        {
                            Console.WriteLine("Ingrese (id) modelo de " + vehiculossucursales[id] + " que quiere agregar: ");
                            sucursales[decision2].PrintVehiclesModels(vehiculossucursales[id]);
                            modelo = VerifyInt(modelo);
                            if (sucursales[decision2].ExistVehicleModel(vehiculossucursales[id], modelo)) Console.WriteLine("\n  ERROR:Vehiculo ya existe en la flota. Debe seleccionar Incrementar Flota Actual\n");
                            else
                            {
                                Console.WriteLine("Ingrese Precio de arriendo: ");
                                precioarriendo = Verifyfloat(precioarriendo);
                                Console.WriteLine("Ingrese Cantidad comprada: ");
                                cantidad = VerifyInt(cantidad);
                                sucursales[decision2].ComprarVehiculo(vehiculossucursales[id], precioarriendo, cantidad, modelo);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese (id) modelo de " + vehiculossucursales[id] + "que quiere agregar: ");
                            sucursales[decision2].PrintVehiclesModels(vehiculossucursales[id]);
                            modelo = VerifyInt(modelo);
                            Console.WriteLine("Ingrese Precio de arriendo: ");
                            precioarriendo = Verifyfloat(precioarriendo);
                            Console.WriteLine("Ingrese Cantidad comprada: ");
                            cantidad = VerifyInt(cantidad);
                            sucursales[decision2].ComprarVehiculo(vehiculossucursales[id], precioarriendo, cantidad, modelo);
                        }
                    }
                }
                else if (decision0 == 4)
                {
                    Console.WriteLine($"{"  ",-3}{"Menu: Incrementar flota de Sucursal",-30}");
                    Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
                    Console.WriteLine("Elegir sucursal a incrementar flota:\n");
                    ImprimirSucursales();
                    decision2 = VerifyInt(decision2);
                    if (decision2 <= sucursales.Count) { 
                        Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
                        if (sucursales[decision2].Vehiculos.Count < 1) Console.WriteLine("Esta sucursal aun no posee flota\n");
                        else
                        {
                            sucursales[decision2].ImprimirFlota();
                            Console.WriteLine("Ingrese (id) Tipo: ");
                            id = VerifyInt(id);
                            tipo = sucursales[decision2].Vehiculos[id].Tipo;
                            Console.WriteLine("Ingrese (id) modelo de " + tipo + "que quiere agregar: ");
                            sucursales[decision2].PrintVehiclesModels(tipo);
                            modelo = VerifyInt(modelo);
                            Console.WriteLine("Ingrese Cantidad comprada: ");
                            cantidad = VerifyInt(cantidad);
                            sucursales[decision2].AumentarFlota(tipo, cantidad, modelo);
                            Console.WriteLine("Nuevo Inventario:\n");
                            sucursales[decision2].ImprimirFlota();
                        }
                    }
                }
                else if (decision0 == 5)
                {
                    Console.WriteLine($"{"  ",-3}{"Menu: Actualizar precios de arriendo",-30}");
                    Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
                    Console.WriteLine("Elegir sucursal a actualizar precios:\n");
                    ImprimirSucursales();
                    decision2 = VerifyInt(decision2);
                    if (decision2 <= sucursales.Count)
                    {
                        Console.WriteLine("Sucursal " + sucursales[decision2].Id + ":\n");
                        if (sucursales[decision2].Vehiculos.Count < 1) Console.WriteLine("Esta sucursal aun no posee flota\n");
                        else
                        {
                            sucursales[decision2].ImprimirFlota();
                            Console.WriteLine("Ingrese (id) Tipo: ");
                            id = VerifyInt(id);
                            tipo = sucursales[decision2].Vehiculos[id].Tipo;
                            Console.WriteLine("Ingrese (id) modelo de " + tipo + " que quiere actulizar precio: ");
                            sucursales[decision2].PrintVehiclesModels(tipo);
                            modelo = VerifyInt(modelo);
                            Console.WriteLine("Precio Actual de " + tipo + " (" + sucursales[decision2].Vehiculos[id].Modelo_Tipo()[modelo - 1] + "): " + sucursales[decision2].Vehiculos[id].Precioarriendo[modelo - 1]);
                            Console.WriteLine("Ingrese Nuevo Precio: ");
                            precio = Verifyfloat(precio);
                            sucursales[decision2].SetVehiclePrice(tipo, modelo, precio);

                        }
                    }
                }
                else if (decision0 == 6)
                {
                    Console.WriteLine($"{"  ",-3}{"Menu: Gestion de Arriendo",-30}");
                    Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
                    List<Accesorios> acc = new List<Accesorios>();
                    Console.WriteLine("Ingrese rut de cliente\n");
                    rut = Console.ReadLine();
                    if (clientes.ContainsKey(rut))
                    {
                        tipocliente = clientes[rut].Tipo;
                        ImprimirDatosClienteAntiguo(rut);
                    }
                    else
                    {
                        Console.WriteLine("\nCliente no existe en sistema. Es Persona Natural o representa Agrupacion:\n (1) Persona Natural\n (2) Empresa\n (3) Institucion\n (4) Organizacion\n");
                        tipocliente = VerifyInt(tipocliente);
                    }
                    Console.WriteLine("Ingrese sucursal donde arrendar vehiculo:\n");
                    eleccionsucursal = ElegirSucursal(eleccionsucursal);
                    if (eleccionsucursal <= sucursales.Count)
                    {
                        sucursales[eleccionsucursal].ImprimirFlota();
                        Console.WriteLine("Seleccione vehiculo a arrendar:");
                        decvehiculo = VerifyInt(decvehiculo);
                        Console.WriteLine("Seleccionar Modelo de Vehiculo:");
                        //sucursales[eleccionsucursal].PrintVehiclesModels(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo);
                        if ((PoliticasDeArriendo(tipocliente).Count > 0) && PoliticasDeArriendo(tipocliente).ContainsKey(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo))
                        {
                            Dictionary<string, List<bool>> dic = PoliticasDeArriendo(tipocliente);
                            for (int veh = 0; veh < dic[sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo].Count; veh++)
                            {
                                if (dic[sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo][veh])
                                {
                                    Console.WriteLine("(" + (veh + 1) + ") " + sucursales[eleccionsucursal].GetVehiclesModels(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo)[veh]);
                                }
                            }
                        }
                        else for (int veh = 0; veh < sucursales[eleccionsucursal].GetVehiclesModels(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo).Count; veh++) Console.WriteLine("(" + (veh + 1) + ") " + sucursales[eleccionsucursal].GetVehiclesModels(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo)[veh]);
                        modelo = VerifyInt(modelo);
                        while (true)
                        {
                            Console.WriteLine("Desea agregar accesorios:");
                            foreach (int acce in sucursales[eleccionsucursal].Accesorios.Keys) Console.WriteLine("(" + acce + ") " +
                                sucursales[eleccionsucursal].Accesorios[acce].Nombre + " Precio: " +
                                sucursales[eleccionsucursal].Accesorios[acce].Precio);
                            Console.WriteLine("(" + (sucursales[eleccionsucursal].Accesorios.Count + 1) + ") Continuar\n");
                            decacce = VerifyInt(decacce);
                            if (decacce < sucursales[eleccionsucursal].Accesorios.Count + 1)
                            {
                                acc.Add(sucursales[eleccionsucursal].Accesorios[decacce]);
                                Console.WriteLine("Accesorio agregado\n");
                            }
                            else break;
                        }
                        Console.WriteLine("Ingrese fecha de termino contrato (dd-mm-yy):\n");
                        termino = DateTime.Parse(Console.ReadLine());
                        resultadoarrendar = ArrendarVehiculo(rut, tipocliente, eleccionsucursal, decvehiculo, acc, termino, modelo);
                        if (resultadoarrendar == 0)
                        {
                            Console.WriteLine("Arriendo Completado, queda Registro" + registros.Count + ":\n");
                            registros[registros.Count].ImprimirRegistro();
                        }
                        if (resultadoarrendar == 1) Console.WriteLine("Error: No Arrendado => Stock\n");
                        if (resultadoarrendar == 2) Console.WriteLine("Error: No Arrendado => Licencia\n");
                        if (resultadoarrendar == 3) Console.WriteLine("Error: No Arrendado => Autorizacion\n");
                    }
                }
                else if (decision0 == 7)
                {
                    Console.WriteLine($"{"  ",-3}{"Menu: Recepcion de Vehiculo",-30}");
                    Console.WriteLine($"{"  ",-3}{guion30 + "\n",30}");
                    Console.WriteLine("Elegir sucursal a devolver vehiculo:\n");
                    decision2 = ElegirSucursal(decision2);
                    Console.WriteLine("Elegir vehiculo a devolver: \n");
                    foreach (float i in vehiculossucursales.Keys) Console.WriteLine("(" + i + ") " + vehiculossucursales[i]);
                    Console.WriteLine("Ingrese (id) Tipo que quiere agregar: ");
                    id = VerifyInt(id);
                    Console.WriteLine("Seleccionar Modelo de Vehiculo:");
                    sucursales[decision2].PrintVehiclesModels(sucursales[decision2].Vehiculos[sucursales[decision2].GetIndexVehicle(vehiculossucursales[id])].Tipo);
                    modelo = VerifyInt(modelo);
                    sucursales[decision2].RecibirVehiculo(vehiculossucursales[id], modelo);
                    Console.WriteLine("\nVehiculo correctamente recepcionado\n");
                }
                else if (decision0 == 8) break;

            }
            
        }
        public void Simulacion()
        {
            int hora = 9;
            int llegadapersonas;
            string rut;
            int tipocliente;
            int eleccionsucursal=1;
            int decvehiculo;
            DateTime termino;
            int resultadoarriendo;
            int accion; //accion 1=arrendar, accion=2 devolver.
            int devueltos=0;
            int modelo = 1;

            Console.WriteLine("Creando sucursal inicial...");
            CrearSucursal();
            Console.WriteLine("Agregando vehiculos...");
            sucursales[1].ComprarVehiculo("Auto", 400, 15, 1);
            sucursales[1].ComprarVehiculo("Camioneta", 500, 18, 1);
            sucursales[1].ComprarVehiculo("Acuatico", 600, 9, 1);
            sucursales[1].ComprarVehiculo("Bus", 800, 4, 2);
            sucursales[1].ComprarVehiculo("MaquinariaPesada", 1000, 3, 1);
            sucursales[1].ComprarVehiculo("Moto", 300, 14, 1);
            sucursales[1].ComprarVehiculo("Camion", 900, 0, 1);

            while (hora < 21)
            {
                llegadapersonas = random.Next(5, 13);
                Console.WriteLine($"{"\n"}{"++++++++++",10}{ "Hora: " + hora + ":00",6}{"++++++++++",10}{"\n"}");
                Console.WriteLine($"{"Cliente",-30}{"|",1}{"Vehiculo",-30}{"|",1}{"Accesorios",-25}{"|",1}{"Inicio",-20}{"|",1}{"Termino",-20}{"|",1}{"Total",-6}{"|",1}{"Fallo",-15}");
                Console.WriteLine($"{"------------------------------",-30}{" ",1}{"------------------------------",-30}{" ",1}{"-------------------------",-25}{" ",1}{"--------------------",-20}{" ",1}{"--------------------",-20}{" ",1}{"------",-6}{" ",1}{"---------------",-15}");
                for (int numeropersona=1; numeropersona <= llegadapersonas; numeropersona++)
                {
                    List<Accesorios> acc = new List<Accesorios>();
                    rut =random.Next(1000000, 20000000).ToString();
                    tipocliente = random.Next(1, 5);
                    decvehiculo = random.Next(1, 7);
                    modelo = random.Next(1, sucursales[eleccionsucursal].GetVehiclesModels(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo).Count+1);
                    termino = DateTime.Now.AddDays(random.Next(1,10));
                    int[] accesorios = { random.Next(1, 11), random.Next(1, 11), random.Next(1, 11), random.Next(1, 10), random.Next(1, 10), random.Next(1, 10) };
                    for (int i=0; i < 6; i++) if (accesorios[i] > 9) acc.Add(sucursales[eleccionsucursal].Accesorios[i + 1]);
                    accion = random.Next(1, 11);
                    if (accion <=8 )
                    {
                        resultadoarriendo = ArrendarVehiculo(rut, tipocliente, eleccionsucursal, decvehiculo, acc, termino, modelo);
                        if (resultadoarriendo == 0) { System.Threading.Thread.Sleep(250); registros[registros.Count].ImprimirRegistroenlinea(); }
                        else { System.Threading.Thread.Sleep(250); ArriendoNoLogrado[ArriendoNoLogrado.Count].ImprimirRegistroenlinea(); }
                    }
                    else
                    {
                        sucursales[eleccionsucursal].RecibirVehiculo(sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo, modelo);
                        devueltos += 1;
                        Console.WriteLine($"{"Devolucion de vehiculo",-30}{"|",1}{sucursales[eleccionsucursal].Vehiculos[decvehiculo].Tipo + " (" + sucursales[eleccionsucursal].Vehiculos[decvehiculo].Modelo_Tipo()[modelo - 1] + ")" + " Inv:"+ sucursales[eleccionsucursal].Stockvehiculos2[decvehiculo][modelo-1],-30}{"|",1}");
                    }
                }
                //if (registros.Count > 0) for (int i = ultimoregistrohora; i <= registros.Count; i++) registros[i].Fecha = DateTime.Parse(hora.ToString());
                //if (ArriendoNoLogrado.Count > 0) for (int i = ultimoregistrohora; i <= ArriendoNoLogrado.Count; i++) ArriendoNoLogrado[i].Fecha = DateTime.Parse(hora.ToString());
                hora++;
            }

            Console.WriteLine($"{"\n\n"}{" ",30}{"Resultado del dia",17}{"\n"}");

            string guion12 = "------------";
            string guion10 = "----------";
            string guion15 = "---------------";
            string guion20 = "--------------------";

            Console.WriteLine($"{guion12,-12}{"|",1}{guion10,-10}{"|",1}{guion10,-10}{"|",1}{guion10,-10}{"|",1}{guion10,-10}{"|",1}{guion15,-15}{"|",1}{guion10,-10}");
            Console.WriteLine($"{"Stock Final",-12}{"|",1}{"Auto",-10}{"|",1}{"Camioneta",-10}{"|",1}{"Acuatico",-10}{"|",1}{"Bus",-10}{"|",1}{"Maquinaria",-15}{"|",1}{"Moto",-10}");
            Console.WriteLine($"{" ",-12}{"|",1}{sucursales[eleccionsucursal].totalstockvehicle(1),-10}{"|",1}{sucursales[eleccionsucursal].totalstockvehicle(2),-10}{"|",1}{sucursales[eleccionsucursal].totalstockvehicle(3),-10}{"|",1}{sucursales[eleccionsucursal].totalstockvehicle(4),-10}{"|",1}{sucursales[eleccionsucursal].totalstockvehicle(5),-15}{"|",1}{sucursales[eleccionsucursal].totalstockvehicle(6),-10}");
            Console.WriteLine($"{guion12,-12}{"|",1}{guion10,-10}{"|",1}{guion10,-10}{"|",1}{guion10,-10}{"|",1}{guion10,-10}{"|",1}{guion15,-15}{"|",1}{guion10,-10}");


            Console.WriteLine($"{"\n\n"}{" ",1}{guion20,-20}{"|",1}{guion10,-10}");
            Console.WriteLine($"{"|",1}{"Generales",-20}{"|",1}{"Resutado",-10}{"|",1}");
            Console.WriteLine($"{"|",1}{guion20,-20}{"|",1}{guion10,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{"Total Arrendados",-20}{"|",1}{registros.Count,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{guion20,-20}{"|",1}{guion10,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{"Total Devueltos",-20}{"|",1}{devueltos,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{guion20,-20}{"|",1}{guion10,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{"Total No Arrendados",-20}{"|",1}{ArriendoNoLogrado.Count,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{guion20,-20}{"|",1}{guion10,-10}{"|",1}");
            float sumadeldia = 0;
            foreach (float reg in registros.Keys) sumadeldia += registros[reg].Totalprecio; 
            Console.WriteLine($"{"|",1}{"Ganancia del dia",-20}{"|",1}{sumadeldia,-10}{"|",1}");
            Console.WriteLine($"{"|",1}{guion20,-20}{"|",1}{guion10,-10}{"|",1}");


            Console.ReadLine();
            
            
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
