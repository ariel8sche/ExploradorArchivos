using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;

namespace Tarea11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directorio;

            do
            {
                Console.Write("Por favor ingrese la ruta del directorio: ");
                directorio = Console.ReadLine();

                if (!Directory.Exists(directorio))
                {
                    Console.WriteLine("\nEl directorio no existe, por favor ingrese una ruta válida.\n");
                }

                ExplorarArchivos(directorio);


            } while (!Directory.Exists(directorio));

        }//Fin del método Main

        static void ExplorarArchivos(string directorioPa)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine($"Contenido de: {Path.GetFileName(directorioPa)}\n");

                string[] archivosSubdirectorios = Directory.GetFileSystemEntries(directorioPa);

                MostrarTabla(archivosSubdirectorios);

                Console.Write("Ingrese el numero de la opcion que desee explorar (o 'a' para ir hacia atras, 'n' para ingresar una nueva ruta, 's' para salir): ");
                string opcion = Console.ReadLine();

                if (opcion.ToLower() == "s")
                {
                    continuar = false;
                }
                else if (opcion.ToLower() == "a")
                {
                    directorioPa = Path.GetDirectoryName(directorioPa);
                }
                else if (opcion.ToLower() == "n")
                {
                    Console.Clear();
                    Console.Write("Por favor ingrese la ruta del directorio: ");
                    string nuevaRuta = Console.ReadLine();
                    if (Directory.Exists(nuevaRuta))
                    {
                        directorioPa = nuevaRuta;
                    }
                    else
                    {
                        Console.WriteLine("\nLa ruta ingresada no es válida.\n");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else if (Convert.ToInt32(opcion) >= 0 && Convert.ToInt32(opcion) < archivosSubdirectorios.Length)
                {
                    int opcionEscogida = Convert.ToInt32(opcion);
                    if (Directory.Exists(archivosSubdirectorios[opcionEscogida]))
                    {
                        directorioPa = archivosSubdirectorios[opcionEscogida];
                    }
                    else
                    {
                        OperacionesArchivos(archivosSubdirectorios[opcionEscogida]);
                    }
                }
                else
                {
                    MensajeRutaNoValida();
                }
            }
        }//Fin del método ExplorarArchivos

        static void MostrarTabla(string[] archivosSubdirectoriosPa)
        {
            Console.WriteLine($"{"Indice",-8}{"Nombre",-50}{"Tipo",-13}");

            string guiones = new string('-', 71);
            string nombre, tipo;

            Console.WriteLine(guiones);

            for (int i = 0; i < archivosSubdirectoriosPa.Length; i++)
            {
                nombre = Path.GetFileName(archivosSubdirectoriosPa[i]);

                if (Directory.Exists(archivosSubdirectoriosPa[i]))
                {
                    tipo = "Subdirectorio";
                }
                else
                {
                    tipo = Path.GetExtension(archivosSubdirectoriosPa[i]);
                }

                Console.WriteLine($"{i,-8}{nombre,-50}{tipo,-13}");
            }

            Console.WriteLine();

        }//Fin del método MostrarArchivosSubdirectorios

        static void OperacionesArchivos(string archivo)
        {
            Console.Clear();
            Console.WriteLine($"Que accion desea realizar con el archivo {archivo}");
            Console.WriteLine("\n1. Copiar archivo");
            Console.WriteLine("2. Mover archivo");
            Console.WriteLine("3. Eliminar archivo");
            Console.WriteLine("4. Renombrar archivo");

            Console.Write("\nIngrese el numero de la opcion que desee realizar: ");
            int opcionArchivo = Convert.ToInt32(Console.ReadLine());

            switch (opcionArchivo)
            {
                case 1:
                    CopiarArchivo(archivo);
                    MensajeRealizadoConExito("copiar");
                    break;
                case 2:
                    MoverArchivo(archivo);
                    break;
                case 3:
                    EliminarArchivo(archivo);
                    break;
                case 4:
                    RenombrarArchivo(archivo);
                    break;
                default:
                    Console.WriteLine("\nLa opcion ingresada no es válida.\n");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }//Fin del método OperacionesArchivos

        static void CopiarArchivo(string archivo)
        {
            Console.Clear();
            string ruta;
            Console.Write($"Por favor ingrese la ruta donde desea copiar el archivo {Path.GetFileName(archivo)}: ");
            ruta = Console.ReadLine();
            string destino = Path.Combine(ruta, Path.GetFileName(archivo));
            if (Directory.Exists(ruta))
            {
                if (File.Exists(destino))
                {
                    string sobreEscribir;
                    Console.Write("El archivo ya existe en la ruta de destino, desea sobreescribirlo? (Si/No): ");
                    sobreEscribir = Console.ReadLine();
                    if (sobreEscribir.ToLower() == "si")
                    {
                        File.Copy(archivo, destino, true);
                        MensajeRealizadoConExito("copiar");
                    }
                    else if (sobreEscribir.ToLower() == "no")
                    {
                        MensajeOperacionCancelada();
                    }
                    else
                    {
                        Console.WriteLine("\nLa opcion ingresada no es válida.\n");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    File.Copy(archivo, destino);
                }
            }
            else
            {
                Console.WriteLine("\nLa ruta ingresada no es válida.\n");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        }//Fin del método CopiarArchivo

        static void MoverArchivo(string archivo)
        {
            Console.Clear();
            string ruta;
            Console.Write($"Por favor ingrese la ruta donde desea mover el archivo {Path.GetFileName(archivo)}: ");
            ruta = Console.ReadLine();
            string destino = Path.Combine(ruta, Path.GetFileName(archivo));
            if (Directory.Exists(ruta))
            {
                if (File.Exists(destino))
                {
                    string sobreEscribir;
                    Console.Write("El archivo ya existe en la ruta de destino, desea sobreescribirlo? (Si/No): ");
                    sobreEscribir = Console.ReadLine();
                    if (sobreEscribir.ToLower() == "si")
                    {
                        File.Delete(archivo);
                        File.Move(archivo, destino);
                        MensajeRealizadoConExito("mover");
                    }
                    else if (sobreEscribir.ToLower() == "no")
                    {
                        MensajeOperacionCancelada();
                    }
                    else
                    {
                        Console.WriteLine("\nLa opcion ingresada no es válida.\n");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    File.Move(archivo, destino);
                }
            }
            else
            {
                MensajeRutaNoValida();
            }

        }//Fin del método MoverArchivo

        static void EliminarArchivo(string archivo)
        {
            Console.Clear();
            Console.Write($"Esta seguro que desea eliminar el archivo {Path.GetFileName(archivo)}? (Si/No): ");
            string confirmar = Console.ReadLine().Trim().ToLower();
            if (confirmar == "si")
            {
                File.Delete(archivo);
                MensajeRealizadoConExito("eliminar");
            }
            else if (confirmar == "no")
            {
                MensajeOperacionCancelada();
            }
            else
            {
                Console.WriteLine("\nLa opcion ingresada no es válida.\n");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }//Fin del método EliminarArchivo

        static void RenombrarArchivo(string archivo)
        {
            Console.Clear();
            string ruta = Path.GetDirectoryName(archivo);
            Console.Write($"\nPor favor ingrese el nuevo nombre para el archivo {Path.GetFileName(archivo)}: ");
            string nuevoNombre = Console.ReadLine();
            string extension = Path.GetExtension(archivo);
            string nuevoArchivo = Path.Combine(ruta, nuevoNombre + extension);
            Console.Write("\nSeguro que desee renombrar el archvo? (Si/No): ");
            string confirmar = Console.ReadLine();
            if (confirmar.ToLower() == "si")
            {
                File.Move(archivo, nuevoArchivo);
                MensajeRealizadoConExito("renombrar");
            }
            else if (confirmar.ToLower() == "no")
            {
                MensajeOperacionCancelada();
            }
            else
            {
                Console.WriteLine("\nLa opcion ingresada no es válida.\n");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }//Fin del método RenombrarArchivo

        static void MensajeRealizadoConExito(string tipoMovimientoPa)
        {
            switch (tipoMovimientoPa)
            {
                case "copiar":
                    Console.WriteLine("\nEl archivo ha sido copiado con éxito.\n");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "mover":
                    Console.WriteLine("\nEl archivo ha sido movido con éxito.\n");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "eliminar":
                    Console.WriteLine("\nEl archivo ha sido eliminado con éxito.\n");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "renombrar":
                    Console.WriteLine("\nEl archivo ha sido renombrado con éxito.\n");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }//Fin del método MensajeRealizadoConExito

        static void MensajeOperacionCancelada()
        {
            Console.WriteLine("\nLa operación ha sido cancelada.\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }//Fin del método MensajeOperacionCancelada

        static void MensajeRutaNoValida()
        {
            Console.WriteLine("\nLa ruta ingresada no es válida.\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }//Fin del método MensajeRutaNoValida

    }//Fin de la clase Program
}//Fin del namespace Tarea11
