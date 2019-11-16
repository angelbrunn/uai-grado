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
    public partial class actividades : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        Boolean exitCode = false;
        /// <summary>
        /// 
        /// </summary>
        Boolean setCultureLang = false;
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
                Session["avisoModal01"] = "0";
                string loginEstado = Session["loginEstado"].ToString();
                string loginUsuario = Session["loginUsuario"].ToString();

                //SI ES UN USUARIO NUEVO O INVALIDO LO SACO
                if (loginEstado == "1" || (loginUsuario == "NuevoUsuario"))
                {
                    Session["loginEstado"] = 1;
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                }

                //VALIDICION SI VIENE DE POSTBACK LO DEJO EN EL DIALOG
                if (IsPostBack)
                {
                    if (!setCultureLang) { 
                    if (!exitCode)
                    {
                        //SHOW DETALLE
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalActividad()", true);
                    }
                    else
                    {
                        //HIDE DETALLE
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "closeModalActividad()", true);
                    }
                    }
                    else
                    {
                        setCultureLang = false;
                    }
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
                setCultureLang = true;
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
        protected void btnActivROS01_Click(object sender, EventArgs e)
        {
            exitCode = false;
            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "ROS01";

            //OBTENER ACTIVIDAD ROSARIO
            Actividad detalleActividad = new Actividad();
            detalleActividad = interfazNegocio.ObtenerActividad(codRuta);

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG
            List<ActividadPrecio> listadoActividadPrecio = new List<ActividadPrecio>();
            listadoActividadPrecio = interfazNegocio.ObtenerPrecioActividades(detalleActividad.CodAct);

            //EVALUO EL ESTADO DE LAS RUTAS
            IEnumerator<ActividadPrecio> enu = listadoActividadPrecio.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdActividadPrecio)
                {
                    case "13":
                        chkAct1.Text = enu.Current.TituloActividad.ToString();
                        lblAct1Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct1.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "14":
                        chkAct2.Text = enu.Current.TituloActividad.ToString();
                        lblAct2Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct2.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "15":
                        chkAct3.Text = enu.Current.TituloActividad.ToString();
                        lblAct3Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct3.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "16":
                        chkAct4.Text = enu.Current.TituloActividad.ToString();
                        lblAct4Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct4.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                }

            }

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalActividad()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnActivCHS01_Click(object sender, EventArgs e)
        {
            exitCode = false;
            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "CHS01";

            //OBTENER ACTIVIDAD CHASCOMUS
            Actividad detalleActividad = new Actividad();
            detalleActividad = interfazNegocio.ObtenerActividad(codRuta);

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG
            List<ActividadPrecio> listadoActividadPrecio = new List<ActividadPrecio>();
            listadoActividadPrecio = interfazNegocio.ObtenerPrecioActividades(detalleActividad.CodAct);

            //EVALUO EL ESTADO DE LAS RUTAS
            IEnumerator<ActividadPrecio> enu = listadoActividadPrecio.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdActividadPrecio)
                {
                    case "1":
                        chkAct1.Text = enu.Current.TituloActividad.ToString();
                        lblAct1Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct1.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "2":
                        chkAct2.Text = enu.Current.TituloActividad.ToString();
                        lblAct2Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct2.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "3":
                        chkAct3.Text = enu.Current.TituloActividad.ToString();
                        lblAct3Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct3.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "4":
                        chkAct4.Text = enu.Current.TituloActividad.ToString();
                        lblAct4Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct4.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                }

            }

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalActividad()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnActivMDQ01_Click(object sender, EventArgs e)
        {
            exitCode = false;
            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "MDQ01";

            //OBTENER ACTIVIDAD MAR DEL PLATA
            Actividad detalleActividad = new Actividad();
            detalleActividad = interfazNegocio.ObtenerActividad(codRuta);

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG
            List<ActividadPrecio> listadoActividadPrecio = new List<ActividadPrecio>();
            listadoActividadPrecio = interfazNegocio.ObtenerPrecioActividades(detalleActividad.CodAct);

            //EVALUO EL ESTADO DE LAS RUTAS
            IEnumerator<ActividadPrecio> enu = listadoActividadPrecio.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdActividadPrecio)
                {
                    case "5":
                        chkAct1.Text = enu.Current.TituloActividad.ToString();
                        lblAct1Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct1.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "6":
                        chkAct2.Text = enu.Current.TituloActividad.ToString();
                        lblAct2Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct2.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "7":
                        chkAct3.Text = enu.Current.TituloActividad.ToString();
                        lblAct3Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct3.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "8":
                        chkAct4.Text = enu.Current.TituloActividad.ToString();
                        lblAct4Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct4.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                }

            }

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalActividad()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnActivCOR01_Click(object sender, EventArgs e)
        {
            exitCode = false;
            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "COR01";

            //OBTENER ACTIVIDAD CORDOBA
            Actividad detalleActividad = new Actividad();
            detalleActividad = interfazNegocio.ObtenerActividad(codRuta);

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG
            List<ActividadPrecio> listadoActividadPrecio = new List<ActividadPrecio>();
            listadoActividadPrecio = interfazNegocio.ObtenerPrecioActividades(detalleActividad.CodAct);

            //EVALUO EL ESTADO DE LAS RUTAS
            IEnumerator<ActividadPrecio> enu = listadoActividadPrecio.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdActividadPrecio)
                {
                    case "9":
                        chkAct1.Text = enu.Current.TituloActividad.ToString();
                        lblAct1Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct1.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "10":
                        chkAct2.Text = enu.Current.TituloActividad.ToString();
                        lblAct2Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct2.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "11":
                        chkAct3.Text = enu.Current.TituloActividad.ToString();
                        lblAct3Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct3.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                    case "12":
                        chkAct4.Text = enu.Current.TituloActividad.ToString();
                        lblAct4Precio.Text = "$ " + enu.Current.Precio.ToString();
                        imgAct4.ToolTip = enu.Current.Descripcion.ToString();
                        break;
                }

            }

            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalActividad()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        protected void CleanModal(object sender, EventArgs e)
        {

            //LIMPIAR LOS CHECKS EN = FALSE
            chkAct1.Checked = false;
            chkAct2.Checked = false;
            chkAct3.Checked = false;
            chkAct4.Checked = false;
            lblResultSumatoria.Text = "0";
            exitCode = true;

            ScriptManager.RegisterStartupScript(this, GetType(), "Close Modal", "closeModalActividad();", true);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnComprarActividad(object sender, EventArgs e)
        {

            //GO TO COMPRAR
            Session["CompraActividad"] = 1;
            Session["CompraMonto"] = Int32.Parse(lblResultSumatoria.Text);
            string idUsuario = Session["UsuarioId"].ToString();
            Session["IdMembresia"] = interfazNegocio.ObtenerCodigoMembresiaUsuario(idUsuario).ToString();

            if (Session["CompraMonto"].ToString() != "0")
            {
                Response.Redirect("membresiaspago.aspx");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddSumaTotalAct1(object sender, EventArgs e)
        {
            int act1 = Int32.Parse(lblAct1Precio.Text.Replace("$", ""));
            int res = Int32.Parse(lblResultSumatoria.Text);
            exitCode = false;

            if (chkAct1.Checked == true)
            {
                res = res + act1;
                lblResultSumatoria.Text = res.ToString();
            }

            if (chkAct1.Checked == false)
            {
                res = res - act1;
                lblResultSumatoria.Text = res.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddSumaTotalAct2(object sender, EventArgs e)
        {

            int act2 = Int32.Parse(lblAct2Precio.Text.Replace("$", ""));
            int res = Int32.Parse(lblResultSumatoria.Text);
            exitCode = false;

            if (chkAct2.Checked == true)
            {
                res = res + act2;
                lblResultSumatoria.Text = res.ToString();
            }

            if (chkAct2.Checked == false)
            {
                res = res - act2;
                lblResultSumatoria.Text = res.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddSumaTotalAct3(object sender, EventArgs e)
        {

            int act3 = Int32.Parse(lblAct3Precio.Text.Replace("$", ""));
            int res = Int32.Parse(lblResultSumatoria.Text);
            exitCode = false;

            if (chkAct3.Checked == true)
            {
                res = res + act3;
                lblResultSumatoria.Text = res.ToString();
            }

            if (chkAct3.Checked == false)
            {
                res = res - act3;
                lblResultSumatoria.Text = res.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddSumaTotalAct4(object sender, EventArgs e)
        {

            int act4 = Int32.Parse(lblAct4Precio.Text.Replace("$", ""));
            int res = Int32.Parse(lblResultSumatoria.Text);
            exitCode = false;

            if (chkAct4.Checked == true)
            {
                res = res + act4;
                lblResultSumatoria.Text = res.ToString();
            }

            if (chkAct4.Checked == false)
            {
                res = res - act4;
                lblResultSumatoria.Text = res.ToString();
            }
        }
    }
}