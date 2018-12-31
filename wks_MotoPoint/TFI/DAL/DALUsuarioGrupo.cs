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
    public class DALUsuarioGrupo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public List<UsuarioGrupo> ObtenerGrupoPorIdUsuario(int idUsuario)
        {
            List<UsuarioGrupo> listadoUsuarioGrupo = new List<UsuarioGrupo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_UsuarioGrupo WHERE idUsuario=@IdUsuario", con);
                    cmdSelect.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioGrupo oUsuarioGrupo = new UsuarioGrupo();
                            oUsuarioGrupo.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
                            oUsuarioGrupo.IdGrupo = Convert.ToInt32(reader["idGrupo"]);
                            listadoUsuarioGrupo.Add(oUsuarioGrupo);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listadoUsuarioGrupo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsuarioGrupo> ObtenerTablaUsuarioGrupo()
        {
            List<UsuarioGrupo> listadoUsuarioGrupo = new List<UsuarioGrupo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_UsuarioGrupo", con);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioGrupo oUsuarioGrupo = new UsuarioGrupo();
                            oUsuarioGrupo.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
                            oUsuarioGrupo.IdGrupo = Convert.ToInt32(reader["idGrupo"]);
                            listadoUsuarioGrupo.Add(oUsuarioGrupo);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listadoUsuarioGrupo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuarioGrupo"></param>
        public void InsertarUsuarioGrupo(UsuarioGrupo oUsuarioGrupo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdInsert = new SqlCommand("INSERT INTO tbl_UsuarioGrupo([idUsuario],[idGrupo]) VALUES (@IdUsuario,@IdGrupo)", con))
                {
                    cmdInsert.Parameters.AddWithValue("@IdUsuario", oUsuarioGrupo.IdUsuario);
                    cmdInsert.Parameters.AddWithValue("@IdGrupo", oUsuarioGrupo.IdGrupo);

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
    }
}
