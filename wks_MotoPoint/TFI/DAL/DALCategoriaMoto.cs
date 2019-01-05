using System;
using SIS.ENTIDAD;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace SIS.DATOS
{
    /// <summary>
    /// ADO.NET MODO: DESCONECTADO
    /// </summary>
    public class DALCategoriaMoto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoriaMoto> ObtenerTablaCategoriaMoto()
        {
            List<CategoriaMoto> listadoCategoriaMoto = new List<CategoriaMoto>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM CategoriaMoto", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CategoriaMoto oCategoriaMoto = new CategoriaMoto();
                                oCategoriaMoto.idCategoriaMoto = reader["id"].ToString();
                                oCategoriaMoto.categoriaMoto = reader["categoriaMoto"].ToString();
                                oCategoriaMoto.Descripcion = reader["descripcion"].ToString();
                                listadoCategoriaMoto.Add(oCategoriaMoto);
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
                return listadoCategoriaMoto;
            }
        }
    }
}
