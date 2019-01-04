﻿using SIS.ENTIDAD;
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
    public class DALUsuario
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenerUltimoId()
        {
            int ultimoId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT MAX(idUsuario) FROM tbl_Usuario", con))
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
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public String ObtenerNombreApellidoUsuario(int idUsuario)
        {
            String nombreApellido = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT nombreApellido FROM tbl_Usuario WHERE idUsuario=@IdUsuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        nombreApellido = (String)cmdSelect.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return nombreApellido;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioPorEmail(String email)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Usuario WHERE email=@Email", con);
                    cmdSelect.Parameters.AddWithValue("@Email", email);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oUsuario.IdUsuario = reader["idUsuario"].ToString();
                            oUsuario.NombreApellido = reader["nombreApellido"].ToString();
                            oUsuario.FechaNacimiento = reader["fechaNacimiento"].ToString();
                            oUsuario.CategoriaMoto = reader["categoriaMoto"].ToString();
                            oUsuario.usuario = reader["usuario"].ToString();
                            oUsuario.Password = reader["password"].ToString();
                            oUsuario.Email = reader["email"].ToString();
                            oUsuario.Estado = reader["estado"].ToString();
                            oUsuario.DigitoVerificador = reader["digitoVerificador"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return oUsuario;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioPorId(String idUsuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Usuario WHERE idUsuario=@IdUsuario", con);
                    cmdSelect.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oUsuario.IdUsuario = reader["idUsuario"].ToString();
                            oUsuario.NombreApellido = reader["nombreApellido"].ToString();
                            oUsuario.FechaNacimiento = reader["fechaNacimiento"].ToString();
                            oUsuario.usuario = reader["usuario"].ToString();
                            oUsuario.Password = reader["password"].ToString();
                            oUsuario.Email = reader["email"].ToString();
                            oUsuario.Estado = reader["estado"].ToString();
                            oUsuario.DigitoVerificador = reader["digitoVerificador"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return oUsuario;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioPorCategoriaMoto(String categoriaMoto)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Usuario WHERE categoriaMoto=@CategoriaMoto", con);
                    cmdSelect.Parameters.AddWithValue("@CategoriaMoto", categoriaMoto);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oUsuario.IdUsuario = reader["idUsuario"].ToString();
                            oUsuario.NombreApellido = reader["nombreApellido"].ToString();
                            oUsuario.FechaNacimiento = reader["fechaNacimiento"].ToString();
                            oUsuario.CategoriaMoto = reader["categoriaMoto"].ToString();
                            oUsuario.usuario = reader["usuario"].ToString();
                            oUsuario.Password = reader["password"].ToString();
                            oUsuario.Email = reader["email"].ToString();
                            oUsuario.Estado = reader["estado"].ToString();
                            oUsuario.DigitoVerificador = reader["digitoVerificador"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw new EXCEPCIONES.DALExcepcion(ex.Message);
                }
                return oUsuario;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ValidarUsuario(String usuario, String password)
        {
            int resultadoValidacion = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT [idUsuario] FROM tbl_Usuario WHERE usuario=@Usuario AND password=@Password", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@Usuario", usuario);
                        cmdSelect.Parameters.AddWithValue("@Password", password);
                        resultadoValidacion = (int)cmdSelect.ExecuteScalar();
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
        public List<Usuario> ObtenerTablaUsuario()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Usuario", con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario oUsuario = new Usuario();
                                oUsuario.IdUsuario = reader["idUsuario"].ToString();
                                oUsuario.NombreApellido = reader["nombreApellido"].ToString();
                                oUsuario.FechaNacimiento = reader["fechaNacimiento"].ToString();
                                oUsuario.CategoriaMoto = reader["categoriaMoto"].ToString();
                                oUsuario.usuario = reader["usuario"].ToString();
                                oUsuario.Password = reader["password"].ToString();
                                oUsuario.Email = reader["email"].ToString();
                                oUsuario.Estado = reader["estado"].ToString();
                                oUsuario.DigitoVerificador = reader["digitoVerificador"].ToString();
                                listadoUsuarios.Add(oUsuario);
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
                return listadoUsuarios;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Boolean ValidarExistenciaUsuario(String usuario)
        {
            int resultadoValidacion = 0;
            Boolean resultado;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT [idUsuario] FROM tbl_Usuario WHERE usuario=@Usuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@Usuario", usuario);
                        resultadoValidacion = (int)cmdSelect.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
                //VALIDO EXISTENCIA
                if (!(resultadoValidacion == 0))
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarios"></param>
        public void InsertarUsuarioDesdeBackup(List<Usuario> listaUsuarios)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdDelete = new SqlCommand("DELETE FROM [MotoPoint].[dbo].[tbl_Usuario]", con))
                {
                    try
                    {
                        con.Open();
                        cmdDelete.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new SIS.EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }

                try
                {
                    con.Open();
                    foreach (Usuario element in listaUsuarios)
                    {
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO tbl_Usuario (idUsuario,nombreApellido,fechaNacimiento,categoriaMoto,usuario,password,email,estado,digitoVerificador) VALUES (@IdUsuario,@NombreApellido,@FechaNacimiento,@CategoriaMoto,@Usuario,@Password,@Email,@Estado,@DigitoVerificador)", con);

                        cmdInsert.Parameters.AddWithValue("@IdUsuario", element.IdUsuario);
                        cmdInsert.Parameters.AddWithValue("@NombreApellido", element.NombreApellido);
                        cmdInsert.Parameters.AddWithValue("@FechaNacimiento", element.FechaNacimiento);
                        cmdInsert.Parameters.AddWithValue("@CategoriaMoto", element.CategoriaMoto);
                        cmdInsert.Parameters.AddWithValue("@Usuario", element.usuario);
                        cmdInsert.Parameters.AddWithValue("@Password", element.Password);
                        cmdInsert.Parameters.AddWithValue("@Email", element.Email);
                        cmdInsert.Parameters.AddWithValue("@Estado", element.Estado);
                        cmdInsert.Parameters.AddWithValue("@DigitoVerificador", element.DigitoVerificador);

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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarios"></param>
        public void InsertarUsuarioHaseados(List<Usuario> listaUsuarios)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdDelete = new SqlCommand("DELETE FROM [MotoPoint].[dbo].[tbl_Usuario]", con))
                {
                    try
                    {
                        con.Open();
                        cmdDelete.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new SIS.EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }

                try
                {
                    con.Open();
                    foreach (Usuario element in listaUsuarios)
                    {
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO tbl_Usuario (idUsuario,nombreApellido,fechaNacimiento,categoriaMoto,usuario,password,email,estado,digitoVerificador) VALUES (@IdUsuario,@NombreApellido,@FechaNacimiento,@CategoriaMoto,@Usuario,@Password,@Email,@Estado,@DigitoVerificador)", con);

                        cmdInsert.Parameters.AddWithValue("@IdUsuario", element.IdUsuario);
                        cmdInsert.Parameters.AddWithValue("@NombreApellido", element.NombreApellido);
                        cmdInsert.Parameters.AddWithValue("@FechaNacimiento", element.FechaNacimiento);
                        cmdInsert.Parameters.AddWithValue("@CategoriaMoto", element.CategoriaMoto);
                        cmdInsert.Parameters.AddWithValue("@Usuario", element.usuario);
                        cmdInsert.Parameters.AddWithValue("@Password", element.Password);
                        cmdInsert.Parameters.AddWithValue("@Email", element.Email);
                        cmdInsert.Parameters.AddWithValue("@Estado", element.Estado);
                        cmdInsert.Parameters.AddWithValue("@DigitoVerificador", element.DigitoVerificador);

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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int ActualizarUsuarioPorId(Usuario usuario)
        {
            int resultadoValidacion = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand("UPDATE tbl_Usuario SET nombreApellido=@NombreApellido, fechaNacimiento=@FechaNacimiento, categoriaMoto=@CategoriaMoto, usuario=@Usuario, password=@Password, email=@Email, estado=@Estado, digitoVerificador=@DigitoVerificador WHERE usuario=@IdUsuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdUpdate.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmdUpdate.Parameters.AddWithValue("@NombreApellido", usuario.NombreApellido);
                        cmdUpdate.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmdUpdate.Parameters.AddWithValue("@CategoriaMoto", usuario.CategoriaMoto);
                        cmdUpdate.Parameters.AddWithValue("@Usuario", usuario.usuario);
                        cmdUpdate.Parameters.AddWithValue("@Password", usuario.Password);
                        cmdUpdate.Parameters.AddWithValue("@Email", usuario.Email);
                        cmdUpdate.Parameters.AddWithValue("@Estado", usuario.Estado);
                        cmdUpdate.Parameters.AddWithValue("@DigitoVerificador", usuario.DigitoVerificador);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarios"></param>
        public void InsertarUsuario(List<Usuario> listaUsuarios)
        {
            String conexString = ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString;
            string sqlQuery = "SELECT * FROM tbl_Usuario";
            SqlDataAdapter adaptador = new SqlDataAdapter(sqlQuery, conexString);
            DataSet ds = new DataSet();
            SqlCommandBuilder cb = new SqlCommandBuilder(adaptador);
            adaptador.UpdateCommand = cb.GetUpdateCommand();
            adaptador.InsertCommand = cb.GetInsertCommand();
            adaptador.DeleteCommand = cb.GetDeleteCommand();
            try
            {
                adaptador.Fill(ds, "Usuario");
                if ((ds.Tables["Usuario"].Rows.Count == 0))
                {
                    Usuario ColumnaVerificadora = listaUsuarios[0];
                    DataRow dr = ds.Tables["Usuario"].Rows.Add();
                    dr["idUsuario"] = ColumnaVerificadora.IdUsuario.ToString();
                    dr["nombreApellido"] = ColumnaVerificadora.NombreApellido.ToString();
                    dr["fechaNacimiento"] = ColumnaVerificadora.FechaNacimiento.ToString();
                    dr["categoriaMoto"] = ColumnaVerificadora.CategoriaMoto.ToString();
                    dr["usuario"] = ColumnaVerificadora.usuario.ToString();
                    dr["password"] = ColumnaVerificadora.Password.ToString();
                    dr["email"] = ColumnaVerificadora.Email.ToString();
                    dr["estado"] = ColumnaVerificadora.Estado.ToString();
                    dr["digitoVerificador"] = ColumnaVerificadora.DigitoVerificador.ToString();
                }
                else
                {
                    IEnumerable<DataRow> sequence = ds.Tables["Usuario"].AsEnumerable();
                    IEnumerator<DataRow> enu = sequence.GetEnumerator();

                    while (enu.MoveNext())
                    {
                        int IntEnu = (int)enu.Current[0];
                        if ((IntEnu == 1))
                        {
                            enu.Current[1] = listaUsuarios[0].usuario;
                            enu.Current[2] = listaUsuarios[0].NombreApellido;
                            enu.Current[3] = listaUsuarios[0].FechaNacimiento;
                            enu.Current[4] = listaUsuarios[0].CategoriaMoto;
                            enu.Current[5] = listaUsuarios[0].Password;
                            enu.Current[6] = listaUsuarios[0].Email;
                            enu.Current[7] = listaUsuarios[0].Estado;
                            enu.Current[8] = listaUsuarios[0].DigitoVerificador;
                        }

                    }

                }

                int posicionUltimo = listaUsuarios.Count;
                posicionUltimo = (posicionUltimo - 1);
                Usuario oUsuario2 = listaUsuarios[posicionUltimo];
                DataRow dr2 = ds.Tables["Usuario"].NewRow();
                dr2["idUsuario"] = oUsuario2.IdUsuario.ToString();
                dr2["nombreApellido"] = oUsuario2.NombreApellido.ToString();
                dr2["fechaNacimiento"] = oUsuario2.FechaNacimiento.ToString();
                dr2["categoriaMoto"] = oUsuario2.CategoriaMoto.ToString();
                dr2["usuario"] = oUsuario2.usuario.ToString();
                dr2["password"] = oUsuario2.Password.ToString();
                dr2["email"] = oUsuario2.Email.ToString();
                dr2["estado"] = oUsuario2.Estado.ToString();
                dr2["digitoVerificador"] = oUsuario2.DigitoVerificador.ToString();
                ds.Tables["Usuario"].Rows.Add(dr2);
                adaptador.Update(ds, "Usuario");
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.DALExcepcion(ex.Message);
            }

        }
    }
}
