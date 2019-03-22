using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SIS.DATOS
{
    /// <summary>
    /// 
    /// </summary>
    public class DALNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Boolean ValidarLikeUsuario(string codRuta, string usuario)
        {
            int resultadoValidacion = 0;
            Boolean resultado;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {

                using (SqlCommand cmdSelect = new SqlCommand("SELECT id FROM RutaUsuario WHERE codRuta=@CodRuta AND usuario=@Usuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@CodRuta", codRuta);
                        cmdSelect.Parameters.AddWithValue("@Usuario", usuario);
                        resultadoValidacion = (int)cmdSelect.ExecuteScalar();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                //VALIDO EXISTENCIA | TRUE:EXISTE YA UN LIKE PARA ESA RUTA DE ESTE USUARIO
                if (!(resultadoValidacion == 0))
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenerUltimoIdLikeUsuario()
        {
            int ultimoId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT MAX(id) FROM RutaUsuario", con))
                {
                    try
                    {
                        con.Open();
                        ultimoId = (int)cmdSelect.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return ultimoId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public string ObtenerFecha(string codRuta)
        {
            string fecha;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {

                using (SqlCommand cmdSelect = new SqlCommand("SELECT fecha FROM Ruta WHERE codRuta=@CodRuta", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@CodRuta", codRuta);
                        fecha = (string)cmdSelect.ExecuteScalar();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return fecha;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <param name="usuario"></param>
        /// <param name="fechaRuta"></param>
        public void RegistrarLike(int idRutaLikeUsuario, string codRuta, string usuario, string fechaRuta)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdInsert = new SqlCommand("INSERT INTO RutaUsuario (Id,CodRuta,Usuario,Fecha) VALUES (@Id,@CodRuta,@Usuario,@Fecha)", con))
                {
                    cmdInsert.Parameters.AddWithValue("@Id", idRutaLikeUsuario);
                    cmdInsert.Parameters.AddWithValue("@CodRuta", codRuta);
                    cmdInsert.Parameters.AddWithValue("@Usuario", usuario);
                    cmdInsert.Parameters.AddWithValue("@Fecha", fechaRuta);

                    try
                    {
                        con.Open();
                        cmdInsert.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public int RegistrarVotacion(string codRuta)
        {
            int resultadoValidacion = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand("UPDATE RutaVotacion SET cantUsuario=CantUsuario+1 WHERE codRuta=@CodRuta", con))
                {
                    try
                    {
                        con.Open();
                        cmdUpdate.Parameters.AddWithValue("@CodRuta", codRuta);
                        resultadoValidacion = (int)cmdUpdate.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return resultadoValidacion;
        }
    }
}
