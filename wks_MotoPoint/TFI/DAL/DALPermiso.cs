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
    public class DALPermiso
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPermiso"></param>
        /// <returns></returns>
        public Permiso ObtenerPermisoPorId(int idPermiso)
        {
            Permiso oPermiso = new Permiso();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Permisos WHERE idPermiso=@IdPermiso", con);
                    cmdSelect.Parameters.AddWithValue("@IdPermiso", idPermiso);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oPermiso.IdPermiso = Convert.ToInt32(reader["idPermiso"]);
                            oPermiso.Descripcion = reader["descripcion"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return oPermiso;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ObtenerPermiso()
        {
            List<Permiso> listaPermiso = new List<Permiso>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Permisos", con);

                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permiso oPermiso = new Permiso();
                            oPermiso.IdPermiso = Convert.ToInt32(reader["idPermiso"]);
                            oPermiso.Descripcion = reader["descripcion"].ToString();
                            listaPermiso.Add(oPermiso);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listaPermiso;
            }
        }
    }
}
