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
            if (Session["UsuarioId"] != null && Session["IdMembresia"] != null)
            {
                string isCompraActividad = Session["CompraActividad"].ToString();
                if (isCompraActividad == "0")
                {
                    idMembresia = Session["IdMembresia"].ToString();
                    idUsuario = Session["UsuarioId"].ToString();
                    precioMembresia = Session["valorMembresia"].ToString();
                    tipoMembresia = Session["tipoMembresia"].ToString();
                    codigoMembresia = Session["codigoMembresia"].ToString();
                    txtMontoPagar.Text = precioMembresia;
                }
                else if (isCompraActividad == "1")
                {
                    Session["registroEstado"] = 0;
                    idUsuario = Session["UsuarioId"].ToString();
                    txtMontoPagar.Text = Session["CompraMonto"].ToString();
                }
            }
            else
            {
                //ARQ.BASE LOGIN MOSTRAR PANTALLA LOGIN | NO EXISTE USUARIO VALIDO
                Session["loginEstado"] = 1;
                Response.Redirect("login.aspx");
            }
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

            string isCompraActividad = Session["CompraActividad"].ToString();


            if (isCompraActividad == "0")
            {
                if (resultadoPago == true)
                {
                    // NEGOCIO - ACTIVAR USUARIO CUANDO EL PAGO SE REALIZA DE FORMA CORRECTA
                    Usuario oUsuaio = new Usuario();
                    oUsuaio = interfazNegocioUsuario.ObtenerUsuario(System.Convert.ToInt16(idUsuario));
                    oUsuaio.Estado = "Activo";
                    interfazNegocioUsuario.ActualizarUsuarioEstado(oUsuaio);
                    // NEGOCIO - ACTUALIZAR PAGOUSUARIOS, IDUSUARIO,NOMBREAPELLIDO,DESCRIPCION,NUMERO DE ORDEN,MONTO,FECHA
                    string estadoPago = "";
                    string descipcion = "PAGO DE MEMBRESIA " + tipoMembresia;
                    string monto = Session["valorMembresia"].ToString();
                    int numeroOrden = interfazNegocio.RegistrarPagoUsuario(oUsuaio.IdUsuario, oUsuaio.NombreApellido, descipcion, monto);
                    // NEGOCIO - ENVIAR FACTURA AL CLIENTE SOBRE EL MONTO QUE PAGO
                    if (numeroOrden != 1)
                    {
                        estadoPago = "PAGO REGISTRADO CORRECTAMENTE!";
                    }
                    else
                    {
                        estadoPago = "FALLO AL REGISTRAR EL PAGO!";
                    }
                    // NEGOCIO - LE EMBIAMOS POR EMAIL EN EL BODY COMO SI FUERA UN TK
                    interfazNegocio.EnviarTicketConfirmacionPago(oUsuaio.IdUsuario, numeroOrden, oUsuaio.Email, estadoPago);
                    // NEGOCIO - INSERTO MEMBRESIAUSUARIO SI ES NUEVO | SI EXISTE LO ACTUALIZO
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
                //ENTRO A PAGAR LAS ACTIVIADES
            }
            else if (isCompraActividad == "1")
            {
                //PAGO ACTIVIDADES | REGISTRO DE PAGO OK
                if (resultadoPago == true)
                {
                    Usuario oUsuaio = new Usuario();
                    oUsuaio = interfazNegocioUsuario.ObtenerUsuario(System.Convert.ToInt16(idUsuario));

                    string estadoPago = "";
                    string descipcion = "ACTIVIDADES";
                    string monto = Session["CompraMonto"].ToString();

                    int numeroOrden = interfazNegocio.RegistrarPagoUsuario(oUsuaio.IdUsuario, oUsuaio.NombreApellido, descipcion, monto);

                    // NEGOCIO - ENVIAR FACTURA AL CLIENTE SOBRE EL MONTO QUE PAGO
                    if (numeroOrden != 1)
                    {
                        //CREAR PDF TK NUMERO DE ORDE | NOMBRE Y APELLIDO | DESC | MONTO
                        interfazNegocio.CrearPDFVoucher(numeroOrden.ToString(), oUsuaio.NombreApellido, descipcion, monto);
                        estadoPago = "PAGO REGISTRADO CORRECTAMENTE!";
                    }
                    else
                    {
                        estadoPago = "FALLO EL PAGO!";
                    }

                    // NEGOCIO - LE EMBIAMOS POR EMAIL EN EL BODY COMO SI FUERA UN TK
                    interfazNegocio.EnviarTicketConfirmacionPago(oUsuaio.IdUsuario, numeroOrden, oUsuaio.Email, estadoPago);

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
}