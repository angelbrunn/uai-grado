using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace SIS.BUSINESS
{
    /// <summary>
    ///  FacadeNegocio | https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class NegNegocio : INegNegocio
    {
        //ESTE SERVICIO WEB DA SERVICIO DE COBRO
        BLL.localhost.Service ws_001 = new BLL.localhost.Service();
        /// <summary>
        /// 
        /// </summary>
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        public void RealizarCobroMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular)
        {
            Boolean realizarPagoResultado;
            realizarPagoResultado = ws_001.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoriaMoto> ObtenerCategoriaMoto()
        {
            List<CategoriaMoto> listadoCategoriaMoto = new List<CategoriaMoto>();
            DATOS.DALCategoriaMoto oDalCategoriaMoto = new DATOS.DALCategoriaMoto();
            listadoCategoriaMoto = oDalCategoriaMoto.ObtenerTablaCategoriaMoto();
            return listadoCategoriaMoto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int RegistrarMembresiaParaUsuario(string idMembresia, string idUsuario)
        {
            int resultadoValidacion = 1;
            MembresiaUsuario oMembresiaUsuario = new MembresiaUsuario();
            oMembresiaUsuario.IdMembresia = idMembresia;
            oMembresiaUsuario.IdUsuario = idUsuario;

            try
            {
                resultadoValidacion = 0;
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.InsertarMembresiaParaUsuario(oMembresiaUsuario);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaSegunTipo(string tipoMembresia)
        {
            int idMembresia = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresia = oDalMembresia.ObtenerMembresiaSegunTipo(tipoMembresia);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresia;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaPrecio(string idMembresia)
        {
            int idMembresiaPrecio = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresiaPrecio = oDalMembresia.ObtenerMembresiaPrecio(idMembresia);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresiaPrecio;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombreApellido"></param>
        /// <param name="descipcion"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        public int RegistrarPagoUsuario(string idUsuario, string nombreApellido, string descipcion, string monto)
        {
            int resultadoValidacion = 1;

            PagoUsuario oPagoUsuario = new PagoUsuario();
            oPagoUsuario.IdUsuario = idUsuario;
            oPagoUsuario.NombreApellido = nombreApellido;
            oPagoUsuario.Descripcion = descipcion;
            oPagoUsuario.Monto = monto;
            string fechaPago = DateTime.Now.ToString();
            oPagoUsuario.FechaPago = fechaPago;

            try
            {
                DATOS.DALPago oDalPago = new DATOS.DALPago();
                //NEGOCIO - OBTENER ULTIMO NUMERO DE ORDER 
                int numOrden = oDalPago.ObtenerUltimoNumeroOrden();
                int NumeroOrden = numOrden + 1;
                oPagoUsuario.IdNumeroOrden = NumeroOrden;
                //NEGOCIO - GRABAR PAGO DEL CLIENTE
                List<PagoUsuario> listaPagoUsuario = new List<PagoUsuario>();
                listaPagoUsuario.Add(oPagoUsuario);
                resultadoValidacion = System.Convert.ToInt16(NumeroOrden);
                oDalPago.InsertarPago(listaPagoUsuario);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="numeroOrden"></param>
        /// <param name="destinatarioEmail"></param>
        /// <param name="estadoPago"></param>
        /// <returns></returns>
        public bool EnviarTicketConfirmacionPago(string idUsuario, int numeroOrden, string destinatarioEmail, string estadoPago)
        {
            bool estado = false;
            string IdSys = "SYS";

            //NEGOCIO - OBTENER PAGO REALIZADO POR EL CLIENTE
            PagoUsuario oPagoUsuario = new PagoUsuario();
            DATOS.DALPago oDalPago = new DATOS.DALPago();
            oPagoUsuario = oDalPago.ObtenerPagoUsuarioPorNumeroOrden(numeroOrden.ToString());


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("motopointserviciocontacto@gmail.com");
            mail.To.Add(destinatarioEmail);

            mail.Subject = "Sistema de cobro - MOTOPOINT";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("                       MOTOPOINT                          ");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("DIRECCION: xxxxxxxxxxxxxxxxxx");
            sb.AppendLine("EMAIL: motopointserviciocontacto@gmail.com");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("MONTO: " + oPagoUsuario.Monto.ToString());
            sb.AppendLine("FECHA: " + oPagoUsuario.FechaPago.ToString());
            sb.AppendLine("NUMERO ORDE: " + oPagoUsuario.IdNumeroOrden.ToString());
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("ESTADO: " + estadoPago);
            sb.AppendLine("-------------------------------------------------------------------------");

            mail.Body = sb.ToString(); ;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            SmtpServer.EnableSsl = true;

            try
            {
                estado = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                estado = false;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }

            return estado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int ObtenerCodigoMembresiaUsuario(string idUsuario)
        {
            int idMembresia = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresia = oDalMembresia.ObtenerMembresiaUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresia;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public int RegistrarMembresiaUsuario(string idUsuario, string idMembresia)
        {
            int resultadoValidacion = 1;
            try
            {
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.InsertarMembresiaUsuario(idUsuario, idMembresia);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public int ActualizarMembresiaUsuario(string idUsuario, string idMembresia)
        {
            int resultadoValidacion = 1;
            try
            {
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.ActualizarMembresiaUsuario(idUsuario, idMembresia);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
    }
}
