using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Xml;
using SIS.ENTIDAD;
using System.Threading;
using System.Globalization;

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
        List<TarjetaCredito> collTarjetasCredito = new List<TarjetaCredito>();
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
        protected override void InitializeCulture()
        {
            if (Session["lang"] != null)
            {
                SetCulture(Session["lang"].ToString());
                base.InitializeCulture();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        private void SetCulture(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            //NEGOCIO - VALIDO EL PAGO VIA WEBSERVICES
            var operacion = new somee.Service();
            string numeroTarjeta = txtNumeroTarjeta.Text;
            string numeroSeguridad = txtCvc.Text;
            string fechaValidez = txtFecha.Text;
            string nombreTitular = txtTitularTarjeta.Text;
            string saldo = txtMontoPagar.Text;

            Boolean resultadoPago = false;
            Boolean esTarjetaValida = false;

            esTarjetaValida = ValTarjetaYvalSaldo(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular, saldo);

            //TODO CALL TO WEBSERVICE DEPLOYMENT
            resultadoPago = operacion.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);

            resultadoPago = esTarjetaValida;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        /// <returns></returns>
        public Boolean ValTarjetaYvalSaldo(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular, string saldo)
        {
            Boolean resultadoPago = false;

            //OBTENGO LAS TARJETAS VAIDAS DE LOS CLIENTES
            collTarjetasCredito = interfazNegocio.ObtenerTarjetaCredito();

            // BUSCO DENTRO DE MI DB EN MEMORIA SI EXISTE VALIDO CVC SINO EXISTE LO AGREGO
            IEnumerator<TarjetaCredito> enu1 = collTarjetasCredito.GetEnumerator();
            IEnumerator<TarjetaCredito> enu = collTarjetasCredito.GetEnumerator();
            int nuevaTarjeta = 0;
            Boolean block = false;

            while (enu1.MoveNext())
            {
                if (enu1.Current.NumeroTarjeta == numeroTarjeta)
                {
                    // SI LA TARJETA EXISTE ENTONCES OPERO CON DICHA TARJETA
                    nuevaTarjeta = 0;
                }
                else
                {
                    // SI LA TARJETA NO EXISTE LA AGREGO
                    nuevaTarjeta = 1;
                }
            }

            while (enu.MoveNext())
            {
                if (nuevaTarjeta == 0)
                {
                    // VALIDO SI EXISTE LA TARJETA O SI YA SE INGRESO
                    if (enu.Current.NumeroTarjeta == numeroTarjeta)
                    {
                        // SI YA LA AGREGUE VALIDO SI EL CODIGO DE CVC ES VALIDO
                        if (enu.Current.NumeroSeguridad == numeroSeguridad)
                        {
                            // VALIDACION DE LA FECHA | LA MISMA TIENE QUE ESTAR VIGENTE
                            DateTime dateActual = DateTime.Now;
                            string fecha = "01/" + fechaValidez.Substring(0, 2).ToString() + "/" + "20" + fechaValidez.Substring(2, 2).ToString();
                            DateTime dateTarjeta = DateTime.Parse(fecha);

                            if (dateTarjeta > dateActual)
                            {
                                int saldoDisponible = Convert.ToInt32(enu.Current.Saldo);
                                int saldoDebitar = Convert.ToInt32(saldo);
                                // VALIDO SI TIENE SALDO - PENDING
                                if (saldoDisponible >= saldoDebitar)
                                {
                                    int saldoFinal = saldoDisponible - saldoDebitar;
                                    // DEBITO | DECREMENTO SALDO PARA DICHA TARJETA
                                    interfazNegocio.DecrementarTarjetaCreditoSaldo(enu.Current.NumeroTarjeta, saldoFinal.ToString());
                                    resultadoPago = true;
                                }
                                else
                                {
                                    resultadoPago = false;
                                }
                            }
                            else
                            {
                                resultadoPago = false;
                            }

                        }
                        else
                        {
                            resultadoPago = false;
                        }
                    }
                }
                else if (nuevaTarjeta == 1)
                {
                    if (block == false)
                    {
                        //SAVE TARJETA
                        block = true;
                        TarjetaCredito oTarjetaCredito = new TarjetaCredito();
                        oTarjetaCredito.NumeroTarjeta = numeroTarjeta;
                        oTarjetaCredito.NumeroSeguridad = numeroSeguridad;
                        oTarjetaCredito.FechaValidez = fechaValidez;
                        oTarjetaCredito.NombreTitular = nombreTitular;
                        int saldoDisponible = Convert.ToInt32("5000");
                        int saldoDebitar = Convert.ToInt32(saldo);
                        int saldoFinal = saldoDisponible - saldoDebitar;
                        oTarjetaCredito.Saldo = saldoFinal.ToString();
                        // LA TARJETA ES NUEVA LA AGREGO | SI ES TARJETA VALIDA
                        switch (enu.Current.NumeroTarjeta.Substring(0, 4))
                        {
                            case "4338":
                                Console.WriteLine("PAGO CON VISA");
                                interfazNegocio.RegistrarTarjetaCredito(oTarjetaCredito);
                                resultadoPago = true;
                                break;
                            case "3777":
                                Console.WriteLine("PAGO CON AMEX");
                                interfazNegocio.RegistrarTarjetaCredito(oTarjetaCredito);
                                resultadoPago = true;
                                break;
                            case "5323":
                                Console.WriteLine("PAGO CON MS");
                                interfazNegocio.RegistrarTarjetaCredito(oTarjetaCredito);
                                resultadoPago = true;
                                break;
                            default:
                                Console.WriteLine("Invalid Card");
                                interfazNegocio.RegistrarTarjetaCredito(oTarjetaCredito);
                                resultadoPago = false;
                                break;
                        }
                    }
                }
            }
            return resultadoPago;
        }
    }
}
