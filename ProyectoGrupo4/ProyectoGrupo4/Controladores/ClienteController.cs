using ProyectoGrupo4.Modelos.DAO;
using ProyectoGrupo4.Modelos.Entidades;
using ProyectoGrupo4.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGrupo4.Controladores
{
    public class ClienteController
    {
        ClienteView vista;
        ClienteDAO clienteDAO = new ClienteDAO();
        Cliente cliente = new Cliente();
        string operacion = string.Empty;

        public ClienteController(ClienteView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.Load += new EventHandler(Load);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.IdentidadMaskedTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdentidadMaskedTextBox, "Ingrese la Identidad");
                vista.IdentidadMaskedTextBox.Focus();
            }

            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese la Nombre");
                vista.NombreTextBox.Focus();
            }

            if (vista.CorreoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.CorreoTextBox, "Ingrese el Correo");
                vista.CorreoTextBox.Focus();
            }

            if (vista.NumeroTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NumeroTextBox, "Ingrese el Numero telefonico");
                vista.NumeroTextBox.Focus();
            }

            if (vista.GeneroTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.GeneroTextBox, "Ingrese el Genero");
                vista.GeneroTextBox.Focus();
            }

            if (vista.EdadTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EdadTextBox, "Ingrese la Edad");
                vista.EdadTextBox.Focus();
            }

            try
            {
                cliente.Identidad = vista.IdentidadMaskedTextBox.Text;
                cliente.Nombre = vista.NombreTextBox.Text;
                cliente.Correo = vista.CorreoTextBox.Text;
                cliente.NumeroTelefonico = vista.NumeroTextBox.Text;
                cliente.Edad = Convert.ToInt32(vista.EdadTextBox.Text);
                cliente.Genero = vista.GeneroTextBox.Text;


                if (operacion == "Nuevo")
                {
                    bool inserto = clienteDAO.InsertarNuevoCliente(cliente);

                    if (inserto)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Cliente creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();

                        System.Security.Principal.GenericIdentity Nombre = new System.Security.Principal.GenericIdentity(vista.NombreTextBox.Text);
                        System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(Nombre, null);
                        System.Threading.Thread.CurrentPrincipal = principal;
                    }
                    else
                    {
                        MessageBox.Show("Cliente NO creado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion == "Modificar")
                {
                    cliente.Id = Convert.ToInt32(vista.IdTextBox.Text);
                    bool modifico = clienteDAO.ActualizarCliente(cliente);

                    if (modifico)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Cliente ha sido modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente NO modificado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.ClienteDataGridView.SelectedRows.Count > 0)
            {
                HabilitarControles();
                operacion = "Modificar";

                vista.IdTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.IdentidadMaskedTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                vista.NombreTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.CorreoTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["CORREO"].Value.ToString();
                vista.GeneroTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["GENERO"].Value.ToString();
                vista.EdadTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["EDAD"].Value.ToString();
                vista.NumeroTextBox.Text = vista.ClienteDataGridView.CurrentRow.Cells["NUMEROTELEFONICO"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.ClienteDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = clienteDAO.EliminarCliente(Convert.ToInt32(vista.ClienteDataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Cliente eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente NO eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListarClientes()
        {
            vista.ClienteDataGridView.DataSource = clienteDAO.GetCliente();
        }

        private void Cancelar(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
            cliente = null;
        }

        private void Nuevo(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            vista.IdentidadMaskedTextBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;
            vista.CorreoTextBox.Enabled = true;
            vista.NumeroTextBox.Enabled = true;
            vista.EdadTextBox.Enabled = true;
            vista.GeneroTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            vista.IdentidadMaskedTextBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.CorreoTextBox.Enabled = false;
            vista.NumeroTextBox.Enabled = false;
            vista.EdadTextBox.Enabled = false;
            vista.GeneroTextBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;

        }

        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.IdentidadMaskedTextBox.Clear();
            vista.NombreTextBox.Clear();
            vista.NumeroTextBox.Clear();
            vista.CorreoTextBox.Clear();
            vista.GeneroTextBox.Clear();
            vista.EdadTextBox.Clear();
        }
    }
}
