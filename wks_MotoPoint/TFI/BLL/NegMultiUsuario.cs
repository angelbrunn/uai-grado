using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text;

namespace SIS.BUSINESS
{
    /// <summary>
    /// FacadeMultiUsuari | https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class NegMultiUsuario : INegMultiUsuario
    {
        /// <summary>
        /// 
        /// </summary>
        private SEG.IHash interfazHash = new SEG.Hash();
        /// <summary>
        /// 
        /// </summary>
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        public void InsertarUsuario(ENTIDAD.Usuario oUsuario)
        {
            string passHasheada;
            string digiVerificador;
            string IdHASH = "HASH";

            // passHasheada = interfazHash.obtenerHash(oUsuario.password)
            // oUsuario.password = passHasheada

            // digiVerificador = interfazHash.obtenerHashUsuario(oUsuario)
            // oUsuario.digitoVerificador = digiVerificador
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            try
            {
                passHasheada = interfazHash.ObtenerHash(oUsuario.Password);
                oUsuario.Password = passHasheada;

                digiVerificador = interfazHash.ObtenerHashUsuario(oUsuario);
                oUsuario.DigitoVerificador = digiVerificador;
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdHASH, oExBLL);
            }
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            List<ENTIDAD.Usuario> listaUsuarios = new List<ENTIDAD.Usuario>();
            DATOS.DALUsuario oDalUsuaio = new DATOS.DALUsuario();
            listaUsuarios = oDalUsuaio.ObtenerTablaUsuario();
            if (listaUsuarios.Count == 0)
            {
                ENTIDAD.Usuario oUsuarioColumnHash = new ENTIDAD.Usuario();
                oUsuarioColumnHash.IdUsuario = "1";
                oUsuarioColumnHash.NombreApellido = "a";
                oUsuarioColumnHash.FechaNacimiento = "a";
                oUsuarioColumnHash.CategoriaMoto = "a";
                oUsuarioColumnHash.usuario = "a";
                oUsuarioColumnHash.Password = "a";
                oUsuarioColumnHash.Estado = "es";
                listaUsuarios.Add(oUsuarioColumnHash);
            }

            listaUsuarios.Add(oUsuario);

            List<ENTIDAD.Usuario> listaUsuariosConDigitosVerif = new List<ENTIDAD.Usuario>();
            listaUsuariosConDigitosVerif = interfazHash.CalcularHashTablaUsuario(listaUsuarios);

            oDalUsuaio.InsertarUsuario(listaUsuariosConDigitosVerif);

            DATOS.DALUsuarioGrupo oDalUsuarioGrupo = new DATOS.DALUsuarioGrupo();
            List<ENTIDAD.Grupo> listadoGruposAUsuario = oUsuario.ListadoGrupos;
            IEnumerator<ENTIDAD.Grupo> enu = listadoGruposAUsuario.GetEnumerator();
            while (enu.MoveNext())
            {
                ENTIDAD.UsuarioGrupo oUsuarioGrupo = new ENTIDAD.UsuarioGrupo();
                oUsuarioGrupo.IdUsuario = System.Convert.ToInt32(oUsuario.IdUsuario);
                oUsuarioGrupo.IdGrupo = enu.Current.IdGrupo;
                oDalUsuarioGrupo.InsertarUsuarioGrupo(oUsuarioGrupo);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        public void ActualizarUsuario(ENTIDAD.Usuario oUsuario)
        {
            string passHasheada;
            string digiVerificador;
            string IdHASH = "HASH";

            DATOS.DALUsuario oDalUsuaio = new DATOS.DALUsuario();
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            try
            {
                passHasheada = interfazHash.ObtenerHash(oUsuario.Password);
                oUsuario.Password = passHasheada;

                digiVerificador = interfazHash.ObtenerHashUsuario(oUsuario);
                oUsuario.DigitoVerificador = digiVerificador;

                //UPDATE AL USUARIO CON SU NUEVA CLAVE
                oDalUsuaio.ActualizarUsuarioPorId(oUsuario);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdHASH, oExBLL);
            }
            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            //RE-CALCULAR LOS DIGITO VERIFICADORES DE USUARIOS | RESTABLECEMOS BKP CON NUEVOS DATOS
            List<ENTIDAD.Usuario> lstUsuarios = new List<ENTIDAD.Usuario>();
            lstUsuarios = oDalUsuaio.ObtenerTablaUsuario();

            List<ENTIDAD.Usuario> listaUsuarioHash = new List<ENTIDAD.Usuario>();
            listaUsuarioHash = interfazHash.CalcularHashTablaUsuario(lstUsuarios);

            oDalUsuaio.InsertarUsuarioDesdeBackup(listaUsuarioHash);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenerIdParaUsuario()
        {
            int ultimoIdUsuario = 1;

            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();
            ultimoIdUsuario = oDalUsuario.ObtenerUltimoId();

            if (ultimoIdUsuario == 0)
                ultimoIdUsuario = 1;

            ultimoIdUsuario = ultimoIdUsuario + 1;

            return ultimoIdUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public ENTIDAD.Usuario ObtenerUsuario(int idUsuario)
        {
            // Instancio el usuario que voy a pasar por parametro
            ENTIDAD.Usuario oUsuario = new ENTIDAD.Usuario();

            // Instancio DAL Usuario para obtener el usuario
            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();
            oUsuario = oDalUsuario.ObtenerUsuarioPorId(System.Convert.ToString(idUsuario));

            // Instancio el objeto UsuarioGrupo para buscar los grupos de ese usuario
            DATOS.DALUsuarioGrupo oDalUsuarioGrupo = new DATOS.DALUsuarioGrupo();
            List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo;
            listaUsuarioGrupo = oDalUsuarioGrupo.ObtenerGrupoPorIdUsuario(idUsuario);

            // Instancio una lista de grupos para el usuario
            List<ENTIDAD.Grupo> listaGrupo = new List<ENTIDAD.Grupo>();
            List<ENTIDAD.Permiso> listaPermisos = new List<ENTIDAD.Permiso>();

            // Recorro la lista y obtengo los objetos Grupo
            IEnumerator<ENTIDAD.UsuarioGrupo> enu = listaUsuarioGrupo.GetEnumerator();
            while (enu.MoveNext())
            {
                ENTIDAD.Grupo oGrupo = new ENTIDAD.Grupo();
                DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
                oGrupo = oDalGrupo.ObtenerGrupoPorId(enu.Current.IdGrupo);

                DATOS.DALGrupoPermiso oDalGrupoPermiso = new DATOS.DALGrupoPermiso();
                List<ENTIDAD.GrupoPermiso> listadoGrupoPermisos = new List<ENTIDAD.GrupoPermiso>();
                listadoGrupoPermisos = oDalGrupoPermiso.ObtenerPermisosPorIdGrupo(oGrupo.IdGrupo);

                IEnumerator<ENTIDAD.GrupoPermiso> enu2 = listadoGrupoPermisos.GetEnumerator();
                while (enu2.MoveNext())
                {
                    DATOS.DALPermiso oDalPermiso = new DATOS.DALPermiso();
                    ENTIDAD.Permiso oPermiso;
                    oPermiso = oDalPermiso.ObtenerPermisoPorId(enu2.Current.IdPermiso);
                    listaPermisos.Add(oPermiso);
                    oGrupo.ListadoPermisos = listaPermisos;
                }
                listaGrupo.Add(oGrupo);
            }
            oUsuario.ListadoGrupos = listaGrupo;

            return oUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public ENTIDAD.Usuario ObtenerUsuarioPorEmail(string email)
        {
            // Instancio el usuario que voy a pasar por parametro
            ENTIDAD.Usuario oUsuario = new ENTIDAD.Usuario();

            // Instancio DAL Usuario para obtener el usuario
            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();
            oUsuario = oDalUsuario.ObtenerUsuarioPorEmail(System.Convert.ToString(email));

            // Instancio el objeto UsuarioGrupo para buscar los grupos de ese usuario
            DATOS.DALUsuarioGrupo oDalUsuarioGrupo = new DATOS.DALUsuarioGrupo();
            List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo;
            listaUsuarioGrupo = oDalUsuarioGrupo.ObtenerGrupoPorIdUsuario(System.Convert.ToInt16(oUsuario.IdUsuario));

            // Instancio una lista de grupos para el usuario
            List<ENTIDAD.Grupo> listaGrupo = new List<ENTIDAD.Grupo>();
            List<ENTIDAD.Permiso> listaPermisos = new List<ENTIDAD.Permiso>();

            // Recorro la lista y obtengo los objetos Grupo
            IEnumerator<ENTIDAD.UsuarioGrupo> enu = listaUsuarioGrupo.GetEnumerator();
            while (enu.MoveNext())
            {
                ENTIDAD.Grupo oGrupo = new ENTIDAD.Grupo();
                DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
                oGrupo = oDalGrupo.ObtenerGrupoPorId(enu.Current.IdGrupo);

                DATOS.DALGrupoPermiso oDalGrupoPermiso = new DATOS.DALGrupoPermiso();
                List<ENTIDAD.GrupoPermiso> listadoGrupoPermisos = new List<ENTIDAD.GrupoPermiso>();
                listadoGrupoPermisos = oDalGrupoPermiso.ObtenerPermisosPorIdGrupo(oGrupo.IdGrupo);

                IEnumerator<ENTIDAD.GrupoPermiso> enu2 = listadoGrupoPermisos.GetEnumerator();
                while (enu2.MoveNext())
                {
                    DATOS.DALPermiso oDalPermiso = new DATOS.DALPermiso();
                    ENTIDAD.Permiso oPermiso;
                    oPermiso = oDalPermiso.ObtenerPermisoPorId(enu2.Current.IdPermiso);
                    listaPermisos.Add(oPermiso);
                    oGrupo.ListadoPermisos = listaPermisos;
                }
                listaGrupo.Add(oGrupo);
            }
            oUsuario.ListadoGrupos = listaGrupo;

            return oUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public ENTIDAD.Usuario ObtenerUsuarioPorCategoriaMoto(int categoriaMoto)
        {
            ENTIDAD.Usuario oUsuario = new ENTIDAD.Usuario();

            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();

            oUsuario = oDalUsuario.ObtenerUsuarioPorCategoriaMoto(System.Convert.ToString(categoriaMoto));

            // Instancio el objeto UsuarioGrupo para buscar los grupos de ese usuario
            DATOS.DALUsuarioGrupo oDalUsuarioGrupo = new DATOS.DALUsuarioGrupo();
            List<ENTIDAD.UsuarioGrupo> listaUsuarioGrupo;

            listaUsuarioGrupo = oDalUsuarioGrupo.ObtenerGrupoPorIdUsuario(System.Convert.ToInt32(oUsuario.IdUsuario));

            // Instancio una lista de grupos para el usuario
            List<ENTIDAD.Grupo> listaGrupo = new List<ENTIDAD.Grupo>();
            List<ENTIDAD.Permiso> listaPermisos = new List<ENTIDAD.Permiso>();

            // Recorro la lista y obtengo los objetos Grupo
            IEnumerator<ENTIDAD.UsuarioGrupo> enu = listaUsuarioGrupo.GetEnumerator();
            while (enu.MoveNext())
            {
                ENTIDAD.Grupo oGrupo = new ENTIDAD.Grupo();
                DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
                oGrupo = oDalGrupo.ObtenerGrupoPorId(enu.Current.IdGrupo);

                DATOS.DALGrupoPermiso oDalGrupoPermiso = new DATOS.DALGrupoPermiso();
                List<ENTIDAD.GrupoPermiso> listadoGrupoPermisos = new List<ENTIDAD.GrupoPermiso>();
                listadoGrupoPermisos = oDalGrupoPermiso.ObtenerPermisosPorIdGrupo(oGrupo.IdGrupo);

                IEnumerator<ENTIDAD.GrupoPermiso> enu2 = listadoGrupoPermisos.GetEnumerator();
                while (enu2.MoveNext())
                {
                    DATOS.DALPermiso oDalPermiso = new DATOS.DALPermiso();
                    ENTIDAD.Permiso oPermiso;
                    oPermiso = oDalPermiso.ObtenerPermisoPorId(enu2.Current.IdPermiso);
                    listaPermisos.Add(oPermiso);
                    oGrupo.ListadoPermisos = listaPermisos;
                }
                listaGrupo.Add(oGrupo);
            }
            oUsuario.ListadoGrupos = listaGrupo;

            return oUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string usuario, string password)
        {
            // Cifro la password
            string passHasheada;
            int resultadoValidacion = 0;

            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();
            string IdDB = "DB";

            try
            {
                passHasheada = interfazHash.ObtenerHash(password);
                resultadoValidacion = oDalUsuario.ValidarUsuario(usuario, passHasheada);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdDB, oExBLL);
            }

            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ValidarExistenciaUsuario(string usuario)
        {
            bool resultado = false;

            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();
            resultado = oDalUsuario.ValidarExistenciaUsuario(usuario);

            return resultado;
        }
        // ##### GRUPO #####
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public ENTIDAD.Grupo ObtenerGrupoPorId(int idGrupo)
        {

            ENTIDAD.Grupo oGrupo = new ENTIDAD.Grupo();

            DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
            oGrupo = oDalGrupo.ObtenerGrupoPorId(idGrupo);

            return oGrupo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ENTIDAD.Grupo> ObtenerGrupos()
        {
            List<ENTIDAD.Grupo> listadoGrupos = new List<ENTIDAD.Grupo>();

            DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
            listadoGrupos = oDalGrupo.ObtenerGrupos();

            return listadoGrupos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <returns></returns>
        public string ObtenerDescripcionGrupoPorNombre(string nombreGrupo)
        {
            string descripcionGrupo = "";

            DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
            descripcionGrupo = oDalGrupo.ObtenerDescripcionGrupoPorNombreGrupo(nombreGrupo);

            return descripcionGrupo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreGrupo"></param>
        /// <returns></returns>
        public ENTIDAD.Grupo ObtenerGrupoPorNombre(string nombreGrupo)
        {
            ENTIDAD.Grupo oGrupo = new ENTIDAD.Grupo();

            DATOS.DALGrupo oDalGrupo = new DATOS.DALGrupo();
            oGrupo = oDalGrupo.obtenerGrupoPorNombreGrupo(nombreGrupo);

            return oGrupo;
        }
        // ##### PERMISO #####
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPermiso"></param>
        /// <returns></returns>
        public ENTIDAD.Permiso ObtenerPermisoPorId(int idPermiso)
        {
            ENTIDAD.Permiso oPermiso = new ENTIDAD.Permiso();

            DATOS.DALPermiso oDalPermiso = new DATOS.DALPermiso();
            oPermiso = oDalPermiso.ObtenerPermisoPorId(idPermiso);

            return oPermiso;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool VerificarConsistenciaUsuarioBD()
        {
            bool estado = false;
            string IdDB = "DB";

            try
            {
                estado = interfazHash.VerificarConsistenciaUsuarioBD();
            }
            catch (EXCEPCIONES.SEGExcepcion ex)
            {
                interfazNegocioBitacora.RegistrarEnBitacora_SEG(IdDB, ex);
            }

            return estado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool EnviarRecordatorioPassword(string destinatarioEmail, string contraseñaRecuperada)
        {
            bool estado = false;
            string IdSys = "SYS";

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("motopointserviciocontacto@gmail.com");
            mail.To.Add(destinatarioEmail);

            mail.Subject = "Sistema de recuperacion de contraseña - MOTOPOINT";
            mail.Body = "Su contraseña es: " + contraseñaRecuperada;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            SmtpServer.EnableSsl = true;


            try
            {
                estado = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                estado = false;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }

            return estado;
        }
    }
}
