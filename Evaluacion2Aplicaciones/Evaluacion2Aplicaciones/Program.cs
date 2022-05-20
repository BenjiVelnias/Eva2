using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Evaluacion2Aplicaciones.Comunicacion;
using LibreriaClases;
using LibreriaClases.DAL;
using LibreriaClases.DTO;

namespace Evaluacion2Aplicaciones
{
    class Program
    {
        private static IMedidor iMedidor = Lectura.GetInstancia();
        static void Main(string[] args)
        {
            HebraServer hebra = new HebraServer();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (Menu()) ;
        }
        private static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1. Ingresar Datos");
            Console.WriteLine("2. Mostrar Datos");
            Console.WriteLine("3. Salir");

            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    Mostrar();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Por favor elija una opcion");
                    break;
            }
            return continuar;
        }
        private static void Ingresar()
        {
            try
            {
                Console.WriteLine("Ingrese los datos: ");
                string datos = Console.ReadLine().Trim();

                string[] data = datos.Split('|', '|', '|');

                int id = Convert.ToInt32(data[0]);
                DateTime fecha = Convert.ToDateTime(data[1]);
                decimal consumo = Convert.ToDecimal(data[2]);

                Medidores medidoress = new Medidores()
                {
                    Id = id,
                    Fecha = fecha,
                    Consumo = consumo
                };

                lock (iMedidor)
                {
                    iMedidor.IngresarMedidores(medidoress);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al ingresar los datos");
            }
        }
        private static void Mostrar()
        {
            List<Medidores> medidoress = null;
            lock (iMedidor)
            {
                medidoress = iMedidor.ObtenerMedidores();
            }
            foreach (Medidores medidores in medidoress)
            {
                Console.WriteLine(medidores);
            }
        }

    }
}
