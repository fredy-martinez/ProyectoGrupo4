using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrupo4.Modelos.Entidades
{
    public class GenerarBoleto
    {
        public int Id { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string IdClase { get; set; }
        public string IdDestino { get; set; }
        public decimal PrecioClase { get; set; }
        public int FechaSalida { get; set; }
        public int FechaLlegada { get; set; }

        public int Total { get; set; }

    }
}
