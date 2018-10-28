using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MotoPoint
{
    public partial class webmasterpagos : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Usuario"))
            {
                //SI EL USUARIO NO TIENE PERMISOS LO SACO DE LA WEBMASTER PAGE - CONTINGENCIAS DE BACKLOG SYSTEM!
                Response.Redirect("home.aspx");
            }
            else {
                XmlDataDocument miDataDoc = new XmlDataDocument();
                miDataDoc.DataSet.ReadXmlSchema("C:\\MotoPoint\\pagos.xml");

                miDataDoc.Load("C:\\MotoPoint\\pagos.xml");
                GridViewPago.DataSource = miDataDoc.DataSet.Tables[0];
                GridViewPago.DataBind();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("webmaster.aspx");
        }
    }
}