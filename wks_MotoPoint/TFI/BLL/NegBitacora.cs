using System.Collections.Generic;
using System.Data;

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
        IO.IHash interfazHash = new IO.Hash();
        /// <summary>
        /// 
        /// </summary>
        ESCRITURA.IOBitacora interfazIOBitacora = new ESCRITURA.IOBitacora();
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool VerificarConsistenciaBD()
        {
            bool estado = false;
            string IdDB = "DB";
            try
            {
                estado = interfazHash.VerificarConsistenciaBitacoraBD();
            }
            catch (EXCEPCIONES.SEGExcepcion ex)
            {
                BIT.Bitacora oBITBitacora = new BIT.Bitacora();
                oBITBitacora.RegistrarEnBitacora_SEG(IdDB,ex);
            }

            return estado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerLogSystem()
        {
            DataTable dt = null;
            string IdFile = "Error en lectura de log_System";
            try
            {
                dt = interfazIOBitacora.LeerLogSystem();
            }
            catch (EXCEPCIONES.SEGExcepcion ex)
            {
                BIT.Bitacora oBITBitacora = new BIT.Bitacora();
                oBITBitacora.RegistrarEnBitacora_SEG(IdFile, ex);
            }

            return dt;
        }
    }
}
