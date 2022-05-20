using LibreriaClases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClases.DAL
{
    public interface IMedidor
    {
        void IngresarMedidores(Medidores medidores);

        List<Medidores> ObtenerMedidores();
    }
}
