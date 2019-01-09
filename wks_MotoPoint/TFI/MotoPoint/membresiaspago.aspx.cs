using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Xml;
using SIS.ENTIDAD;

namespace MotoPoint
{
    /// <summary>
    /// 
    /// </summary>
    public partial class membresiaspago : System.Web.UI.Page
    {
        /// <summary>
        /// NEGOCIO
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// ARQ.BASE Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new SIS.BUSINESS.NegMultiUsuario();
        /// <summary>
        /// 
        /// </summary>
        string idUsuario;
        /// <summary>
        /// 
        /// </summary>
        string idMembresia;
        /// <summary>
        /// 
        /// </summary>
        string precioMembresia;
        /// <summary>
        /// 
        /// </summary>
        string tipoMembresia;
        /// <summary>
        /// 
        /// </summary>
        string codigoMembresia;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            idUsuario = Session["IdMembresia"].ToString();
            idMembresia = Session["UsuarioId"].ToString();
            precioMembresia = Session["valorMembresia"].ToString();
            tipoMembresia = Session["tipoMembresia"].ToString();
            codigoMembresia = Session["codigoMembresia"].ToString();
            txtMontoPagar.Text = precioMembresia;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            //NEGOCIO - VALIDO EL PAGO VIA WEBSERVICES
            var operacion = new localhost.Service();

            string numeroTarjeta = txtNumeroTarjeta.Text;
            string numeroSeguridad = txtCvc.Text;
            string fechaValidez = txtFecha.Text;
            string nombreTitular = txtTitularTarjeta.Text;

            Boolean resultadoPago = false;

            resultadoPago = operacion.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);

            if (resultadoPago == true)
            {
                // NEGOCIO - ACTIVAR USUARIO CUANDO EL PAGO SE REALIZA DE FORMA CORRECTA
                Usuario oUsuaio = new Usuario();
                oUsuaio = interfazNegocioUsuario.ObtenerUsuario(System.Convert.ToInt16(idUsuario));
                oUsuaio.Estado = "Activo";
                interfazNegocioUsuario.ActualizarUsuario(oUsuaio);
                // NEGOCIO - ACTUALIZAR PAGOUSUARIOS, IDUSUARIO,NOMBREAPELLIDO,DESCRIPCION,NUMERO DE ORDEN,MONTO,FECHA
                string estadoPago = "";
                string descipcion = "PAGO DE MEMBRESIA " + tipoMembresia;
                string monto = Session["valorMembresia"].ToString();
                int numeroOrden = interfazNegocio.RegistrarPagoUsuario(oUsuaio.IdUsuario, oUsuaio.NombreApellido, descipcion, monto);
                // NEGOCIO - ENVIAR FACTURA AL CLIENTE SOBRE EL MONTO QUE PAGO
                if (numeroOrden != 1) {
                    estadoPago = "PAGO REGISTRADO CORRECTAMENTE!";
                } else
                {
                    estadoPago = "FALLO AL REGISTRAR EL PAGO!";
                }
                // NEGOCIO - LE EMBIAMOS POR EMAIL EN EL BODY COMO SI FUERA UN TK
                interfazNegocio.EnviarTicketConfirmacionPago(oUsuaio.IdUsuario, numeroOrden, oUsuaio.Email, estadoPago);
                // NEGOCIO - INSERTO MEMBRESIAUSUARIO SI ES NUEVO | SI EXISTE LO ACTUALIZO
                // POSIBILIDADES: NUEVOUSUARIO , UPGRADE USUARIO, PAGO POR ACTIVACION
                int codigoMembresiaUsuario = interfazNegocio.ObtenerCodigoMembresiaUsuario(oUsuaio.IdUsuario);
                if (codigoMembresiaUsuario == 0)
                {
                    // NEGOCIO - codigoMembresiaUsuario == 0 ENTONCES NUEVO USUARIO - INSERTO
                    interfazNegocio.RegistrarMembresiaUsuario(oUsuaio.IdUsuario, codigoMembresia);
                }
                else
                {
                    //NEGOCIO - codigoMembresiaUsuario != 0 ENTONCES USUARIO YA EXISTE ACTUALIZO SU MEMBRESIA
                    interfazNegocio.ActualizarMembresiaUsuario(oUsuaio.IdUsuario, codigoMembresia);
                }
                resultadoPago = false;
                Response.Redirect("isOk.aspx");
            }
            else
            {
                resultadoPago = false;
                Response.Redirect("isError.aspx");
            }
        }
    }
}