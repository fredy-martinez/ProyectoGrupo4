using ProyectoGrupo4.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProyectoGrupo4.Modelos.DAO
{
    public class GenerarBoletoDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();


        public bool InsertarBoleto(GenerarBoleto boleto)
        {
            bool boletos = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TOTAL ");
                sql.Append(" VALUES (@Cliente,@Total); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Cliente", SqlDbType.NVarChar, 80).Value = boleto.IdCliente;
                comando.Parameters.Add("@Total", SqlDbType.Int).Value = boleto.Total;
               



                comando.ExecuteNonQuery();
                MiConexion.Close();
                boletos = true;


            }
            catch (Exception)
            {
                boletos = false;
            }
            return boletos;
        }






        public bool InsertarBoletos(GenerarBoleto boleto)
            {
                bool boletos = false;
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" INSERT INTO GENERARBOLETO ");
                    sql.Append(" VALUES (@Nombre, @Fecha, @Clase, @Destino, @Precio, @FechaSalida,@FechaEntrada); ");

                    comando.Connection = MiConexion;
                    MiConexion.Open();
                    comando.Parameters.Clear();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = sql.ToString();
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = boleto.IdCliente;
                    comando.Parameters.Add("@Fecha", SqlDbType.DateTime, 80).Value = boleto.Fecha;
                    comando.Parameters.Add("@Clase", SqlDbType.NVarChar, 20).Value = boleto.IdClase;
                    comando.Parameters.Add("@Destino", SqlDbType.NVarChar, 20).Value = boleto.IdDestino;
                    comando.Parameters.Add("@Precio", SqlDbType.Int).Value = boleto.PrecioClase;
                    comando.Parameters.Add("@FechaSalida", SqlDbType.DateTime, 20).Value = boleto.FechaSalida;
                    comando.Parameters.Add("@FechaEntrada", SqlDbType.DateTime, 20).Value = boleto.FechaLlegada;
                   


                comando.ExecuteNonQuery();
                    MiConexion.Close();
                    boletos = true;


                }
                catch (Exception)
                {
                    boletos = false;
                }
                return boletos;
            }
        



    }
    }
