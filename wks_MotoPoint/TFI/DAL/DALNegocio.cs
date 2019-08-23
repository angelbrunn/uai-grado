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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Ruta> ObtenerVotacionesUsuario(string usuario)
        {
            List<Ruta> listadoVotacionesUsuario = new List<Ruta>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT codRuta FROM RutaUsuario WHERE usuario=@Usuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@Usuario", usuario);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ruta oRuta = new Ruta();
                                oRuta.CodRuta = reader["codRuta"].ToString();
                                listadoVotacionesUsuario.Add(oRuta);
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
                return listadoVotacionesUsuario;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="codRuta"></param>
        public void BorrarVotacion(string usuario, string codRuta)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdDelete = new SqlCommand("DELETE FROM [MotoPoint].[dbo].[RutaUsuario] WHERE usuario=@Usuario AND codRuta=@CodRuta", con))
                {
                    try
                    {
                        con.Open();
                        cmdDelete.Parameters.AddWithValue("@Usuario", usuario);
                        cmdDelete.Parameters.AddWithValue("@CodRuta", codRuta);
                        cmdDelete.ExecuteNonQuery();
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
        public int DecrementarVotacion(string codRuta)
        {
            int resultadoValidacion = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand("UPDATE RutaVotacion SET cantUsuario=CantUsuario-1 WHERE codRuta=@CodRuta", con))
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RutaVotacion> ObtenerDatosRutas()
        {
            List<RutaVotacion> listadoDatosRutas = new List<RutaVotacion>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT codRuta,cantUsuario,detalleRutaVotacion,fechaLimite FROM RutaVotacion", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RutaVotacion oRutaVotacion = new RutaVotacion();
                                oRutaVotacion.CodRuta = reader["codRuta"].ToString();
                                oRutaVotacion.cantUsuario = reader["cantUsuario"].ToString();
                                oRutaVotacion.DetalleRutaVotacion = reader["detalleRutaVotacion"].ToString();
                                oRutaVotacion.FechaLimite = reader["fechaLimite"].ToString();
                                listadoDatosRutas.Add(oRutaVotacion);
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
                return listadoDatosRutas;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Evento> ObtenerDatosEventos()
        {
            List<Evento> listadoDatosEventos = new List<Evento>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT TOP (6) [id],[codEvento],[desde],[hasta],[cantidadMinimaUsuarios],[cantidadActualUsuarios],[cantidadMaximaUsuarios],[estado],[detalleEvento],[fecha] FROM Evento WHERE estado='ABIERTO' ORDER BY [id] DESC", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Evento oEvento = new Evento();
                                oEvento.IdEvento = reader["id"].ToString();
                                oEvento.CodEvento = reader["codEvento"].ToString();
                                oEvento.Desde = reader["desde"].ToString();
                                oEvento.Hasta = reader["hasta"].ToString();
                                oEvento.MinMotos = reader["cantidadMinimaUsuarios"].ToString();
                                oEvento.ActualMotos = reader["cantidadActualUsuarios"].ToString();
                                oEvento.MaxMotos = reader["cantidadMaximaUsuarios"].ToString();
                                oEvento.Estado = reader["estado"].ToString();
                                oEvento.DetalleEvento = reader["detalleEvento"].ToString();
                                oEvento.Fecha = reader["fecha"].ToString();
                                listadoDatosEventos.Add(oEvento);
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
                return listadoDatosEventos;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RutaVotacion> ObtenerEstadoVotaciones()
        {
            List<RutaVotacion> listadoEstadoVotaciones = new List<RutaVotacion>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT codRuta,estado FROM RutaVotacion", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RutaVotacion oEstadoVotacion = new RutaVotacion();
                                oEstadoVotacion.CodRuta = reader["codRuta"].ToString();
                                oEstadoVotacion.Estado = reader["estado"].ToString();
                                listadoEstadoVotaciones.Add(oEstadoVotacion);
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
                return listadoEstadoVotaciones;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public Ruta ObtenerDetalleRuta(string codRuta)
        {
            Ruta oDetalleRuta = new Ruta();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT id,codRuta,desde,hasta,minMotos,maxMotos,fecha FROM Ruta WHERE codRuta=@CodRuta", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@CodRuta", codRuta);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oDetalleRuta.IdRuta = reader["id"].ToString();
                                oDetalleRuta.CodRuta = reader["codRuta"].ToString();
                                oDetalleRuta.Desde = reader["desde"].ToString();
                                oDetalleRuta.Hasta = reader["hasta"].ToString();
                                oDetalleRuta.MinMotos = reader["minMotos"].ToString();
                                oDetalleRuta.MaxMotos = reader["maxMotos"].ToString();
                                oDetalleRuta.Fecha = reader["fecha"].ToString();
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
                return oDetalleRuta;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public Actividad ObtenerActividad(string codRuta)
        {
            Actividad oActividad = new Actividad();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT id,codRuta,titulo,descripcion,codAct FROM Actividad WHERE codRuta=@CodRuta", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@CodRuta", codRuta);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oActividad.IdActividad = reader["id"].ToString();
                                oActividad.CodRuta = reader["codRuta"].ToString();
                                oActividad.TituloActividad = reader["titulo"].ToString();
                                oActividad.Descripcion = reader["descripcion"].ToString();
                                oActividad.CodAct = reader["codAct"].ToString();
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
                return oActividad;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodAct"></param>
        /// <returns></returns>
        public List<ActividadPrecio> ObtenerPrecioActividades(string CodAct)
        {
            List<ActividadPrecio> listadoActividadPrecio = new List<ActividadPrecio>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT id,codAct,tituloActividad,descripcion,precio FROM ActividadPrecio WHERE codAct=@CodAct", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@CodAct", CodAct);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ActividadPrecio oActividadPrecio = new ActividadPrecio();
                                oActividadPrecio.IdActividadPrecio = reader["id"].ToString();
                                oActividadPrecio.CodAct = reader["codAct"].ToString();
                                oActividadPrecio.TituloActividad = reader["tituloActividad"].ToString();
                                oActividadPrecio.Descripcion = reader["descripcion"].ToString();
                                oActividadPrecio.Precio = reader["precio"].ToString();
                                listadoActividadPrecio.Add(oActividadPrecio);
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
                return listadoActividadPrecio;
            }
        }
    }
}
