using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClases.DTO
{
    public class Medidores
    {
        private int id;
        private DateTime fecha;
        private decimal consumo;

        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Consumo { get => consumo; set => consumo = value; }

        public override string ToString()
        {
            return id + "| " + fecha + "| " + consumo;
        }
    }
}