using Evaluacion2Aplicaciones.Sockets;
using LibreriaClases.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluacion2Aplicaciones.Comunicacion
{
    public class HebraServer
    {
        private IMedidor imedidor = Lectura.GetInstancia();
        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Servidor iniciado en el puerto {0} ", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("Esperando cliente ");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("Cliente conectado ");
                    ClienteCom clienteCom = new ClienteCom(cliente);

                    HebraCliente clienteThread = new HebraCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteThread.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                Console.WriteLine("La conexion fallo");
            }
        }
    }
}
