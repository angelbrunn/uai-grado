using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIS.DATOS
{
    /// <summary>
    /// 
    /// </summary>
    public class DALPago
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenerUltimoNumeroOrden()
        {
            int ultimoNumeroOrden = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT MAX(idNumeroOrden) FROM PagoUsuario", con))
                {
                    try
                    {
                        con.Open();
                        ultimoNumeroOrden = (int)cmdSelect.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return ultimoNumeroOrden;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaPagoUsuario"></param>
        public void InsertarPago(List<PagoUsuario> listaPagoUsuario)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString);
           
            try
            {
                con.Open();
                foreach (PagoUsuario element in listaPagoUsuario)
                {
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO PagoUsuario (idNumeroOrden,idUsuario,nombreApellido,descripcion,monto,fechaPago) VALUES (@IdNumeroOrden,@IdUsuario,@NombreApellido,@Descripcion,@Monto,@FechaPago)", con);

                    cmdInsert.Parameters.AddWithValue("@IdNumeroOrden", element.IdNumeroOrden);
                    cmdInsert.Parameters.AddWithValue("@IdUsuario", element.IdUsuario);
                    cmdInsert.Parameters.AddWithValue("@NombreApellido", element.NombreApellido);
                    cmdInsert.Parameters.AddWithValue("@Descripcion", element.Descripcion);
                    cmdInsert.Parameters.AddWithValue("@Monto", element.Monto);
                    cmdInsert.Parameters.AddWithValue("@FechaPago", element.FechaPago);
                    cmdInsert.ExecuteNonQuery();
                }
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
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        public PagoUsuario ObtenerPagoUsuarioPorNumeroOrden(string idNumeroOrden)
        {
            PagoUsuario oPagoUsuario = new PagoUsuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM PagoUsuario WHERE idNumeroOrden=@IdNumeroOrden", con);
                    cmdSelect.Parameters.AddWithValue("@IdNumeroOrden", idNumeroOrden);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            oPagoUsuario.IdNumeroOrden = System.Convert.ToInt16(reader["idNumeroOrden"]);
                            oPagoUsuario.IdUsuario = reader["idUsuario"].ToString();
                            oPagoUsuario.NombreApellido = reader["nombreApellido"].ToString();
                            oPagoUsuario.Descripcion = reader["descripcion"].ToString();
                            oPagoUsuario.Monto = reader["monto"].ToString();
                            oPagoUsuario.FechaPago = reader["fechaPago"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return oPagoUsuario;
            }
        }
    }
}
