using System;
class Vuelos
{
    static int[][] vuelo = new int[0][];
    static string[] destino = new string[0];

    static void Main()
    {
        int opcion = 0;

        //Menu de opciones
        do
        {
            Console.WriteLine("1) Crear vuelo.");
            Console.WriteLine("2) Reservar asiento.");
            Console.WriteLine("3) Cancelar reserva.");
            Console.WriteLine("4) Mostrar estado actual.");
            Console.WriteLine("5) Mostrar asientos(Disponibles/Ocupados).");
            Console.WriteLine("6) Buscar asiento.");
            Console.WriteLine("7) Salir.");
            Console.Write("Ingrese una opcion:");
            opcion = int.Parse(Console.ReadLine());

            if (vuelo.Length == 0 && opcion != 1)
            {
                if (opcion != 7)
                {

                    Console.Clear();
                    Console.WriteLine("Primero debe crear un vuelo.");
                    Console.ReadKey();
                }
            }
            else
            {


                switch (opcion)
                {

                    case 1:
                        CrearVuelo();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        ReservarAsiento();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        CancelarReservaAsiento();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:

                        MostrarEstadoActual();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        EstadoAsiento();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        BuscarAsiento();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 7:
                        Console.WriteLine("Saliendo...Gracias por elegirnos! ");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;

                }
            }
        } while (opcion != 7);
    }

    static void CrearVuelo()
    {

        Array.Resize(ref vuelo, vuelo.Length + 1);
        Array.Resize(ref destino, destino.Length + 1);

        vuelo[vuelo.Length - 1] = new int[60];

        Console.Write("Ingrese su destino:");
        string destinoText = Console.ReadLine();

        destino[destino.Length - 1] = destinoText;

        Console.WriteLine("Datos creados exitosamente.");
    }

    /* Reservar un asiento. Si está disponible (0) lo marca como ocupado (1).*/
    static void ReservarAsiento()
    {
        MostrarDestino();
        Console.Write("Ingrese el numero de vuelo:");
        int nvuelo = int.Parse(Console.ReadLine());

        MostrarAsientos(nvuelo);
        Console.Write("Ingrese el numero de asiento a reservar:");
        int nasiento = int.Parse(Console.ReadLine());


        if (vuelo[nvuelo - 1][nasiento - 1] == 1)
        {
            Console.WriteLine("El asiento ingresado ya se encuentra reservado. ");
        }
        else
        {
            vuelo[nvuelo - 1][nasiento - 1] = 1;

            Console.WriteLine("Vuelo con destino a " + destino[nvuelo - 1] + " asiento numero " + nasiento + " Reservado exitosamente.");
        }
    }

    /*   Cancelar una reserva. El asiento vuelve a estar disponible (0)*/
    static void CancelarReservaAsiento()
    {
        MostrarDestino();
        Console.Write("Ingrese el numero de vuelo:");
        int nvuelo = int.Parse(Console.ReadLine());

        MostrarAsientos(nvuelo);
        Console.Write("Ingrese el numero de asiento a cancelar: ");
        int nasiento = int.Parse(Console.ReadLine());

        if (vuelo[nvuelo - 1][nasiento - 1] == 0)
        {
            Console.WriteLine("No se encontraron reservas para el asiento.");
        }
        else
        {
            vuelo[nvuelo - 1][nasiento - 1] = 0;

            Console.WriteLine("Vuelo con destino a " + destino[nvuelo - 1] + " asiento numero: " + nasiento);
            Console.WriteLine("Reserva cancelada exitosamente.");
        }

    }

    /* Mostrar el estado actual del vuelo, mostrando todos los asientos disponibles y ocupados.*/

