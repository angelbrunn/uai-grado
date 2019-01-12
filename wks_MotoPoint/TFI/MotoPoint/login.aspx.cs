using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace MotoPoint
{
    public partial class login : System.Web.UI.Page
    {
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
            //ARQ.BASE: GESTION LOGIN/LOGOUT - VALIDACION DE ESTADO DE LOGIN
            var loginEstado = Session["loginEstado"];
            if (loginEstado == null)
            {
                Session["loginEstado"] = 0;
            }
            else if (loginEstado.ToString() == "0")
            {
                Session["loginEstado"] = 0;
            }
            else if (loginEstado.ToString() == "1")
            {
                Session["loginEstado"] = 1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var resultadoLogin = 0;
            bool existeUsuario = false;
            SIS.ENTIDAD.Usuario user = new SIS.ENTIDAD.Usuario();

            user.usuario = txtUsuario.Text;
            user.Password = txtContrasenia.Text;

            if (txtUsuario.Text != null && txtContrasenia.Text != null)
            {
                //ARQ.BASE - VALIDO SI EXISTE USUARIO | REITENTOS
                existeUsuario = interfazNegocioUsuario.ValidarUsuario(user.usuario.ToString());
                //ARQ.BASE - OBTENGO ID DEL USER SI EXISTE
                resultadoLogin = interfazNegocioUsuario.Login(user.usuario, user.Password);
            }

            //EVALUO EL RESULTDO DEL LOGIN | SI ES 0 Y NO EXISTE USUARIO -> CREAR USUARIO
            if (resultadoLogin != 0 && existeUsuario == true)
            {
                SingletonConeccion coneccion = SingletonConeccion.Instance;

                //BUSCO EL USUARIO POR SU ID
                var usuario = interfazNegocioUsuario.ObtenerUsuario(resultadoLogin);
                if (usuario.Estado == "Activo")
                {
                    //GUARDO EL USUARIO CONECTADO EN SESSION
                    Session["Usuario"] = usuario.usuario;
                    Session["UsuarioId"] = usuario.IdUsuario;
                    Session["UsuarioLoginFecha"] = DateTime.Now;
                    Session["UsuarioHost"] = Request.UserHostAddress;
                    Session["UsuarioAgent"] = Request.Browser.Browser + "-" + Request.Browser.Version;
                    //NOS ASEGURAMOS QUE SOLO SE USARA UNA CONECCION PARA CADA USUARIO
                    Session["UsuarioInstaciaConeccion"] = coneccion;

                    //ME GUARDO LOS GRUPOS PARA EL USUARIO LOGEADO
                    List<SIS.ENTIDAD.Grupo> lstGrupos = usuario.ListadoGrupos;
                    //NIVEL DE ACCESO DEL USUARIO LOGEADO
                    var nVisibilidad = "";

                    foreach (SIS.ENTIDAD.Grupo g in lstGrupos)
                    {
                        //TOMO LA VISIBILIDAD ASIGNADA A DICHO USUARIO
                        nVisibilidad = g.grupo;
                    }

                    // CREO UN TICKET DE AUTENTIFICACION Y LO ENCRYPTO: ARQ.BASE.WEBSEGURITY
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, // Ticket version
                    user.usuario, // Username associated with ticket
                    DateTime.Now, // Date/time issued
                    DateTime.Now.AddMinutes(30), // Date/time to expire
                    true, // "true" for a persistent user cookie
                    nVisibilidad, // User-data, in this case the roles
                    FormsAuthentication.FormsCookiePath);// Path cookie valid for

                    // Encrypt the cookie using the machine key for secure transport
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie loginCookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName, // Name of auth cookie
                    hash); // Hashed ticket

                    // Set the cookie's expiration time to the tickets expiration time
                    if (ticket.IsPersistent) loginCookie.Expires = ticket.Expiration;

                    // Add the cookie to the list for outgoing response
                    Response.Cookies.Add(loginCookie);


                    if (nVisibilidad == "Admin")
                    {
                        //SI USUARIO ADMIN -> PANTALLA ADMIN
                        Session["loginEstado"] = 0;
                        Session["loginUsuario"] = user.usuario;
                        Response.Redirect("webmaster.aspx");
                    }
                    else
                    {
                        //SI USUARIO ES JERARQUICO O USUARIO -> PANTALLA HOME
                        Session["loginEstado"] = 0;
                        Session["loginUsuario"] = user.usuario;
                        Response.Redirect("eventos.aspx");
                    }
                }
                else
                {
                    //ARQ.BASE - ESTADO INACTIVO PERO USUARIO EXISTENTE | A: INACTIVO POR FALTA DE PAGO O B:INACTIVO POR REITENTO
                    int cantidadReitento = interfazNegocioUsuario.ConsultarReIntento(usuario.IdUsuario);

                    if (cantidadReitento == 3)
                    {
                        //ARQ.BASE - CASO B: USUARIO INACTIVO POR BLOQUEADO MAX RE-INTENTOS
                        crearTicketUsuarioNoRegistrado();
                        Session["UsuarioId"] = usuario.IdUsuario;
                        Response.Redirect("blockUsuario.aspx");
                    }
                    else
                    {
                        //ARQ.BASE - CASO A: USUARIO INACTIVO FALTA DE PAGO
                        crearTicketUsuarioNoRegistrado();
                        Session["UsuarioId"] = usuario.IdUsuario;
                        Response.Redirect("avisoPago.aspx");
                    }
                }
            }
            else if (resultadoLogin == 0 && existeUsuario == true)
            {
                Usuario oUsuario = new Usuario();
                //ARQ.BASE - BUSCO EL USUARIO POR NOMBRE DE USUARIO Y COBRO REITENTO
                oUsuario = interfazNegocioUsuario.ObtenerUsuarioPorNombreUsuario(txtUsuario.Text);

                //ARQ.BASE - VERIFICO SI TIENE MENOS DE 3 INTENTOS | SINO ESTA BLOQUEADO POR RE-INTENTOS
                int cantidadReitento = interfazNegocioUsuario.ConsultarReIntento(oUsuario.IdUsuario);

                if (cantidadReitento < 2)
                {
                    //ARQ.BASE - BUSCAR SI TIENE INSERTADO REGISTRO EN REITENTOS
                    interfazNegocioUsuario.ContarReIntento(oUsuario.IdUsuario, cantidadReitento);
                }else if (cantidadReitento == 2)
                {
                    //ARQ.BASE - TERCER REITENTO
                    interfazNegocioUsuario.ContarReIntento(oUsuario.IdUsuario, cantidadReitento);
                    //ARQ.BASE - INACTIVAR USUARIO
                    oUsuario.Estado = "Inactivo";
                    interfazNegocioUsuario.ActualizarUsuarioEstado(oUsuario);
                }
                else
                {
                    //ARQ.BASE - USUARIO BLOQUEADO MAX RE-INTENTOS
                    crearTicketUsuarioNoRegistrado();
                    Response.Redirect("blockUsuario.aspx");
                }
            }
            //MOSTRAR PANTALLA LOGIN | AVISAR USER INVALIDO
            Session["loginEstado"] = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkRegistrarse_Click(object sender, EventArgs e)
        {
            //CREO UN TK TEMPORAL PARA UN USUARIO INVALIDO O NO REGISTRADO
            crearTicketUsuarioNoRegistrado();

            Session["loginEstado"] = 0;
            Session["loginUsuario"] = "NuevoUsuario";

            Response.Redirect("registro.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkRecordar_Click(object sender, EventArgs e)
        {
            //CREO UN TK TEMPORAL PARA UN USUARIO INVALIDO O NO REGISTRADO
            crearTicketUsuarioNoRegistrado();

            Session["loginEstado"] = 1;
            Session["loginUsuario"] = "NuevoUsuario";

            Response.Redirect("recordar.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        protected void crearTicketUsuarioNoRegistrado()
        {
            // CREO UN TICKET DE AUTENTIFICACION Y LO ENCRYPTO: ARQ.BASE.WEBSEGURITY
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, // Ticket version
            "NuevoUsuario", // Username associated with ticket
            DateTime.Now, // Date/time issued
            DateTime.Now.AddMinutes(30), // Date/time to expire
            true, // "true" for a persistent user cookie
            "", // User-data, in this case the roles
            FormsAuthentication.FormsCookiePath);// Path cookie valid for

            // Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie loginCookie = new HttpCookie(
            FormsAuthentication.FormsCookieName, // Name of auth cookie
            hash); // Hashed ticket

            // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent) loginCookie.Expires = ticket.Expiration;

            // Add the cookie to the list for outgoing response
            Response.Cookies.Add(loginCookie);
        }
        /// <summary>
        /// SINGLETON | https://codeburst.io/singleton-design-pattern-implementation-in-c-62a8daf3d115
        /// </summary>
        public sealed class SingletonConeccion
        {
            SingletonConeccion()
            {
            }
            private static readonly object padlock = new object();
            private static SingletonConeccion instance = null;
            public static SingletonConeccion Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonConeccion();
                        }
                        return instance;
                    }
                }
            }
        }
    }
}