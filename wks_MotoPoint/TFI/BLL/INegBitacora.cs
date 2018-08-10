using System.Collections.Generic;

namespace SIS.BUSINESS
{
    /// <summary>
    /// 
    /// </summary>
    public interface INegBitacora
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oBKP"></param>
        void RegistrarEnBitacora_BKP(string usuarioId, EXCEPCIONES.BKPException oBKP);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oBLL"></param>
        void RegistrarEnBitacora_BLL(string usuarioId, EXCEPCIONES.BLLExcepcion oBLL);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oDAL"></param>
        void RegistrarEnBitacora_DAL(string usuarioId, EXCEPCIONES.DALExcepcion oDAL);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oIO"></param>
        void RegistrarEnBitacora_IO(string usuarioId, EXCEPCIONES.IOException oIO);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oSEG"></param>
        void RegistrarEnBitacora_SEG(string usuarioId, EXCEPCIONES.SEGExcepcion oSEG);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oUI"></param>
        void RegistrarEnBitacora_UI(string usuarioId, EXCEPCIONES.UIExcepcion oUI);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ENTIDAD.Bitacora> ObtenerEventosBitacora();
    }
}
