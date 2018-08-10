using System;
using System.Collections.Generic;

namespace SIS.BUSINESS
{
    /// <summary>
    /// 
    /// </summary>
    public interface INegBackup
    {
        // ### EXPORTAR ###
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ExportarAArchivoUsuario(string ruta, string delim);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="ruta"></param>
       /// <param name="delim"></param>
        void ExportarAArchivoBitacora(string ruta, string delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ExportarAArchivoUsuarioGrupo(string ruta, string delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ExportarAArchivoGrupo(string ruta, string delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ExportarAArchivoGrupoPermisos(string ruta, string delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ExportarAArchivoMultiIdioma(string ruta, string delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ExportarAArchivoPermisos(string ruta, string delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoUsuario(string ruta, Char delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoBitacora(string ruta, Char delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoGrupo(string ruta, Char delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoGrupoPermiso(string ruta, Char delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoPermiso(string ruta, Char delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoMultiIdioma(string ruta, Char delim);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="delim"></param>
        void ImportarDesdeArchivoUsuarioGrupo(string ruta, Char delim);
        // ##### INSERT EN BD #####
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarios"></param>
        void InsertarUsuarioDesdeBackup(List<ENTIDAD.Usuario> listaUsuarios);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaEventos"></param>
        void InsertarBitacoraDesdeBackup(List<ENTIDAD.Bitacora> listaEventos);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaGrupo"></param>
        void InsertarGrupoDesdeBackup(List<ENTIDAD.Grupo> listaGrupo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaGrupoPermiso"></param>
        void InsertarGrupoPermisoDesdeBackup(List<ENTIDAD.GrupoPermiso> listaGrupoPermiso);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaPermiso"></param>
        void InsertarPermisoDesdeBackup(List<ENTIDAD.Permiso> listaPermiso);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaMultiIdioma"></param>
        void InsertarMultiIdiomaDesdeBackup(List<ENTIDAD.MultiIdioma> listaMultiIdioma);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuarioGrupo"></param>
        void InsertarUsuarioGrupoDesdeBackup(List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo);
    }
}
