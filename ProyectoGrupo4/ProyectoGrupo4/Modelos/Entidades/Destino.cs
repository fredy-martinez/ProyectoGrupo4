using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrupo4.Modelos.Entidades
{
    public class Destino
    {
        public int id { get; set; }
        public string CiudadDeSalida { get; set; }

        public string LugarDestino { get; set; }

        public int CantidadAdultos { get; set; }
        public int CantidadNinios { get; set; }
        public int CantidadBebes { get; set; }
        public DateTime FechaDeSalida { get; set; }
        public DateTime FechaDeRegreso { get; set; }
    }
}
