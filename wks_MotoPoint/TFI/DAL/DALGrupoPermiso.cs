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
    public class DALGrupoPermiso
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public List<GrupoPermiso> ObtenerPermisosPorIdGrupo(int idGrupo)
        {
            List<GrupoPermiso> listGrupoPermiso = new List<GrupoPermiso>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_GrupoPermisos WHERE idGrupo=@IdGrupo", con);
                    cmdSelect.Parameters.AddWithValue("@IdGrupo", idGrupo);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GrupoPermiso oGrupoPermiso = new GrupoPermiso();
                            oGrupoPermiso.IdGrupo = Convert.ToInt32(reader["IdGrupo"]);
                            oGrupoPermiso.IdPermiso = Convert.ToInt32(reader["idPermisos"]);
                            listGrupoPermiso.Add(oGrupoPermiso);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listGrupoPermiso;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GrupoPermiso> ObtenerGrupoPermiso()
        {
            List<GrupoPermiso> listGrupoPermiso = new List<GrupoPermiso>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_GrupoPermisos", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GrupoPermiso oGrupoPermiso = new GrupoPermiso();
                                oGrupoPermiso.IdGrupo = Convert.ToInt32(reader["IdGrupo"]);
                                oGrupoPermiso.IdPermiso = Convert.ToInt32(reader["idPermisos"]);
                                listGrupoPermiso.Add(oGrupoPermiso);
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                return listGrupoPermiso;
            }
        }
    }
}
