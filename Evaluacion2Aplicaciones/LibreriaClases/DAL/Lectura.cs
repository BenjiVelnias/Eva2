using LibreriaClases.DAL;
using LibreriaClases.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClases.DAL
{
    public class Lectura : IMedidor
    {
        private Lectura()
        {

        }

        private static Lectura instancia;
        public static IMedidor GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Lectura();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lectura.txt";
        public void IngresarMedidores(Medidores medidores)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(archivo, true))
                {
                    write.WriteLine(medidores.Id + ";" + medidores.Fecha + ";" + medidores.Consumo);
                    write.Flush();
                }
            }
            catch (Exception)
            {
            }
        }

        public List<Medidores> ObtenerMedidores()
        {
            List<Medidores> listaMedidores = new List<Medidores>();
            try
            {
                using(StreamReader reader = new StreamReader(archivo))
                {
                    string datos = "";
                    do
                    {
                        datos = reader.ReadLine();
                        if (datos != null)
                        {
                            string[] arr = datos.Trim().Split('|');
                            int id = Convert.ToInt32(arr[0]);
                            DateTime fecha = Convert.ToDateTime(arr[1]);
                            decimal consumo = Convert.ToDecimal(arr[2]);

                            Medidores medidores = new Medidores()
                            {
                                Id = id,
                                Fecha = fecha,
                                Consumo = consumo
                            };
                            listaMedidores.Add(medidores);
                        }
                    } while (datos != null);
                }
            }
            catch (Exception)
            {
                listaMedidores = null;
            }
            return listaMedidores;
        }


    }
}
