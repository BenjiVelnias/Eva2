using Evaluacion2Aplicaciones.Sockets;
using LibreriaClases.DAL;
using LibreriaClases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2Aplicaciones.Comunicacion
{
    public class HebraCliente
    {
        private ClienteCom clienteCom;
        private IMedidor iMedidor = Lectura.GetInstancia();

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }
        public void Ejecutar()
        {
            try
            {
                clienteCom.Escribir("Ingrese numero medidor: ");
                string id = clienteCom.Leer();
                clienteCom.Escribir("Ingrese Fecha: ");
                string fecha = clienteCom.Leer();
                clienteCom.Escribir("Ingrese valor de consumo: ");
                string consumo = clienteCom.Leer();

                Medidores medidores = new Medidores()
                {
                    Id = Convert.ToInt32(id),
                    Fecha = DateTime.Parse(fecha),
                    Consumo = Convert.ToDecimal(consumo)
                };

                lock (iMedidor)
                {
                    iMedidor.IngresarMedidores(medidores);
                }
                clienteCom.Escribir("Datos ingresados correctamente");
                clienteCom.Desconectar();
            }
            catch (Exception)
            {
                clienteCom.Escribir("Datos ingresados incorrectamente");
                clienteCom.Desconectar();
            }
        }
    }
}
