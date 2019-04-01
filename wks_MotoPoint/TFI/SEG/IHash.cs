﻿using System.Collections.Generic;

namespace SIS.SEG
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCadena"></param>
        /// <returns></returns>
        string GenerarSHA(string sCadena);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        string ObtenerHash(string cadena);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        /// <returns></returns>
        string ObtenerHashUsuario(ENTIDAD.Usuario oUsuario);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool VerificarConsistenciaUsuarioBD();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool VerificarConsistenciaBitacoraBD();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaUsuario"></param>
        /// <returns></returns>
        List<ENTIDAD.Usuario> CalcularHashTablaUsuario(List<ENTIDAD.Usuario> listaUsuario);
        /// <summary>
        /// 
        /// </summary>
        void CalcularHashTablaBitacora();
    }
}