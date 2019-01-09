using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIS.DATOS
{
    /// <summary>
    /// ADO.NET MODO: DESCONECTADO
    /// </summary>
    public class DALMembresia
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <param name="idUsuario"></param>
        public void InsertarMembresiaParaUsuario(MembresiaUsuario oMembresiaUsuario)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdInsert = new SqlCommand("INSERT INTO MembresiaUsuario([idUsuario],[idMembresia]) VALUES (@IdUsuario,@IdMembresia)", con))
                {
                    cmdInsert.Parameters.AddWithValue("@IdUsuario", oMembresiaUsuario.IdUsuario);
                    cmdInsert.Parameters.AddWithValue("@IdMembresia", oMembresiaUsuario.IdMembresia);

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
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaSegunTipo(string tipoMembresia)
        {
            int idMembresia = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT idMembresia FROM MembresiaTipo WHERE tipoMembresia=@TipoMembresia", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@TipoMembresia", tipoMembresia);
                        idMembresia = (int)cmdSelect.ExecuteScalar();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return idMembresia;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaPrecio(string idMembresia)
        {
            int membresiaPrecio = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT precio FROM MembresiaPrecio WHERE idMembresia=@IdMembresia", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@IdMembresia", idMembresia);
                        membresiaPrecio = (int)cmdSelect.ExecuteScalar();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return membresiaPrecio;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int ObtenerMembresiaUsuario(string idUsuario)
        {
            int idMembresia = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT idMembresia FROM MembresiaUsuario WHERE idUsuario=@IdUsuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        idMembresia = (int)cmdSelect.ExecuteScalar();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return idMembresia;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        public void InsertarMembresiaUsuario(string idUsuario, string idMembresia)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString);

            try
            {
                con.Open();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO MembresiaUsuario (idUsuario,idMembresia) VALUES (@IdUsuario,@IdMembresia)", con);
                cmdInsert.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmdInsert.Parameters.AddWithValue("@IdMembresia", idMembresia);
                cmdInsert.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new EXCEPCIONES.DALExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public int ActualizarMembresiaUsuario(string idUsuario, string idMembresia)
        {
            int resultadoValidacion = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand("UPDATE MembresiaUsuario SET idMembresia=@IdMembresia WHERE idUsuario=@IdUsuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdUpdate.Parameters.AddWithValue("@IdMembresia", idMembresia);
                        cmdUpdate.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        resultadoValidacion = (int)cmdUpdate.ExecuteNonQuery();
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
