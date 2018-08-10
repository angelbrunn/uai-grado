using System.Collections.Generic;

namespace SIS.BUSINESS
{
    /// <summary>
    /// 
    /// </summary>
    public class NegBitacora : INegBitacora
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oBKP"></param>
        public void RegistrarEnBitacora_BKP(string usuarioId, EXCEPCIONES.BKPException oBKP)
        {
            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            oBITBitacora.RegistrarEnBitacora_BKP(usuarioId, oBKP);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oBLL"></param>
        public void RegistrarEnBitacora_BLL(string usuarioId, EXCEPCIONES.BLLExcepcion oBLL)
        {
            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            oBITBitacora.RegistrarEnBitacora_BLL(usuarioId, oBLL);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oDAL"></param>
        public void RegistrarEnBitacora_DAL(string usuarioId, EXCEPCIONES.DALExcepcion oDAL)
        {
            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            oBITBitacora.RegistrarEnBitacora_DAL(usuarioId, oDAL);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oIO"></param>
        public void RegistrarEnBitacora_IO(string usuarioId, EXCEPCIONES.IOException oIO)
        {
            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            oBITBitacora.RegistrarEnBitacora_IO(usuarioId, oIO);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oSEG"></param>
        public void RegistrarEnBitacora_SEG(string usuarioId, EXCEPCIONES.SEGExcepcion oSEG)
        {
            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            oBITBitacora.RegistrarEnBitacora_SEG(usuarioId, oSEG);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="oUI"></param>
        public void RegistrarEnBitacora_UI(string usuarioId, EXCEPCIONES.UIExcepcion oUI)
        {
            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            oBITBitacora.RegistrarEnBitacora_UI(usuarioId, oUI);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ENTIDAD.Bitacora> ObtenerEventosBitacora()
        {
            List<ENTIDAD.Bitacora> listadoEventos = new List<ENTIDAD.Bitacora>();

            BIT.Bitacora oBITBitacora = new BIT.Bitacora();
            listadoEventos = oBITBitacora.ObtenerEventos();

            return listadoEventos;
        }
    }
}
