using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SIS.DATOS
{
    public class DALMultiIdioma
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public List<MultiIdioma> ObtenerTablaMultiIdioma(String idioma)
        {
            List<MultiIdioma> listaMultiIdioma = new List<MultiIdioma>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_MultiIdioma where ikey=@Idioma", con);
                    cmdSelect.Parameters.AddWithValue("@Idioma", idioma);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MultiIdioma oMultiIdioma = new MultiIdioma();
                            oMultiIdioma.Componente = reader["componente"].ToString();
                            oMultiIdioma.IKey = reader["ikey"].ToString();
                            oMultiIdioma.Value = reader["value"].ToString();
                            listaMultiIdioma.Add(oMultiIdioma);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listaMultiIdioma;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MultiIdioma> ObtenerTablaMultiIdiomaAll()
        {
            List<MultiIdioma> listaMultiIdioma = new List<MultiIdioma>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_MultiIdioma", con);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MultiIdioma oMultiIdioma = new MultiIdioma();
                            oMultiIdioma.Componente = reader["componente"].ToString();
                            oMultiIdioma.IKey = reader["ikey"].ToString();
                            oMultiIdioma.Value = reader["value"].ToString();
                            listaMultiIdioma.Add(oMultiIdioma);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listaMultiIdioma;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MultiIdioma> IdiomasDisponibles()
        {
            List<MultiIdioma> listaMultiIdioma = new List<MultiIdioma>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT DISTINCT iKey FROM tbl_MultiIdioma", con);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MultiIdioma oMultiIdioma = new MultiIdioma();
                            oMultiIdioma.Componente = reader["componente"].ToString();
                            oMultiIdioma.IKey = reader["ikey"].ToString();
                            oMultiIdioma.Value = reader["value"].ToString();
                            listaMultiIdioma.Add(oMultiIdioma);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return listaMultiIdioma;
            }
        }
    }
}