    static void MostrarDestino()
    {
        Console.Clear();

        for (int i = 0; i < vuelo.Length; i++)
        {
            Console.WriteLine("Vuelo numero " + (i + 1) + " con destino a " + destino[i]);
        }
    }
    static void MostrarAsientos(int nVuelo)
    {
        int numVuelo = nVuelo - 1;
        Console.Clear();

        for (int e = 0; e < vuelo[numVuelo].Length; e++)
        {
            if (e < 20)
            {
                Console.SetCursorPosition(20, (e));
                if (e < 9)
                {
                    Console.WriteLine("0" + (e + 1) + "_asiento: " + vuelo[numVuelo][e]);

                }
                else
                {
                    Console.WriteLine((e + 1) + "_asiento: " + vuelo[numVuelo][e]);
                }
            }
            else if (e < 40)
            {
                Console.SetCursorPosition(40, (e - 20));
                Console.WriteLine((e + 1) + "_asiento: " + vuelo[numVuelo][e]);
            }
            else
            {
                Console.SetCursorPosition(60, (e - 40));
                Console.WriteLine((e + 1) + "_asiento: " + vuelo[numVuelo][e]);
            }

        }
        Console.WriteLine(" ");

    }
    static void MostrarEstadoActual()
    {
        MostrarDestino();
        Console.Write("Ingrese numero de vuelo:");
        int numVuelo = int.Parse(Console.ReadLine());
        Console.Clear();
        MostrarAsientos(numVuelo);
    }

    /*Mostrar la cantidad de asientos disponibles y ocupados en el vuelo*/
    static void EstadoAsiento()
    {
        string[] ocupados = new string[0];
        string[] disponible = new string[0];
        int aocupados = 0;
        int adisponibles = 0;
        int opcion = 0;

        MostrarDestino();
        Console.Write("Ingrese el numero de vuelo:");
        int nvuelo = int.Parse(Console.ReadLine());

        for (int i = 0; i < vuelo[nvuelo - 1].Length; i++)
        {
            if (vuelo[nvuelo - 1][i] == 1)
            {
                Array.Resize(ref ocupados, ocupados.Length + 1);
                ocupados[ocupados.Length - 1] = "[" + (i + 1) + "]_Ocupado";
                aocupados++;

            }
            else
            {
                Array.Resize(ref disponible, disponible.Length + 1);
                disponible[disponible.Length - 1] = "[" + (i + 1) + "]_Disponible";
                adisponibles++;
            }
        }

        do
        {
            Console.Clear();
            opcion = MensajeEstadoAsiento(nvuelo, adisponibles, aocupados, opcion);

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    VerEstadoAsientos(disponible);
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    VerEstadoAsientos(ocupados);
                    Console.ReadKey();
                    break;
                case 3:
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 3);
    }

    static void VerEstadoAsientos(string[] cadena)
    {
        for (int i = 0; i < cadena.Length; i++)
        {
            if (i < 20)
            {
                Console.SetCursorPosition(20, i);
                Console.WriteLine(cadena[i]);

            }
            else if (i < 40)
            {
                Console.SetCursorPosition(40, (i - 20));
                Console.WriteLine(cadena[i]);
            }
            else
            {
                Console.SetCursorPosition(60, (i - 40));
                Console.WriteLine(cadena[i]);
            }
        }
        Console.WriteLine(" ");
    }

    static int MensajeEstadoAsiento(int nvuelo, int adisponibles, int aocupados, int opcion)
    {

        Console.WriteLine("Vuelo numero " + nvuelo + " con destino a " + destino[nvuelo - 1]);
        Console.WriteLine(adisponibles + " Asientos Disponibles.");
        Console.WriteLine(aocupados + " Asientos Ocupados.");

        Console.WriteLine("\n\n" + "1) Ver asientos disponibles.");
        Console.WriteLine("2) Ver asientos ocupados.");
        Console.WriteLine("3) Salir.");
        Console.Write("Ingrese una opcion:");
        opcion = int.Parse(Console.ReadLine());

        return opcion;
    }

    /*    Buscar un asiento en particular e indicar si el mismo está disponible*/
    static void BuscarAsiento()
    {
        MostrarDestino();
        Console.Write("Ingrese el numero de vuelo:");
        int nvuelo = int.Parse(Console.ReadLine());

        MostrarAsientos(nvuelo);
        Console.Write("Ingrese el numero de asiento:");
        int nasiento = int.Parse(Console.ReadLine());

        if (vuelo[nvuelo - 1][nasiento - 1] == 1)
        {
            Console.WriteLine("Vuelo a " + destino[nvuelo - 1] + " Asiento numero: " + nasiento);
            Console.WriteLine("Estado: Reservado - Ocupado.");

        }
        else
        {
            Console.WriteLine("Vuelo a " + destino[nvuelo - 1] + " Asiento numero: " + nasiento);
            Console.WriteLine("Estado: No Reservado - Disponible.");
        }
    }

}


