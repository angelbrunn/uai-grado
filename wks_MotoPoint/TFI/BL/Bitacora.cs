using System;
using SIS.DATOS;
using System.Collections.Generic;

namespace SIS.BIT
{
    /// <summary>
    /// 
    /// </summary>
    public class Bitacora
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int ObtenerUltimoId()
        {
            int ultimoId=1;
            DALBitacora oDalBitacora = new DALBitacora();
            try
            {
                ultimoId = oDalBitacora.ObtenerUltimoId();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }
            return ultimoId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioI"></param>
        /// <param name="oBKPExc"></param>
        public void RegistrarEnBitacora_BKP(string usuarioI, SIS.EXCEPCIONES.BKPException oBKPExc)
        {
            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
            // Guardo Usuario
            oBitacora.IdUsuario = usuarioI;
            // Se agrega la fecha del evento.
            oBitacora.Fecha = DateTime.Now.ToString("HH:mm:ss");
            oBitacora.Descripcion = "BKPException:" + oBKPExc.Message;

            try
            {
                // Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.IdEvento = (this.ObtenerUltimoId() + 1);

                // Realizo la insercion en la base de datos por medio de DALBitacora
                // si hay una excepcion cualquier que no me permite ingresar el resgistro
                // llamo a la insercion en el archivo local dentro de IOBitacora.
                DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();


                oDalBitacora.RegistrarEnBitacoraBD(oBitacora);
            }
            catch (Exception ex)
            {
                SIS.ESCRITURA.IOBitacora oIOBitacora = new SIS.ESCRITURA.IOBitacora();
                oIOBitacora.RegistrarEnBitacoraIO(oBitacora);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioI"></param>
        /// <param name="oBLLExc"></param>
        public void RegistrarEnBitacora_BLL(string usuarioI, SIS.EXCEPCIONES.BLLExcepcion oBLLExc)
        {
            
            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
            // Guardo Usuario
            oBitacora.IdUsuario = usuarioI;
            // Se agrega la fecha del evento.
            oBitacora.Fecha = DateTime.Now.ToString("HH:mm:ss");
            oBitacora.Descripcion = "BLLExcepcion:" + oBLLExc.Message;

            try
            {
                // Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.IdEvento = (this.ObtenerUltimoId() + 1);

                // Realizo la insercion en la base de datos por medio de DALBitacora
                // si hay una excepcion cualquier que no me permite ingresar el resgistro
                // llamo a la insercion en el archivo local dentro de IOBitacora.
                DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
                oDalBitacora.RegistrarEnBitacoraBD(oBitacora);
            }
            catch (Exception ex)
            {
                ESCRITURA.IOBitacora oIOBitacora = new ESCRITURA.IOBitacora();
                oIOBitacora.RegistrarEnBitacoraIO(oBitacora);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioI"></param>
        /// <param name="oDALExc"></param>
        public void RegistrarEnBitacora_DAL(string usuarioI, SIS.EXCEPCIONES.DALExcepcion oDALExc)
        {
            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
            // Guardo Usuario
            oBitacora.IdUsuario = usuarioI;
            // Se agrega la fecha del evento.
            oBitacora.Fecha = DateTime.Now.ToString("HH:mm:ss");
            oBitacora.Descripcion = "DALExcepcion:" + oDALExc.Message;

            try
            {
                // Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.IdEvento = (this.ObtenerUltimoId() + 1);

                // Realizo la insercion en la base de datos por medio de DALBitacora
                // si hay una excepcion cualquier que no me permite ingresar el resgistro
                // llamo a la insercion en el archivo local dentro de IOBitacora.
                DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
                oDalBitacora.RegistrarEnBitacoraBD(oBitacora);
            }
            catch (Exception ex)
            {
                ESCRITURA.IOBitacora oIOBitacora = new ESCRITURA.IOBitacora();
                oIOBitacora.RegistrarEnBitacoraIO(oBitacora);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioI"></param>
        /// <param name="oIOExc"></param>
        public void RegistrarEnBitacora_IO(string usuarioI, SIS.EXCEPCIONES.IOException oIOExc)
        {
            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
            // Guardo Usuario
            oBitacora.IdUsuario = usuarioI;
            // Se agrega la fecha del evento.
            oBitacora.Fecha = DateTime.Now.ToString("HH:mm:ss");
            oBitacora.Descripcion = "IOException:" + oIOExc.Message;

            try
            {
                // Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.IdEvento = (this.ObtenerUltimoId() + 1);

                // Realizo la insercion en la base de datos por medio de DALBitacora
                // si hay una excepcion cualquier que no me permite ingresar el resgistro
                // llamo a la insercion en el archivo local dentro de IOBitacora.
                DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
                oDalBitacora.RegistrarEnBitacoraBD(oBitacora);
            }
            catch (Exception ex)
            {
                ESCRITURA.IOBitacora oIOBitacora = new ESCRITURA.IOBitacora();
                oIOBitacora.RegistrarEnBitacoraIO(oBitacora);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioI"></param>
        /// <param name="oSEGExc"></param>
        public void RegistrarEnBitacora_SEG(string usuarioI, SIS.EXCEPCIONES.SEGExcepcion oSEGExc)
        {
            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
            // Guardo Usuario
            oBitacora.IdUsuario = usuarioI;
            // Se agrega la fecha del evento.
            oBitacora.Fecha = DateTime.Now.ToString("HH:mm:ss");
            oBitacora.Descripcion = "SEGExcepcion:" + oSEGExc.Message;

            try
            {
                // Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.IdEvento = (this.ObtenerUltimoId() + 1);

                // Realizo la insercion en la base de datos por medio de DALBitacora
                // si hay una excepcion cualquier que no me permite ingresar el resgistro
                // llamo a la insercion en el archivo local dentro de IOBitacora.
                DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
                oDalBitacora.RegistrarEnBitacoraBD(oBitacora);
            }
            catch (Exception ex)
            {
                ESCRITURA.IOBitacora oIOBitacora = new ESCRITURA.IOBitacora();
                oIOBitacora.RegistrarEnBitacoraIO(oBitacora);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioI"></param>
        /// <param name="oUIExc"></param>
        public void RegistrarEnBitacora_UI(string usuarioI, SIS.EXCEPCIONES.UIExcepcion oUIExc)
        {
            ENTIDAD.Bitacora oBitacora = new ENTIDAD.Bitacora();
            // Guardo Usuario
            oBitacora.IdUsuario = usuarioI;
            // Se agrega la fecha del evento.
            oBitacora.Fecha = DateTime.Now.ToString("HH:mm:ss");
            oBitacora.Descripcion = "UIExcepcion:" + oUIExc.Message;

            try
            {
                // Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.IdEvento = (this.ObtenerUltimoId() + 1);

                // Realizo la insercion en la base de datos por medio de DALBitacora
                // si hay una excepcion cualquier que no me permite ingresar el resgistro
                // llamo a la insercion en el archivo local dentro de IOBitacora.
                DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
                oDalBitacora.RegistrarEnBitacoraBD(oBitacora);
            }
            catch (Exception ex)
            {
                ESCRITURA.IOBitacora oIOBitacora = new ESCRITURA.IOBitacora();
                oIOBitacora.RegistrarEnBitacoraIO(oBitacora);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SIS.ENTIDAD.Bitacora> ObtenerEventos()
        {
            List<ENTIDAD.Bitacora> listado = new List<ENTIDAD.Bitacora>();

            DALBitacora oDalBitacora = new DALBitacora();
            listado = oDalBitacora.ObtenerEventos();

            return listado;
        }
    }
}
