using ProyectoGrupo4.Modelos.DAO;
using ProyectoGrupo4.Modelos.Entidades;
using ProyectoGrupo4.Vistas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoGrupo4.Controladores
{
    public class GenerarBoletoController
    {
        int total;
        int totaladult, preciototal, CantNiños, CantBebes;
        GenerarBoletoView vista;
        GenerarBoletoDAO GenerarBDAO = new GenerarBoletoDAO();
        GenerarBoleto GenerarB = new GenerarBoleto();
        ClienteDAO clienteDAO = new ClienteDAO();
        ClaseDAO claseDAO = new ClaseDAO();
        DestinoDAO destinoDAO = new DestinoDAO();
        Cliente cliente = new Cliente();
        Destino destino = new Destino();
        TipoClase clase = new TipoClase();

        public GenerarBoletoController(GenerarBoletoView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
            vista.AceptarButton.Click += new EventHandler(Aceptar);
           

        }



        private void Aceptar(object sender, EventArgs e)
        {

          

            LimpiarControles();
            vista.NombreTextBox.Text = cliente.Nombre;
            vista.ClaseTextBox.Text = clase.Clase;
            vista.DestinoTextBox.Text = destino.CiudadDeSalida;
            vista.PrecioTextBox.Text = Convert.ToString(clase.Precio);
            vista.FechaSalidaTextBox.Text = Convert.ToString(destino.FechaDeSalida);
            vista.FechaRegresoTextBox.Text = Convert.ToString(destino.FechaDeRegreso);
            vista.IdTextBox.Text = Convert.ToString(cliente.Id);
            vista.txt_total.Text = total.ToString();


            GenerarB.IdCliente = clienteDAO.GetUltimoCliente(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            GenerarB.Total = total;

            bool inserto = GenerarBDAO.InsertarBoleto(GenerarB);

            if (inserto)
            {
                MessageBox.Show("Insertado Satisfactoriamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

            else
            {
                MessageBox.Show("Error");
            }



        }






        private void Load(object sender, EventArgs e)
        {

           

            listarBoleto();
            
            vista.ClaseTextBox.Text = claseDAO.GetUltimoClase(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            vista.PrecioTextBox.Text = claseDAO.GetPrecio();
            vista.DestinoTextBox.Text = destinoDAO.GetprimerDestino();
            vista.FechaSalidaTextBox.Text = destinoDAO.GetFechaSalida();
            vista.FechaRegresoTextBox.Text = destinoDAO.GetFechaLlegada();
            vista.IdTextBox.Text = clienteDAO.GetId();
            vista.txt_cantidadAdultos.Text = destinoDAO.GetCantidadAdultos();
            vista.txt_cantniños.Text = destinoDAO.GetCantidadNiños();
            vista.txt_cantidadbebes.Text = destinoDAO.GetCantidadbebes();

            totaladult = Convert.ToInt32(vista.txt_cantidadAdultos.Text);
            preciototal = Convert.ToInt32(vista.PrecioTextBox.Text);
            CantNiños =  Convert.ToInt32( vista.txt_cantniños.Text);
            CantBebes = Convert.ToInt32(vista.txt_cantidadbebes.Text);


            total = totaladult * preciototal * CantNiños * CantBebes; // Codificacion Total
            





        }




        private void listarBoleto()
        {
            vista.NombreTextBox.Text = clienteDAO.GetUltimoCliente(System.Threading.Thread.CurrentPrincipal.Identity.Name);

        }
        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.NombreTextBox.Clear();
            vista.PrecioTextBox.Clear();
            vista.FechaRegresoTextBox.Clear();
            vista.FechaSalidaTextBox.Clear();
            vista.DestinoTextBox.Clear();
            vista.ClaseTextBox.Clear();
        }

    }
}
