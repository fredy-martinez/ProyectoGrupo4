using ProyectoGrupo4.Modelos.DAO;
using ProyectoGrupo4.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGrupo4.Controladores
{
    public class BoletoDetalleController
    {
        BoletoView vista;
        ClienteDAO clienteDAO = new ClienteDAO();
        DestinoDAO destino = new DestinoDAO();
        
       


      

        public BoletoDetalleController(BoletoView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
        }


        private void Load (object sender, EventArgs e)
        {
            ListarDestino();
            ListarCliente();
            
        }

        private void ListarCliente()
        {
            vista.Cliente2DataGridView.DataSource = clienteDAO.GetCliente();
        }

        private void ListarDestino()
        {
            vista.Destino2GridView.DataSource = destino.GetDestino();
        }
    }
}
