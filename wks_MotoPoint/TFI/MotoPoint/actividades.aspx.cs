using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginUsuario"] != null)
            {
                string loginEstado = Session["loginEstado"].ToString();
                string loginUsuario = Session["loginUsuario"].ToString();

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnActivROS01_Click(object sender, EventArgs e)
        {

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "ROS01";

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG


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

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "CHS01";

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG


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

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "MDQ01";

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG


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

            //OBTENGO LA RUTA A BUSCAR DEALLE
            string codRuta = "COR01";

            //OBTENER ACTIVIDADES PARA ROSARIO - SHOW EN DIALOG


            //SHOW DETALLE
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalActividad()", true);
        }
    }
}