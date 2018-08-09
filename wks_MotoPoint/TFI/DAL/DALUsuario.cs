﻿using SIS.ENTIDAD;
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
        public int ObtenerLegajoUsuario(int idUsuario)
        {
            int legajoUsuario = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                using (SqlCommand cmdSelect = new SqlCommand("SELECT legajo FROM tbl_Usuario WHERE idUsuario=@IdUsuario", con))
                {
                    try
                    {
                        con.Open();
                        cmdSelect.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        legajoUsuario = (int)cmdSelect.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw new EXCEPCIONES.DALExcepcion(ex.Message);
                    }
                }
            }
            return legajoUsuario;
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
                            oUsuario.usuario = reader["usuario"].ToString();
                            oUsuario.Password = reader["password"].ToString();
                            oUsuario.Legajo = reader["legajo"].ToString();
                            oUsuario.Idioma = reader["idioma"].ToString();
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
        public Usuario ObtenerUsuarioPorLegajo(String legajo)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MotoPoint"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM tbl_Usuario WHERE legajo=@Legajo", con);
                    cmdSelect.Parameters.AddWithValue("@Legajo", legajo);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oUsuario.IdUsuario = reader["idUsuario"].ToString();
                            oUsuario.usuario = reader["usuario"].ToString();
                            oUsuario.Password = reader["password"].ToString();
                            oUsuario.Legajo = reader["legajo"].ToString();
                            oUsuario.Idioma = reader["idioma"].ToString();
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
                                oUsuario.usuario = reader["usuario"].ToString();
                                oUsuario.Password = reader["password"].ToString();
                                oUsuario.Legajo = reader["legajo"].ToString();
                                oUsuario.Idioma = reader["idioma"].ToString();
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
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO tbl_Usuario (idUsuario,usuario,password,legajo,idioma,digitoVerificador) VALUES (@IdUsuario,@Usuario,@Password,@Legajo,@Idioma,@DigitoVerificador)", con);

                        cmdInsert.Parameters.AddWithValue("@IdUsuario", element.IdUsuario);
                        cmdInsert.Parameters.AddWithValue("@Usuario", element.usuario);
                        cmdInsert.Parameters.AddWithValue("@Password", element.Password);
                        cmdInsert.Parameters.AddWithValue("@Legajo", element.Legajo);
                        cmdInsert.Parameters.AddWithValue("@Idioma", element.Idioma);
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
                    dr["usuario"] = ColumnaVerificadora.usuario.ToString();
                    dr["password"] = ColumnaVerificadora.Password.ToString();
                    dr["legajo"] = ColumnaVerificadora.Legajo.ToString();
                    dr["idioma"] = ColumnaVerificadora.Idioma.ToString();
                    dr["digitoVerificador"] = ColumnaVerificadora.DigitoVerificador.ToString();
                }
                else
                {
                    // sobre escribir el regustro cuyo idUsuario=1 (digitos Verificadores verticales)
                    IEnumerable<DataRow> sequence = ds.Tables["Usuario"].AsEnumerable();
                    IEnumerator<DataRow> enu = sequence.GetEnumerator();
                    //IEnumerator<DataRow> enu = ds.Tables["Usuario"].Rows.GetEnumerator();

                    while (enu.MoveNext())
                    {
                        int IntEnu = (int)enu.Current[0];
                        if ((IntEnu == 1))
                        {
                            enu.Current[1] = listaUsuarios[0].usuario;
                            enu.Current[2] = listaUsuarios[0].Password;
                            enu.Current[3] = listaUsuarios[0].Legajo;
                            enu.Current[4] = listaUsuarios[0].Idioma;
                            enu.Current[5] = listaUsuarios[0].DigitoVerificador;
                        }

                    }

                }

                int posicionUltimo = listaUsuarios.Count;
                posicionUltimo = (posicionUltimo - 1);
                Usuario oUsuario2 = listaUsuarios[posicionUltimo];
                DataRow dr2 = ds.Tables["Usuario"].NewRow();
                dr2["idUsuario"] = oUsuario2.IdUsuario.ToString();
                dr2["usuario"] = oUsuario2.usuario.ToString();
                dr2["password"] = oUsuario2.Password.ToString();
                dr2["legajo"] = oUsuario2.Legajo.ToString();
                dr2["idioma"] = oUsuario2.Idioma.ToString();
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
/*
    
        Public Sub insertarUsuario(ByVal listaUsuarios As List(Of BE.SIS.ENTIDAD.Usuario))
            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Usuario"

            Dim adaptador As New SqlDataAdapter(sqlQuery, conexString)
            Dim ds As New DataSet
            Dim cb As New SqlCommandBuilder(adaptador)
            adaptador.UpdateCommand = cb.GetUpdateCommand
            adaptador.InsertCommand = cb.GetInsertCommand
            adaptador.DeleteCommand = cb.GetDeleteCommand

            Try
                adaptador.Fill(ds, "Usuario")

                If ds.Tables("Usuario").Rows.Count = 0 Then
                    Dim ColumnaVerificadora As BE.SIS.ENTIDAD.Usuario = listaUsuarios.Item(0)
                    Dim dr As DataRow = ds.Tables("Usuario").Rows.Add
                    dr("idUsuario") = ColumnaVerificadora.idUsuario.ToString
                    dr("usuario") = ColumnaVerificadora.usuario.ToString
                    dr("password") = ColumnaVerificadora.password.ToString
                    dr("legajo") = ColumnaVerificadora.legajo.ToString
                    dr("idioma") = ColumnaVerificadora.idioma.ToString
                    dr("digitoVerificador") = ColumnaVerificadora.digitoVerificador.ToString
                Else
                    'sobre escribir el regustro cuyo idUsuario=1 (digitos Verificadores verticales)

                    Dim enu As IEnumerator(Of DataRow) = ds.Tables("Usuario").Rows.GetEnumerator
                    While enu.MoveNext
                        If enu.Current.Item(0) = 1 Then
                            enu.Current.Item(1) = listaUsuarios.Item(0).usuario
                            enu.Current.Item(2) = listaUsuarios.Item(0).password
                            enu.Current.Item(3) = listaUsuarios.Item(0).legajo
                            enu.Current.Item(4) = listaUsuarios.Item(0).idioma
                            enu.Current.Item(5) = listaUsuarios.Item(0).digitoVerificador
                        End If

                    End While
                End If

                Dim posicionUltimo As Integer = listaUsuarios.Count
                posicionUltimo = posicionUltimo - 1
                Dim oUsuario2 As BE.SIS.ENTIDAD.Usuario = listaUsuarios.Item(posicionUltimo)
                Dim dr2 As DataRow = ds.Tables("Usuario").NewRow
                dr2("idUsuario") = CType(oUsuario2.idUsuario, Integer)
                dr2("usuario") = oUsuario2.usuario.ToString
                dr2("password") = oUsuario2.password.ToString
                dr2("legajo") = oUsuario2.legajo.ToString
                dr2("idioma") = oUsuario2.idioma.ToString
                dr2("digitoVerificador") = oUsuario2.digitoVerificador.ToString
                ds.Tables("Usuario").Rows.Add(dr2)

                adaptador.Update(ds, "Usuario")
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub


*/
