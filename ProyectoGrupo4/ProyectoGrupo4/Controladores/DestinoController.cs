using ProyectoGrupo4.Modelos.DAO;
using ProyectoGrupo4.Modelos.Entidades;
using ProyectoGrupo4.Vistas;
using System;
using System.Windows.Forms;

namespace ProyectoGrupo4.Controladores
{
    public class DestinoController
    {
        
            DestinoView vista;
            DestinoDAO destinoDAO = new DestinoDAO();
            Destino destino = new Destino ();
            string operacion = string.Empty;

            public DestinoController(DestinoView view)
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
                if (vista.CiudadSalidaTextBox.Text == "")
                {
                    vista.errorProvider1.SetError(vista.CiudadSalidaTextBox, "Ingrese la Ciudad de salida");
                    vista.CiudadSalidaTextBox.Focus();
                }

                if (vista.LugarDestinotextBox.Text == "")
                {
                    vista.errorProvider1.SetError(vista.LugarDestinotextBox, "Ingrese el lugar de destino");
                    vista.LugarDestinotextBox.Focus();
                }

                if (vista.CantidadAdultotextBox.Text == "")
                {
                    vista.errorProvider1.SetError(vista.CantidadAdultotextBox, "Ingrese la cantidad de adulto");
                    vista.CantidadAdultotextBox.Focus();
                }

                if (vista.CantidadNiniosTextBox.Text == "")
                {
                    vista.errorProvider1.SetError(vista.CantidadNiniosTextBox, "Ingrese la cantidad de niños");
                    vista.CantidadNiniosTextBox.Focus();
                }

                if (vista.CantidadBebesTextBox.Text == "")
                {
                    vista.errorProvider1.SetError(vista.CantidadBebesTextBox, "Ingrese la cantidad de bebés");
                    vista.CantidadBebesTextBox.Focus();
                }

                if (vista.FechaSalidaDateTimePicker.Text == "")
                {
                    vista.errorProvider1.SetError(vista.FechaSalidaDateTimePicker, "Ingrese la fecha de salida");
                    vista.FechaSalidaDateTimePicker.Focus();
                }
                if (vista.FechaLlegadaDateTimePicker.Text == "")
                {
                   vista.errorProvider1.SetError(vista.FechaLlegadaDateTimePicker, "Ingrese la fechja de regreso");
                   vista.FechaLlegadaDateTimePicker.Focus();
                }

                        destino.CiudadDeSalida = vista.CiudadSalidaTextBox.Text;
                        destino.LugarDestino = vista.LugarDestinotextBox.Text;
                        destino.CantidadAdultos = Convert.ToInt32(vista.CantidadAdultotextBox.Text);
                        destino.CantidadNinios = Convert.ToInt32(vista.CantidadNiniosTextBox.Text);
                        destino.CantidadBebes = Convert.ToInt32(vista.CantidadBebesTextBox.Text);
                        destino.FechaDeSalida = vista.FechaSalidaDateTimePicker.Value;
            destino.FechaDeRegreso = vista.FechaLlegadaDateTimePicker.Value;

            try
            {
                    
              


                    if (operacion == "Nuevo")
                    {
                        bool inserto = destinoDAO.InsertarNuevoDestino(destino);

                        if (inserto)
                        {
                            DeshabilitarControles();
                            LimpiarControles();
                            MessageBox.Show("Destino creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarClientes();
                        }
                        else
                        {
                            MessageBox.Show("Destino NO creado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (operacion == "Modificar")
                    {
                        destino.id = Convert.ToInt32(vista.IdtextBox.Text);
                        bool modifico = destinoDAO.ActualizarDestino(destino);

                        if (modifico)
                        {
                            DeshabilitarControles();
                            LimpiarControles();
                            MessageBox.Show("Destino ha sido modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarClientes();
                        }
                        else
                        {
                            MessageBox.Show("Destino NO modificado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (vista.DestinoDataGridView.SelectedRows.Count > 0)
                {
                    HabilitarControles();
                    operacion = "Modificar";

                    vista.IdtextBox.Text = vista.DestinoDataGridView.CurrentRow.Cells["IDDESTINO"].Value.ToString();
                    vista.CiudadSalidaTextBox.Text = vista.DestinoDataGridView.CurrentRow.Cells["CIUDADSALIDA"].Value.ToString();
                    vista.LugarDestinotextBox.Text = vista.DestinoDataGridView.CurrentRow.Cells["LUGARDESTINO"].Value.ToString();
                    vista.CantidadAdultotextBox.Text = vista.DestinoDataGridView.CurrentRow.Cells["CANTIDADADULTOS"].Value.ToString();
                    vista.CantidadNiniosTextBox.Text = vista.DestinoDataGridView.CurrentRow.Cells["CANTIDADNINIOS"].Value.ToString();
                    vista.CantidadBebesTextBox.Text = vista.DestinoDataGridView.CurrentRow.Cells["CANTIDADBEBES"].Value.ToString();
                    vista.FechaSalidaDateTimePicker.Text = vista.DestinoDataGridView.CurrentRow.Cells["FECHASALIDA"].Value.ToString();
                   vista.FechaLlegadaDateTimePicker.Text = vista.DestinoDataGridView.CurrentRow.Cells["FECHAREGRESO"].Value.ToString();
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
                if (vista.DestinoDataGridView.SelectedRows.Count > 0)
                {
                    bool elimino = destinoDAO.EliminarDestino(Convert.ToInt32(vista.DestinoDataGridView.CurrentRow.Cells["IDDESTINO"].Value));
                    if (elimino)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Destino eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Destino NO eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            private void ListarClientes()
            {
                vista.DestinoDataGridView.DataSource = destinoDAO.GetDestino();
            }

            private void Cancelar(object sender, EventArgs e)
            {
                DeshabilitarControles();
                LimpiarControles();
                destino = null;
            }

            private void Nuevo(object sender, EventArgs e)
            {
                operacion = "Nuevo";
                HabilitarControles();
            }

            private void HabilitarControles()
            {
                vista.CiudadSalidaTextBox.Enabled = true;
                vista.LugarDestinotextBox.Enabled = true;
                vista.CantidadAdultotextBox.Enabled = true;
                vista.CantidadNiniosTextBox.Enabled = true;
                vista.CantidadBebesTextBox.Enabled = true;
                vista.FechaSalidaDateTimePicker.Enabled = true;
                vista.FechaLlegadaDateTimePicker.Enabled = true;

                vista.GuardarButton.Enabled = true;
                vista.CancelarButton.Enabled = true;
                vista.ModificarButton.Enabled = false;
                vista.NuevoButton.Enabled = false;
            }

            private void DeshabilitarControles()
            {
                vista.CiudadSalidaTextBox.Enabled = false;
                vista.LugarDestinotextBox.Enabled = false;
                vista.CantidadAdultotextBox.Enabled = false;
                vista.CantidadNiniosTextBox.Enabled = false;
                vista.CantidadBebesTextBox.Enabled = false;
                vista.FechaSalidaDateTimePicker.Enabled = false;
                vista.FechaLlegadaDateTimePicker.Enabled = false;

                vista.GuardarButton.Enabled = false;
                vista.CancelarButton.Enabled = false;
                vista.ModificarButton.Enabled = true;
                vista.NuevoButton.Enabled = true;

            }

            private void LimpiarControles()
            {
                 vista.CiudadSalidaTextBox.Clear();
                 vista.LugarDestinotextBox.Clear();
                 vista.CantidadAdultotextBox.Clear();
                 vista.CantidadNiniosTextBox.Clear();
                 vista.CantidadBebesTextBox.Clear();
           
        }
        }
    
}
