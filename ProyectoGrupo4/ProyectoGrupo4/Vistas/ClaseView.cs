using ProyectoGrupo4.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGrupo4.Vistas
{
    public partial class ClaseView : Form
    {
        public ClaseView()
        {
            InitializeComponent();
            ClaseController controller = new ClaseController(this);


        }
    }
}
