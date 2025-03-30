using EverPostWebApi.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace ChannelMonitoring.Utils
{
    public class ADOHelper
    {
        private static readonly string cadenaConexion;
        static ADOHelper()
        {
            var configuracion = Configuracion.CargarConfiguracion();
            cadenaConexion = configuracion.GetConnectionString("Dev");
        }
        public static DataSet ListarTablas(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            var conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable Listar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public static bool Ejecutar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;


                        if (parametros != null)
                        {
                            foreach (var parametro in parametros)
                            {
                                cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                            }
                        }


                        SqlParameter returnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.TinyInt)
                        {
                            Direction = System.Data.ParameterDirection.ReturnValue
                        };
                        cmd.Parameters.Add(returnValue);


                        cmd.ExecuteNonQuery();

                        var resultado = (byte)returnValue.Value;
                        return resultado == 1;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo del error (puedes registrar el mensaje si lo deseas)
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

    }
}
