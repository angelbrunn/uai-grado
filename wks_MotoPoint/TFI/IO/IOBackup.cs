using System;
using System.Collections.Generic;
using System.IO;


namespace SIS.ESCRITURA
{
    /// <summary>
    /// 
    /// </summary>
    public class IOBackup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.Usuario> LeerArchivoUsuario(string ruta, Char delim)
        {
            List<ENTIDAD.Usuario> lista = new List<ENTIDAD.Usuario>();

            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    
                    if (!String.IsNullOrEmpty(linea))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.Usuario oUsuario = new ENTIDAD.Usuario();
                            oUsuario.IdUsuario = System.Convert.ToString(vec[0]);
                            oUsuario.NombreApellido = System.Convert.ToString(vec[1]);
                            oUsuario.FechaNacimiento = System.Convert.ToString(vec[2]);
                            oUsuario.CategoriaMoto = System.Convert.ToString(vec[3]);
                            oUsuario.usuario = System.Convert.ToString(vec[4]);
                            oUsuario.Password = System.Convert.ToString(vec[5]);
                            oUsuario.Estado = System.Convert.ToString(vec[6]);
                            oUsuario.DigitoVerificador = System.Convert.ToString(vec[7]);
                            lista.Add(oUsuario);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.Bitacora> LeerArchivoBitacora(string ruta, Char delim)
        {
            List<ENTIDAD.Bitacora> lista = new List<ENTIDAD.Bitacora>();
            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
                            oBitacora.IdEvento = System.Convert.ToInt32(vec[0]);
                            oBitacora.IdUsuario = System.Convert.ToString(vec[1]);
                            oBitacora.Descripcion = System.Convert.ToString(vec[2]);
                            oBitacora.Fecha = System.Convert.ToString(vec[3]);
                            lista.Add(oBitacora);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.Grupo> LeerArchivoGrupo(string ruta, Char delim)
        {
            List<ENTIDAD.Grupo> lista = new List<ENTIDAD.Grupo>();

            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.Grupo oGrupo = new ENTIDAD.Grupo();
                            oGrupo.IdGrupo = System.Convert.ToInt32(vec[0]);
                            oGrupo.grupo = System.Convert.ToString(vec[1]);
                            oGrupo.Descripcion = System.Convert.ToString(vec[2]);
                            lista.Add(oGrupo);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }

            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.GrupoPermiso> LeerArchivoGrupoPermiso(string ruta, Char delim)
        {
            List<ENTIDAD.GrupoPermiso> lista = new List<ENTIDAD.GrupoPermiso>();

            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.GrupoPermiso oGrupoPermiso = new ENTIDAD.GrupoPermiso();
                            oGrupoPermiso.IdGrupo = System.Convert.ToInt32(vec[0]);
                            oGrupoPermiso.IdPermiso = System.Convert.ToInt32(vec[1]);
                            lista.Add(oGrupoPermiso);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }

            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.Permiso> LeerArchivoPermiso(string ruta, Char delim)
        {
            List<ENTIDAD.Permiso> lista = new List<ENTIDAD.Permiso>();

            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    if ((!String.IsNullOrEmpty(linea)))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.Permiso oPermiso = new ENTIDAD.Permiso();
                            oPermiso.IdPermiso = System.Convert.ToInt32(vec[0]);
                            oPermiso.Descripcion = System.Convert.ToString(vec[1]);
                            lista.Add(oPermiso);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }

            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.UsuarioGrupo> LeerArchivoUsuarioGrupo(string ruta, Char delim)
        {
            List<ENTIDAD.UsuarioGrupo> lista = new List<ENTIDAD.UsuarioGrupo>();

            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.UsuarioGrupo oUsuarioGrupo = new ENTIDAD.UsuarioGrupo();
                            oUsuarioGrupo.IdUsuario = System.Convert.ToInt32(vec[0]);
                            oUsuarioGrupo.IdGrupo = System.Convert.ToInt32(vec[1]);
                            lista.Add(oUsuarioGrupo);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }

            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public List<ENTIDAD.MultiIdioma> LeerArchivoMultiIdioma(string ruta, Char delim)
        {
            List<ENTIDAD.MultiIdioma> lista = new List<ENTIDAD.MultiIdioma>();

            try
            {
                string linea = "";
                StreamReader sr = new StreamReader(ruta);
                int contador = 0;
                do
                {
                    linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        if (contador > 0)
                        {
                            string[] vec = linea.Split(delim);
                            ENTIDAD.MultiIdioma oMultiIdioma = new ENTIDAD.MultiIdioma();
                            oMultiIdioma.Componente = System.Convert.ToString(vec[0]);
                            oMultiIdioma.IKey = System.Convert.ToString(vec[1]);
                            oMultiIdioma.Value = System.Convert.ToString(vec[2]);
                            lista.Add(oMultiIdioma);
                        }
                    }

                    contador = contador + 1;
                }
                while (!String.IsNullOrEmpty(linea));
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }

            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaUsuario"></param>
        public void EscribirArchivoUsuario(string ruta, string delim, List<ENTIDAD.Usuario> listaUsuario)
        {

            // idUsuario;usuario;password;legajo;idioma;digitoVerificador
            string cabecera = "idUsuario;usuario;password;legajo;idioma;digitoVerificador";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<ENTIDAD.Usuario> enumC = listaUsuario.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.IdUsuario.ToString() + delim + enumC.Current.NombreApellido + delim + enumC.Current.FechaNacimiento + delim + enumC.Current.CategoriaMoto + enumC.Current.usuario
               + delim + enumC.Current.Password + delim + delim + enumC.Current.Estado + delim + enumC.Current.DigitoVerificador;

                sw.WriteLine(linea);
            }
            sw.Close();
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaEventos"></param>
        public void EscribirArchivoBitacora(string ruta, string delim, List<ENTIDAD.Bitacora> listaEventos)
        {
            // idEvento;idUsuario;descripcion;fecha
            string cabecera = "idEvento;idUsuario;descripcion;fecha";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<SIS.ENTIDAD.Bitacora> enumC = listaEventos.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.IdEvento.ToString() + delim + enumC.Current.IdUsuario.ToString()
               + delim + enumC.Current.Descripcion.ToString() + delim + enumC.Current.Fecha.ToString();

                sw.WriteLine(linea);
            }
            sw.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaUsuarioGrupo"></param>
        public void EscribirArchivoUsuarioGrupo(string ruta, string delim, List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo)
        {
            // idUsuario;idGrupo
            string cabecera = "idUsuario;idGrupo";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<ENTIDAD.UsuarioGrupo> enumC = listaUsuarioGrupo.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.IdUsuario.ToString() + delim + enumC.Current.IdGrupo.ToString();
                sw.WriteLine(linea);
            }
            sw.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaGrupo"></param>
        public void EscribirArchivoGrupo(string ruta, string delim, List<ENTIDAD.Grupo> listaGrupo)
        {

            // idUsuario;idGrupo
            string cabecera = "idGrupo;grupo;descripcion";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<ENTIDAD.Grupo> enumC = listaGrupo.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.IdGrupo.ToString() + delim + enumC.Current.grupo.ToString() + delim + enumC.Current.Descripcion.ToString();
                sw.WriteLine(linea);
            }
            sw.Close();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaGrupoPermiso"></param>
        public void EscribirArchivoGrupoPermiso(string ruta, string delim, List<ENTIDAD.GrupoPermiso> listaGrupoPermiso)
        {
            string cabecera = "idGrupo;idPermiso";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<ENTIDAD.GrupoPermiso> enumC = listaGrupoPermiso.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.IdGrupo.ToString() + delim + enumC.Current.IdPermiso.ToString();
                sw.WriteLine(linea);
            }
            sw.Close();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaPermiso"></param>
        public void EscribirArchivoPermiso(string ruta, string delim, List<ENTIDAD.Permiso> listaPermiso)
        {

            string cabecera = "idPermiso;descripcion";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<ENTIDAD.Permiso> enumC = listaPermiso.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.IdPermiso.ToString() + delim + enumC.Current.Descripcion.ToString();
                sw.WriteLine(linea);
            }
            sw.Close();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        /// <param name="listaPermiso"></param>
        public void EscribirArchivoMultiIdioma(string ruta, string delim, List<ENTIDAD.MultiIdioma> listaPermiso)
        {

            string cabecera = "componente;idiomaEspanol;idiomaIngles";

            StreamWriter sw = new StreamWriter(ruta);
            sw.WriteLine(cabecera);
            string linea;

            IEnumerator<ENTIDAD.MultiIdioma> enumC = listaPermiso.GetEnumerator();
            while ((enumC.MoveNext()))
            {
                linea = enumC.Current.Componente.ToString() + delim + enumC.Current.IKey.ToString() + delim + enumC.Current.Value.ToString();
                sw.WriteLine(linea);
            }
            sw.Close();

        }
    }
}
