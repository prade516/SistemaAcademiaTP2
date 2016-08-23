using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Business.Entities;
//using Business.Logic;

namespace UI.Consola
{
    public class Usuarios 
    {

        private Business.Logic.UsuarioLogic _UsuarioNegocio;

        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }
   
        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();
        }
        public void Menu() 
        {

            Console.Clear(); //Limpiar la pantalla
            Console.WriteLine("\t\t\t\tMenú Sistema Academico\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t\t\t\t[L] Listado General\t\n");
            Console.Write("\t\t\t\t[C] Consulta\t\n");
            Console.Write("\t\t\t\t[A] Agregar\t\n");
            Console.Write("\t\t\t\t[M ]Modificar\t\n");
            Console.Write("\t\t\t\t[E] Eliminar\t\n");
            Console.Write("\t\t\t\t[Esc] Salir\t\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Seleccione opcion...");
            //op = Console.ReadKey(true);//Que no muestre la tecla señalada

        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Id Usuario : {0}", usr.Id_Usuario);
            Console.WriteLine("\t\tNombre Usuario :{0}", usr.Nombre_Usuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            //Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);

        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.ReadKey();
        }       
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del Usuario a Modificar\n");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingresa Nombre Usuario\n");
                usuario.Nombre_Usuario = Console.ReadLine();
                Console.WriteLine("Ingresa la Clave\n");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingresa el Email\n");
                //usuario.Email = Console.ReadLine();
                Console.WriteLine("Ingresa Habilitacion de Usuario(1-Si /otro-No):\n");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.Estado = BusinessEntity.Estados.Modificar;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.WriteLine("Ingresa Nombre Usuario\n");
            usuario.Nombre_Usuario = Console.ReadLine();
            Console.WriteLine("Ingresa la Clave\n");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingresa el Email\n");
            //usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingresa Habilitacion de Usuario(1-Si /otro-No):\n");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.Estado = BusinessEntity.Estados.Nuevo;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}",usuario.Id_Usuario);

        }

        public  void Consultar()
        {
            try
            {
                Usuarios usuar = new Usuarios();
                Console.Clear();
                Console.WriteLine("Ingresa El ID del Usuario a Consultar");
                int ID = int.Parse(Console.ReadLine());
                usuar.MostrarDatos(usuar.UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingresa el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

       
    }
}
