using System.Collections.Generic;

namespace SIS.BUSINESS
{
    /// <summary>
    /// 
    /// </summary>
    public interface INegMultiUsuario
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        void InsertarUsuario(ENTIDAD.Usuario oUsuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        void ActualizarUsuario(ENTIDAD.Usuario oUsuario);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int ObtenerIdParaUsuario();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        ENTIDAD.Usuario ObtenerUsuario(int idUsuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        ENTIDAD.Usuario ObtenerUsuarioPorEmail(string email);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        ENTIDAD.Usuario ObtenerUsuarioPorCategoriaMoto(int categoriaMoto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool ValidarExistenciaUsuario(string usuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        ENTIDAD.Grupo ObtenerGrupoPorId(int idGrupo);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ENTIDAD.Grupo> ObtenerGrupos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <returns></returns>
        string ObtenerDescripcionGrupoPorNombre(string nombreGrupo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <returns></returns>
        ENTIDAD.Grupo ObtenerGrupoPorNombre(string nombreGrupo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPermiso"></param>
        /// <returns></returns>
        ENTIDAD.Permiso ObtenerPermisoPorId(int idPermiso);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int Login(string usuario, string password);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool VerificarConsistenciaUsuarioBD();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool EnviarRecordatorioPassword(string destinatarioEmail, string contraseñaRecuperada);
    }
}
