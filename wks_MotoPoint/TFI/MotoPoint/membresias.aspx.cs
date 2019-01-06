﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    /// <summary>
    /// NEGOCIO PAGO DE LA MEMBRESIA
    /// </summary>
    public partial class membresias : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// 
        /// </summary>
        string precioBronce;
        /// <summary>
        /// 
        /// </summary>
        string precioPlata;
        /// <summary>
        /// 
        /// </summary>
        string precioOro;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            string idUsuario = Session["UsuarioId"].ToString();
            //NEGOCIO: ACTUALIZO LOS VALORES DE LAS MEMBRESIAS
            precioBronce = System.Convert.ToString(interfazNegocio.ObtenerMembresiaPrecio("3"));
            precioPlata = System.Convert.ToString(interfazNegocio.ObtenerMembresiaPrecio("2"));
            precioOro = System.Convert.ToString(interfazNegocio.ObtenerMembresiaPrecio("1"));
            lblPrecioBronce.Text = precioBronce;
            lblPrecioPlata.Text = precioPlata;
            lblPrecioOro.Text = precioOro;
            //ARQ.BASE MULTI-USUARIO | VALIDO USUARIO
            if (idUsuario == null || idUsuario == "") {
                //ARQ.BASE LOGIN MOSTRAR PANTALLA LOGIN | AVISAR USER INVALIDO
                Session["loginEstado"] = 1;
                Response.Redirect("login.aspx");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarBronce_Click(object sender, EventArgs e)
        {
            // 1 - BUSCO EL ID PARA LA MEMBRESIA TIPO BRONCE
            string idMembresia = interfazNegocio.ObtenerMembresiaSegunTipo("Bronce").ToString();
            string idUsuario = Session["UsuarioId"].ToString();
            // 2 - GUARDO LA MEMBRESIA SELECCIONADA PARA EL USUARIO 
           // int resulado = interfazNegocio.RegistrarMembresiaParaUsuario(idMembresia, idUsuario);
            Session["IdMembresia"] = idMembresia;
            Session["UsuarioId"] = idUsuario;
            Session["valorMembresia"] = precioBronce;
            Response.Redirect("membresiaspago.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarPlata_Click(object sender, EventArgs e)
        {
            // 1 - BUSCO EL ID PARA LA MEMBRESIA TIPO BRONCE
            string idMembresia = interfazNegocio.ObtenerMembresiaSegunTipo("Plata").ToString();
            string idUsuario = Session["UsuarioId"].ToString();
            // 2 - GUARDO LA MEMBRESIA SELECCIONADA PARA EL USUARIO 
            int resulado = interfazNegocio.RegistrarMembresiaParaUsuario(idMembresia, idUsuario);
            Session["IdMembresia"] = idMembresia;
            Session["UsuarioId"] = idUsuario;
            Session["valorMembresia"] = precioPlata;
            Response.Redirect("membresiaspago.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarOro_Click(object sender, EventArgs e)
        {
            // 1 - BUSCO EL ID PARA LA MEMBRESIA TIPO BRONCE
            string idMembresia = interfazNegocio.ObtenerMembresiaSegunTipo("Oro").ToString();
            string idUsuario = Session["UsuarioId"].ToString();
            // 2 - GUARDO LA MEMBRESIA SELECCIONADA PARA EL USUARIO 
            int resulado = interfazNegocio.RegistrarMembresiaParaUsuario(idMembresia, idUsuario);
            Session["IdMembresia"] = idMembresia;
            Session["UsuarioId"] = idUsuario;
            Session["valorMembresia"] = precioOro;
            Response.Redirect("membresiaspago.aspx");
        }
    }
}