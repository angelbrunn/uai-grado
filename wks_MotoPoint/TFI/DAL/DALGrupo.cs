using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SIS.DATOS
{
    /// <summary>
    /// ADO.NET MODO: DESCONECTADO
    /// </summary>
    public class DALGrupo
    {
        /// <summary>
        /// ADO.NET MODO: DESCONECTADO
        /// </summary>
        public List<Grupo> ObtenerGrupos()
        {
            List<Grupo> listGrupo = new List<Grupo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Grupo", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Grupo oGrupo = new Grupo();
                                oGrupo.IdGrupo = Convert.ToInt32(reader["IdGrupo"]);
                                oGrupo.grupo = reader["grupo"].ToString();
                                oGrupo.Descripcion = reader["Descripcion"].ToString();
                                listGrupo.Add(oGrupo);
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new SIS.EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                return listGrupo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public Grupo ObtenerGrupoPorId(int idGrupo)
        {
            Grupo oGrupo = new Grupo();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Grupo WHERE idGrupo=@IdGrupo", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@IdGrupo", idGrupo);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oGrupo.IdGrupo = Convert.ToInt32(reader["IdGrupo"]);
                                oGrupo.grupo = reader["grupo"].ToString();
                                oGrupo.Descripcion = reader["Descripcion"].ToString();
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new SIS.EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                return oGrupo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <returns></returns>
        public String ObtenerDescripcionGrupoPorNombreGrupo(String nombreGrupo)
        {
            String descripcionGrupo = "Error";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Grupo WHERE grupo=@nombreGrupo", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                descripcionGrupo = reader["grupo"].ToString();
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new SIS.EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                return descripcionGrupo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <returns></returns>
        public Grupo obtenerGrupoPorNombreGrupo(String nombreGrupo)
        {
            Grupo oGrupo = new Grupo();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Grupo WHERE grupo=@nombreGrupo", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oGrupo.IdGrupo = Convert.ToInt32(reader["IdGrupo"]);
                                oGrupo.grupo = reader["grupo"].ToString();
                                oGrupo.Descripcion = reader["Descripcion"].ToString();
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new SIS.EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                return oGrupo;
            }
        }
    }
}
