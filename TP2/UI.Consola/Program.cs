using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;


namespace UI.Consola
{
    class Program:Usuarios
    {
        static void Main(string[] args)
        {
            Usuarios usr1 = new Usuarios();
            ConsoleKeyInfo op;

            do
            {
                usr1.Menu();
                op = Console.ReadKey(true);
                //métodos son acciones, las propiedades son valores
                switch (op.Key)
                {
                    case ConsoleKey.L:
                        Console.WriteLine("Ud seleccionó la opción Listado General");
                        usr1.ListadoGeneral();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.C:
                        Console.WriteLine("Ud seleccionó la opción Consulta");
                        usr1.Consultar();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.A:
                        Console.WriteLine("Ud seleccionó la opción Agregar");
                        usr1.Agregar();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.M:
                        Console.WriteLine("Ud seleccionó la opción Modificar");
                        usr1.Modificar();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.E:
                        Console.WriteLine("Ud seleccionó la opción Eliminar");
                        usr1.Eliminar();
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("Gracias");
                        Console.ReadKey();
                        break;
                }
            } while (op.Key != ConsoleKey.Escape);
        }
       
       
    }
}
