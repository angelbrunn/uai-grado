using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class rutas : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        String rMDQ = "MDQ01";
        /// <summary>
        /// 
        /// </summary>
        String rATA = "ATA01";
        /// <summary>
        /// 
        /// </summary>
        String rCOD = "COD01";
        /// <summary>
        /// 
        /// </summary>
        String rROS = "ROS01";
        /// <summary>
        /// Instancio la clase de negocio motopoint | interfazNegocio
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginUsuario"] != null)
            {
                string loginEstado = Session["loginEstado"].ToString();
                string loginUsuario = Session["loginUsuario"].ToString();

                //OBTENGO DATOS PRIMARIOS DE EL EVENTO
                OtenerDatosRutas();

                //EVALUAR ESTADO DE LAS VOTACIONES
                EvaluarEstadoVotacion();

                //VALIDO A CUALES EVENTOS LE HIZO LIKE EL USUARIO LOGEADO
                EvaluarLikeUsuario(loginUsuario);

                //SI ES UN USUARIO NUEVO O INVALIDO LO SACO
                if (loginEstado == "1" || (loginUsuario == "NuevoUsuario"))
                {
                    Session["loginEstado"] = 1;
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                Session.Clear();
                FormsAuthentication.SignOut();
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
        /// <param name="usuario"></param>
        protected void EvaluarLikeUsuario(string usuario)
        {
            List<Ruta> listadoVotacionesUsuario = new List<Ruta>();
            listadoVotacionesUsuario = interfazNegocio.VotacionesUsuario(usuario);

            IEnumerator<Ruta> enu = listadoVotacionesUsuario.GetEnumerator();
            while (enu.MoveNext())
            {
                if (enu.Current.CodRuta.ToString() == rMDQ)
                {
                    btnLikeMDQ01.Text = "Unlike";
                }
                else if (enu.Current.CodRuta.ToString() == rATA)
                {
                    btnLikeATA01.Text = "Unlike";
                }
                else if (enu.Current.CodRuta.ToString() == rCOD)
                {
                    btnLikeCOD01.Text = "Unlike";
                }
                else if (enu.Current.CodRuta.ToString() == rROS)
                {
                    btnLikeROS01.Text = "Unlike";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void EvaluarEstadoVotacion()
        {
            List<RutaVotacion> listadoEstadoVotacion = new List<RutaVotacion>();
            listadoEstadoVotacion = interfazNegocio.EstadoVotacion();

            //EVALUO EL ESTADO DE LAS RUTAS
            IEnumerator<RutaVotacion> enu = listadoEstadoVotacion.GetEnumerator();
            while (enu.MoveNext())
            {
                if (enu.Current.CodRuta.ToString() == rMDQ)
                {
                    if (enu.Current.Estado.ToString() == "ABIERTO")
                    {
                        btnLikeMDQ01.Enabled = true;
                    }
                    else
                    {
                        btnLikeMDQ01.CssClass = "btnLikeDisabled";
                        btnLikeMDQ01.Enabled = false;
                        lblMDQ01CantMotos.Text = "";
                        lblMDQ01FechaLimite.Text = "";
                        lblMDQ01Estado.Text = "cerrado";
                    }
                }
                else if (enu.Current.CodRuta.ToString() == rATA)
                {
                    if (enu.Current.Estado.ToString() == "ABIERTO")
                    {
                        btnLikeATA01.Enabled = true;
                    }
                    else
                    {
                        btnLikeATA01.CssClass = "btnLikeDisabled";
                        btnLikeATA01.Enabled = false;
                        lblATA01CantMotos.Text = "";
                        lblATA01FechaLimite.Text = "";
                        lblATA01Estado.Text = "cerrado";
                    }
                }
                else if (enu.Current.CodRuta.ToString() == rCOD)
                {
                    if (enu.Current.Estado.ToString() == "ABIERTO")
                    {
                        btnLikeCOD01.Enabled = true;
                    }
                    else
                    {
                        btnLikeCOD01.CssClass = "btnLikeDisabled";
                        btnLikeCOD01.Enabled = false;
                        lblCOD01CantMotos.Text = "";
                        lblCOD01FechaLimite.Text = "";
                        lblCOD01Estado.Text = "cerrado";
                    }
                }
                else if (enu.Current.CodRuta.ToString() == rROS)
                {
                    if (enu.Current.Estado.ToString() == "ABIERTO")
                    {
                        btnLikeROS01.Enabled = true;
                    }
                    else
                    {
                        btnLikeROS01.CssClass = "btnLikeDisabled";
                        btnLikeROS01.Enabled = false;
                        lblROS01CantMotos.Text = "";
                        lblROS01FechaLimite.Text = "";
                        lblROS01Estado.Text = "cerrado";
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void OtenerDatosRutas()
        {
            string currentLang;
            List<RutaVotacion> listadoDatosRuta = new List<RutaVotacion>();
            listadoDatosRuta = interfazNegocio.DatosRutas();

            if (Session["lang"] == null)
            {
                currentLang = "es-ES";
            }
            else
            {
                currentLang = Session["lang"].ToString();

            }

            IEnumerator<RutaVotacion> enu = listadoDatosRuta.GetEnumerator();
            while (enu.MoveNext())
            {
                if (enu.Current.CodRuta.ToString() == rMDQ)
                {
                    lblMDQ01CantMotos.Text = lblMDQ01CantMotos.Text + " " + enu.Current.cantUsuario;
                    if (currentLang == "en-US")
                    {
                        string DescRuta = GetLocalResourceObject("lblDetalleRutaVotacionMDQResource1.Text") as string;
                        lblDetalleRutaVotacionMDQ.Text = DescRuta.ToString();
                    }
                    else
                    {
                        lblDetalleRutaVotacionMDQ.Text = enu.Current.DetalleRutaVotacion;
                    }
                    lblMDQ01FechaLimite.Text = lblMDQ01FechaLimite.Text + " " + (enu.Current.FechaLimite).Substring(0, 6) + (enu.Current.FechaLimite).Substring(8, 2);
                }
                else if (enu.Current.CodRuta.ToString() == rATA)
                {
                    lblATA01CantMotos.Text = lblATA01CantMotos.Text + " " + enu.Current.cantUsuario;
                    if (currentLang == "en-US")
                    {
                        string DescRuta = GetLocalResourceObject("lblDetalleRutaVotacionATAResource1.Text") as string;
                        lblDetalleRutaVotacionATA.Text = DescRuta.ToString();
                    }
                    else
                    {
                        lblDetalleRutaVotacionATA.Text = enu.Current.DetalleRutaVotacion;
                    }
                    lblATA01FechaLimite.Text = lblATA01FechaLimite.Text + " " + (enu.Current.FechaLimite).Substring(0, 6) + (enu.Current.FechaLimite).Substring(8, 2);
                }
                else if (enu.Current.CodRuta.ToString() == rCOD)
                {
                    lblCOD01CantMotos.Text = lblCOD01CantMotos.Text + " " + enu.Current.cantUsuario;
                    if (currentLang == "en-US")
                    {
                        string DescRuta = GetLocalResourceObject("lblDetalleRutaVotacionCORResource1.Text") as string;
                        lblDetalleRutaVotacionCOR.Text = DescRuta.ToString();
                    }
                    else
                    {
                        lblDetalleRutaVotacionCOR.Text = enu.Current.DetalleRutaVotacion;
                    }
                    lblCOD01FechaLimite.Text = lblCOD01FechaLimite.Text + " " + (enu.Current.FechaLimite).Substring(0, 6) + (enu.Current.FechaLimite).Substring(8, 2);
                }
                else if (enu.Current.CodRuta.ToString() == rROS)
                {
                    lblROS01CantMotos.Text = lblROS01CantMotos.Text + " " + enu.Current.cantUsuario;
                    if (currentLang == "en-US")
                    {
                        string DescRuta = GetLocalResourceObject("lblDetalleRutaVotacionROSResource1.Text") as string;
                        lblDetalleRutaVotacionROS.Text = DescRuta.ToString();
                    }
                    else
                    {
                        lblDetalleRutaVotacionROS.Text = enu.Current.DetalleRutaVotacion;
                    }
                    lblROS01FechaLimite.Text = lblROS01FechaLimite.Text + " " + (enu.Current.FechaLimite).Substring(0, 6) + (enu.Current.FechaLimite).Substring(8, 2);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeMDQ_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeATA01_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeCOD01_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeROS01_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDetaMDQ_Click(object sender, EventArgs e)
        {
            //INICIALIZO LOS ESTADOS DE LA RUTA
            InicializarEstadoRuta();

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = ((((ImageButton)sender).ID).ToString()).Substring(7, 5);

            //OBTENER DATOS DE LA RUTA - SHOW EN DIALOG
            Ruta detalleRuta = new Ruta();
            detalleRuta = interfazNegocio.ObtenerDetalleRuta(codRuta);

            lblDetaDesde.Text = detalleRuta.Desde;
            lblDetaHasta.Text = detalleRuta.Hasta;
            lblDetaCantMin.Text = detalleRuta.MinMotos;
            lblDetaCantMax.Text = detalleRuta.MaxMotos;

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalDetalle()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDetaATA_Click(object sender, EventArgs e)
        {
            //INICIALIZO LOS ESTADOS DE LA RUTA
            InicializarEstadoRuta();

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = ((((ImageButton)sender).ID).ToString()).Substring(7, 5);

            //OBTENER DATOS DE LA RUTA - SHOW EN DIALOG
            Ruta detalleRuta = new Ruta();
            detalleRuta = interfazNegocio.ObtenerDetalleRuta(codRuta);

            lblDetaDesde.Text = detalleRuta.Desde;
            lblDetaHasta.Text = detalleRuta.Hasta;
            lblDetaCantMin.Text = detalleRuta.MinMotos;
            lblDetaCantMax.Text = detalleRuta.MaxMotos;

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalDetalle()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDetaCOD_Click(object sender, EventArgs e)
        {
            //INICIALIZO LOS ESTADOS DE LA RUTA
            InicializarEstadoRuta();

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = ((((ImageButton)sender).ID).ToString()).Substring(7, 5);

            //OBTENER DATOS DE LA RUTA - SHOW EN DIALOG
            Ruta detalleRuta = new Ruta();
            detalleRuta = interfazNegocio.ObtenerDetalleRuta(codRuta);

            lblDetaDesde.Text = detalleRuta.Desde;
            lblDetaHasta.Text = detalleRuta.Hasta;
            lblDetaCantMin.Text = detalleRuta.MinMotos;
            lblDetaCantMax.Text = detalleRuta.MaxMotos; 

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalDetalle()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDetaROS_Click(object sender, EventArgs e)
        {
            //INICIALIZO LOS ESTADOS DE LA RUTA
            InicializarEstadoRuta();

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = ((((ImageButton)sender).ID).ToString()).Substring(7, 5);

            //OBTENER DATOS DE LA RUTA - SHOW EN DIALOG
            Ruta detalleRuta = new Ruta();
            detalleRuta = interfazNegocio.ObtenerDetalleRuta(codRuta);

            lblDetaDesde.Text = detalleRuta.Desde;
            lblDetaHasta.Text = detalleRuta.Hasta;
            lblDetaCantMin.Text = detalleRuta.MinMotos;
            lblDetaCantMax.Text = detalleRuta.MaxMotos;

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalDetalle()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        protected void InicializarEstadoRuta() {

            lblMDQ01CantMotos.Text = "Motoqueros:";
            lblMDQ01FechaLimite.Text = "Cierre:";

            lblATA01CantMotos.Text = "Motoqueros:";
            lblATA01FechaLimite.Text = "Cierre:";

            lblCOD01CantMotos.Text = "Motoqueros:";
            lblCOD01FechaLimite.Text = "Cierre:";

            lblROS01CantMotos.Text = "Motoqueros:";
            lblROS01FechaLimite.Text = "Cierre:";

            OtenerDatosRutas();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected void EvaluarLike(object sender)
        {
            //RESULTADO POR DEFAULT | TRUE YA EXISTE LIKE OR FALSE AUN NO TIENE LIKE
            Boolean resultado = true;

            //OBTENGO USUARIO LOGEADO
            string usuario = Session["loginUsuario"].ToString();

            //OBTENGO LA RUTA SELECCIONADA
            string codRuta = ((((Button)sender).ID).ToString()).Substring(7, 5);

            //OBTENGO EL ESTADO LIKE|UNLIKE
            string estadoBtn = ((((Button)sender).Text).ToString());

            //CONSULTO LIKE DE USUARIO CORRIENTE
            resultado = interfazNegocio.ConsultarLikeUsuario(codRuta, usuario);

            //REGISTRO LIKE PARA ESTE USUARIO
            if (estadoBtn == "Like")
            {
                if (resultado == false)
                {
                    //OBTENGO FECHA DEL EVENTO
                    string fechaRuta = interfazNegocio.ObtenerFechaRuta(codRuta);

                    //OBTENER ULTIMO ID RUTASUSUARIO
                    int idRutaLikeUsuario = interfazNegocio.ObtenerIdLikeUsuario();

                    //REGISTRO LIKE DEL USUARIO
                    interfazNegocio.RegistrarLikeUsuario(idRutaLikeUsuario, codRuta, usuario, fechaRuta);

                    //REGISTRO VOTACION DEL USUARIO
                    interfazNegocio.RegistrarVotacionRuta(codRuta);

                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    //USUARIO YA VOTO ESTA RUTA | VALIDACION E AVISO
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModal()", true);

                }
            }
            else if (estadoBtn == "Unlike")
            {
                //DECREMENTAR VOTACION DE DICHA RUTA
                interfazNegocio.DecrementarVotacionRuta(codRuta);

                //BORRAR BOTACION DEL USUARIO PARA DICHA RUTA
                interfazNegocio.BorrarVotacionRutaUsuario(usuario, codRuta);

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}