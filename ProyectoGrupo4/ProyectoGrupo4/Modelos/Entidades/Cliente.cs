using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrupo4.Modelos.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Identidad { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string NumeroTelefonico { get; set; }
    }
}
