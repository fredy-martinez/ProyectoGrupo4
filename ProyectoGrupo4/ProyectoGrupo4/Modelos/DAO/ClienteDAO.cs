using ProyectoGrupo4.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrupo4.Modelos.DAO
{
    public class ClienteDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevoCliente(Cliente cliente)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CLIENTE ");
                sql.Append(" VALUES (@Nombre, @Correo, @Identidad, @Genero, @Edad, @NumeroTelefonico); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = cliente.Nombre;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 80).Value = cliente.Correo;
                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = cliente.Identidad;
                comando.Parameters.Add("@Genero", SqlDbType.NVarChar, 20).Value = cliente.Genero;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = cliente.Edad;
                comando.Parameters.Add("@NumeroTelefonico", SqlDbType.NVarChar, 20).Value = cliente.NumeroTelefonico;
                

                comando.ExecuteNonQuery();
                MiConexion.Close();
                inserto = true;
            }
            catch (Exception ex)
            {
                inserto = false;
            }
            return inserto;
        }

      

        public DataTable GetCliente()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM CLIENTE ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception )
            {

                throw;
            }
            return dt;
        }
       

        public bool ActualizarCliente(Cliente cliente)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE CLIENTE ");
                sql.Append(" SET NOMBRE = @Nombre, CORREO = @Correo, IDENTIDAD = @Identidad, GENERO = @Genero, EDAD = @Edad, NUMEROTELEFONICO = @NumeroTelefonico ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = cliente.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = cliente.Nombre;
                comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 80).Value = cliente.Correo;
                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = cliente.Identidad;
                comando.Parameters.Add("@Genero", SqlDbType.NVarChar, 20).Value = cliente.Genero;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = cliente.Edad;
                comando.Parameters.Add("@NumeroTelefonico", SqlDbType.NVarChar, 20).Value = cliente.NumeroTelefonico;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();
            }
            catch (Exception)
            {
                return modifico;
            }
            return modifico;
        }

        public bool EliminarCliente(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM CLIENTE ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();
            }
            catch (Exception)
            {
                return modifico;
            }
            return modifico;
        }

        public string GetUltimoCliente(string cl)
        {
            string nombre = string.Empty;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT NOMBRE FROM CLIENTE WHERE ID=(SELECT max(ID) FROM CLIENTE); ");



                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
               
                nombre = Convert.ToString( comando.ExecuteScalar());

               
               

                MiConexion.Close();

            }
            catch (Exception ex)
            {
               return nombre;
            }
            return nombre;
        }
        public string GetId()
        {
            string id = string.Empty;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ID FROM CLIENTE WHERE ID=(SELECT max(ID) FROM CLIENTE);");
                // sql.Append(" SELECT NOMBRE FROM CLIENTE WHERE ID=(SELECT max(ID) FROM CLIENTE ");




                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();

                id = Convert.ToString(comando.ExecuteScalar());


                MiConexion.Close();

            }
            catch (Exception ex)
            {
                return id;
            }
            return id;
        }
    }
}
