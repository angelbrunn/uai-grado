using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    /// <summary>
    /// 
    /// </summary>
    public partial class registro : System.Web.UI.Page
    {
        /// <summary>
        /// Instancio la clase de negocio motopoint | interfazNegocio
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new SIS.BUSINESS.NegMultiUsuario();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CategoriaMoto> listadoCategoriaMoto = new List<CategoriaMoto>();
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];
            Session["registroEstado"] = 0;

            //OBTENGO LAS CATEGORIAS DE MOTO
            listadoCategoriaMoto = interfazNegocio.ObtenerCategoriaMoto();

            //CARGO EL DROPDWONLIST CON LAS CATEGORIAS DE LAS MOTOS
            IEnumerator<CategoriaMoto> enu = listadoCategoriaMoto.GetEnumerator();
            while (enu.MoveNext())
            {
                ListItem oItem = new ListItem(enu.Current.Descripcion.ToString(), enu.Current.idCategoriaMoto.ToString());
                CategoriaMotoList.Items.Add(oItem);

            }

            //SI ES UN USUARIO REGISTRADO O VALIDO LO SACO
            if (loginEstado.ToString() == "0" || loginUsuario.ToString() != "NuevoUsuario")
            {
                if (loginUsuario.ToString() != "WebMaster")
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            List<Grupo> lstGrupo = new List<Grupo>();
            SIS.ENTIDAD.Grupo oGrupo = new SIS.ENTIDAD.Grupo();

            if (txtNombre.Text != "" && txtFechaNacimiento.Text != "" && txtContraseña.Text != "" && txtEmail.Text != "")
            {
                Session["registroEstado"] = 0;
                oUsuario.NombreApellido = txtNombre.Text;
                oUsuario.FechaNacimiento = txtFechaNacimiento.Text;
                oUsuario.CategoriaMoto = CategoriaMotoList.SelectedValue.ToString();
                oUsuario.usuario = txtEmail.Text.ToString().Substring(0, txtEmail.Text.ToString().IndexOf("@"));
                oUsuario.Password = txtContraseña.Text;
                oUsuario.Email = txtEmail.Text;
                //ESTA INACTIVO HASTA QUE PAGUE LA MEMBRESIA
                oUsuario.Estado = "Inactivo";

                //ARQ.BASE MULTI-USUARIO | OBTENER ULTIMO ID y GRUPOS ASOCIADOS
                oUsuario.IdUsuario = interfazNegocioUsuario.ObtenerIdParaUsuario().ToString();
                oGrupo = interfazNegocioUsuario.ObtenerGrupoPorId(2);
                lstGrupo.Add(oGrupo);
                oUsuario.ListadoGrupos = lstGrupo;

                //ARQ.BASE MULTI-USUARIO | INSERTO USUARIO - RE-CALCULANDO LOS DIGITOS VERIFICADORES
                interfazNegocioUsuario.InsertarUsuario(oUsuario);

                //GUARDO USUARIO QUE ESTA OPERANDO EN SESSION
                Session["UsuarioId"] = oUsuario.IdUsuario;
                Session["Usuario"] = oUsuario.usuario;

                Response.Redirect("membresias.aspx");
            }
            else
            {
                Session["registroEstado"] = 1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            Session["loginEstado"] = 0;
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}