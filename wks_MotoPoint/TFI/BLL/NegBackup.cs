using System;
using System.Collections.Generic;
using System.IO;

namespace SIS.BUSINESS
{
    /// <summary>
    /// FacadeBackup | https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class NegBackup : INegBackup
    {
        /// <summary>
        /// 
        /// </summary>
        private INegMultiUsuario interfazNegMultiUsuario = new NegMultiUsuario();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoUsuario(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<SIS.ENTIDAD.Usuario> listaUsuario = new List<ENTIDAD.Usuario>();
            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();

            try
            {
                listaUsuario = oDalUsuario.ObtenerTablaUsuario();
                oIOBackup.EscribirArchivoUsuario(ruta, delim, listaUsuario);
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoBitacora(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Bitacora> listaEventos = new List<ENTIDAD.Bitacora>();
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            try
            {
                listaEventos = oDalBitacora.ObtenerEventos();
                oIOBackup.EscribirArchivoBitacora(ruta, delim, listaEventos);
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoUsuarioGrupo(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo = new List<ENTIDAD.UsuarioGrupo>();
            DATOS.DALUsuarioGrupo oDalUsuarioGrupo = new DATOS.DALUsuarioGrupo();

            try
            {
                listaUsuarioGrupo = oDalUsuarioGrupo.ObtenerTablaUsuarioGrupo();
                oIOBackup.EscribirArchivoUsuarioGrupo(ruta, delim, listaUsuarioGrupo);
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoGrupo(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Grupo> listaGrupo = new List<ENTIDAD.Grupo>();
            DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();

            try
            {
                listaGrupo = oDalGrupo.ObtenerGrupos();
                oIOBackup.EscribirArchivoGrupo(ruta, delim, listaGrupo);
            }
            catch (IOException ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoGrupoPermisos(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.GrupoPermiso> listaGrupoPermiso = new List<ENTIDAD.GrupoPermiso>();
            DATOS.DALGrupoPermiso oDalGrupoPermiso = new DATOS.DALGrupoPermiso();

            try
            {
                listaGrupoPermiso = oDalGrupoPermiso.ObtenerGrupoPermiso();
                oIOBackup.EscribirArchivoGrupoPermiso(ruta, delim, listaGrupoPermiso);
            }
            catch (IOException ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoPermisos(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Permiso> listaPermiso = new List<ENTIDAD.Permiso>();
            DATOS.DALPermiso oDalPermiso = new DATOS.DALPermiso();

            try
            {
                listaPermiso = oDalPermiso.ObtenerPermiso();
                oIOBackup.EscribirArchivoPermiso(ruta, delim, listaPermiso);
            }
            catch (IOException ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ExportarAArchivoMultiIdioma(string ruta, string delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.MultiIdioma> listaMultiIdioma = new List<ENTIDAD.MultiIdioma>();
            DATOS.DALMultiIdioma oDalMultiIdioma = new DATOS.DALMultiIdioma();

            try
            {
                listaMultiIdioma = oDalMultiIdioma.ObtenerTablaMultiIdiomaAll();
                oIOBackup.EscribirArchivoMultiIdioma(ruta, delim, listaMultiIdioma);
            }
            catch (IOException ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoUsuario(string ruta, Char delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Usuario> listaUsuario = new List<ENTIDAD.Usuario>();

            listaUsuario = oIOBackup.LeerArchivoUsuario(ruta, delim);

            this.InsertarUsuarioDesdeBackup(listaUsuario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoBitacora(string ruta, Char delim)
        {

            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Bitacora> listaBitacora = new List<ENTIDAD.Bitacora>();

            listaBitacora = oIOBackup.LeerArchivoBitacora(ruta, delim);

            this.InsertarBitacoraDesdeBackup(listaBitacora);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoGrupo(string ruta, Char delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Grupo> listaGrupo = new List<ENTIDAD.Grupo>();

            listaGrupo = oIOBackup.LeerArchivoGrupo(ruta, delim);

            this.InsertarGrupoDesdeBackup(listaGrupo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoGrupoPermiso(string ruta, Char delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.GrupoPermiso> listaGrupoPermiso = new List<ENTIDAD.GrupoPermiso>();

            listaGrupoPermiso = oIOBackup.LeerArchivoGrupoPermiso(ruta, delim);

            this.InsertarGrupoPermisoDesdeBackup(listaGrupoPermiso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoPermiso(string ruta, Char delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.Permiso> listaPermiso = new List<ENTIDAD.Permiso>();

            listaPermiso = oIOBackup.LeerArchivoPermiso(ruta, delim);

            this.InsertarPermisoDesdeBackup(listaPermiso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoMultiIdioma(string ruta, Char delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.MultiIdioma> listaMultiIdioma = new List<ENTIDAD.MultiIdioma>();

            listaMultiIdioma = oIOBackup.LeerArchivoMultiIdioma(ruta, delim);

            this.InsertarMultiIdiomaDesdeBackup(listaMultiIdioma);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        public void ImportarDesdeArchivoUsuarioGrupo(string ruta, Char delim)
        {
            ESCRITURA.IOBackup oIOBackup = new ESCRITURA.IOBackup();
            List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo = new List<ENTIDAD.UsuarioGrupo>();

            listaUsuarioGrupo = oIOBackup.LeerArchivoUsuarioGrupo(ruta, delim);

            this.InsertarUsuarioGrupoDesdeBackup(listaUsuarioGrupo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarios"></param>
        public void InsertarUsuarioDesdeBackup(List<ENTIDAD.Usuario> listaUsuarios)
        {
            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();

            oDalUsuario.InsertarUsuarioDesdeBackup(listaUsuarios);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaEventos"></param>
        public void InsertarBitacoraDesdeBackup(List<ENTIDAD.Bitacora> listaEventos)
        {
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            oDalBitacora.InsertarBitacoraDesdeBackup(listaEventos);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaGrupo"></param>
        public void InsertarGrupoDesdeBackup(List<ENTIDAD.Grupo> listaGrupo)
        {
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            oDalBitacora.InsertarGrupoDesdeBackup(listaGrupo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaGrupoPermiso"></param>
        public void InsertarGrupoPermisoDesdeBackup(List<ENTIDAD.GrupoPermiso> listaGrupoPermiso)
        {
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            oDalBitacora.InsertarGrupoPermisoDesdeBackup(listaGrupoPermiso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaMultiIdioma"></param>
        public void InsertarMultiIdiomaDesdeBackup(List<ENTIDAD.MultiIdioma> listaMultiIdioma)
        {
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            oDalBitacora.InsertarMultiIdiomaDesdeBackup(listaMultiIdioma);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaPermiso"></param>
        public void InsertarPermisoDesdeBackup(List<ENTIDAD.Permiso> listaPermiso)
        {
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            oDalBitacora.InsertarPermisoDesdeBackup(listaPermiso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarioGrupo"></param>
        public void InsertarUsuarioGrupoDesdeBackup(List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo)
        {
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();

            oDalBitacora.InsertarUsuarioGrupoDesdeBackup(listaUsuarioGrupo);
        }
    }
}
