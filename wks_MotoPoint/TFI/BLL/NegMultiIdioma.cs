using System;
using System.Collections.Generic;

namespace SIS.BUSINESS
{
    /// <summary>
    /// FacadeMultiIdioma | https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class NegMultiIdioma : INegMultiIdioma
    {
        /// <summary>
        /// 
        /// </summary>
        private ENTIDAD.Usuario unUsuarioField;
        /// <summary>
        /// 
        /// </summary>
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public List<ENTIDAD.MultiIdioma> ObtenerTablaMultiIdioma(string idioma)
        {
            List<ENTIDAD.MultiIdioma> listaMultiIdioma = new List<ENTIDAD.MultiIdioma>(new ENTIDAD.MultiIdioma[] { });

            DATOS.DALMultiIdioma oDalMultiIdioma = new DATOS.DALMultiIdioma();

            try
            {
                listaMultiIdioma = oDalMultiIdioma.ObtenerTablaMultiIdioma(idioma);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(UnUsuario.IdUsuario, oExBLL);
            }

            return listaMultiIdioma;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ENTIDAD.MultiIdioma> ObtenerIdiomasDisponibles()
        {
            List<ENTIDAD.MultiIdioma> listaIdiomas = new List<ENTIDAD.MultiIdioma>(new ENTIDAD.MultiIdioma[] { });

            DATOS.DALMultiIdioma oDalMultiIdioma = new DATOS.DALMultiIdioma();

            try
            {
                listaIdiomas = oDalMultiIdioma.IdiomasDisponibles();
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(UnUsuario.IdUsuario, oExBLL);
            }

            return listaIdiomas;
        }
        /// <summary>
        /// 
        /// </summary>
        public ENTIDAD.Usuario UnUsuario
        {
            get
            {
                return unUsuarioField;
            }
            set
            {
                unUsuarioField = value;
            }
        }
    }
}
