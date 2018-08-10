using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SIS.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class Hash : IHash
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCadena"></param>
        /// <returns></returns>
        public string GenerarSHA(string sCadena)
        {

            // Objeto de codificación
            UnicodeEncoding ueCodigo = new UnicodeEncoding();

            // Objeto para instanciar las codificación
            SHA256Managed SHA = new SHA256Managed();

            // Calcula el valor hash de la cadena recibida
            byte[] bHash = SHA.ComputeHash(ueCodigo.GetBytes(sCadena));

            // Convierte el hash en una cadena y lo devuelve
            return Convert.ToBase64String(bHash);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string ObtenerHash(string cadena)
        {
            string cadenaHasheada;

            IHash interfazHash = new Hash();
            cadenaHasheada = interfazHash.GenerarSHA(cadena);

            return cadenaHasheada;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        /// <returns></returns>
        public string ObtenerHashUsuario(ENTIDAD.Usuario oUsuario)
        {
            string digiVerif = "ERROR";

            string cadena;
            cadena = oUsuario.IdUsuario.ToString() + oUsuario.usuario + oUsuario.Password + oUsuario.Legajo.ToString() + oUsuario.Idioma.ToString();

            digiVerif = this.ObtenerHash(cadena);

            return digiVerif;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool VerificarConsistenciaBD()
        {
            bool resultadoVerificacion = true;
            
            int resultado;
            string cadena;
            string cadenaHasheada;
            string hashVerificador;
            int contadorErroneo = 0;
            List<ENTIDAD.Usuario> listaUsuarios = new List<ENTIDAD.Usuario>();

            DATOS.DALUsuario oDalUsuario = new DATOS.DALUsuario();

            try
            {
                listaUsuarios = oDalUsuario.ObtenerTablaUsuario();
            }
            catch (EXCEPCIONES.DALExcepcion ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }
            // #################### DIGITO VERIFICADOR HORIZONTAL ####################
            IEnumerator<ENTIDAD.Usuario> enu = listaUsuarios.GetEnumerator();
            while (enu.MoveNext())
            {
                cadena = "";
                cadenaHasheada = "";
                cadena = enu.Current.IdUsuario.ToString() + enu.Current.usuario + enu.Current.Password + enu.Current.Legajo + enu.Current.Idioma;
                cadenaHasheada = this.ObtenerHash(cadena);
                hashVerificador = enu.Current.DigitoVerificador;

                resultado = cadenaHasheada.CompareTo(hashVerificador);
                if (resultado == -1)
                    contadorErroneo = contadorErroneo + 1;
            }

            // #################### DIGITO VERIFICADOR VERTICAL ####################
            int bandera = 1;

            string columnaUsuario = "";
            string columnaPassword = "";
            string columnaLegajo = "";
            string columnaIdioma = "";

            string columnaUsuarioHasheada = "";
            string columnaPasswordHasheada = "";
            string columnaLegajoHasheada = "";
            string columnaIdiomaHasheada = "";

            string columDigiUsuario = "";
            string columDigiPassword = "";
            string columDigiLegajo = "";
            string columDigiIdioma = "";

            IEnumerator<ENTIDAD.Usuario> enuVert = listaUsuarios.GetEnumerator();
            while (enuVert.MoveNext())
            {
                if (bandera == 1)
                {
                    columDigiUsuario = enuVert.Current.usuario;
                    columDigiPassword = enuVert.Current.Password;
                    columDigiLegajo = enuVert.Current.Legajo.ToString();
                    columDigiIdioma = enuVert.Current.Idioma.ToString();
                    bandera = 2;
                }
                else
                {
                    columnaUsuario = columnaUsuario + enuVert.Current.usuario;
                    columnaPassword = columnaPassword + enuVert.Current.Password;
                    columnaLegajo = columnaLegajo + enuVert.Current.Legajo.ToString();
                    columnaIdioma = columnaIdioma + enuVert.Current.Idioma.ToString();
                }
            }

            columnaUsuarioHasheada = this.ObtenerHash(columnaUsuario);
            resultado = columnaUsuarioHasheada.CompareTo(columDigiUsuario);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaPasswordHasheada = this.ObtenerHash(columnaPassword);
            resultado = columnaPasswordHasheada.CompareTo(columDigiPassword);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaLegajoHasheada = this.ObtenerHash(columnaLegajo);
            resultado = columnaLegajoHasheada.CompareTo(columDigiLegajo);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaIdiomaHasheada = this.ObtenerHash(columnaIdioma);
            resultado = columnaIdiomaHasheada.CompareTo(columDigiIdioma);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            // ###### EVALUACION FINAL ######
            // Evaluación final para saber si hubo algun error de comprobación
            // en los digitos verificadores tanto verticales como horizontales.

            if (contadorErroneo == 0)
                resultadoVerificacion = true;
            else
                resultadoVerificacion = false;
            
            return resultadoVerificacion;
        }
        /// <summary>
        ///         ''' 
        ///         ''' </summary>
        ///         ''' <param name="listaUsuarios"></param>
        ///         ''' <returns></returns>
        ///         ''' <remarks></remarks>
        public List<ENTIDAD.Usuario> CalcularHashTablaUsuario(List<ENTIDAD.Usuario> listaUsuarios)
        {
            List<ENTIDAD.Usuario> listaUsuarioHash = new List<ENTIDAD.Usuario>();
            
            // #################### DIGITO VERIFICADOR VERTICAL ####################
            string columnaIdUsuario = "";
            string columnaUsuario = "";
            string columnaPassword = "";
            string columnaLegajo = "";
            string columnaIdioma = "";

            string columDigiIdUsuario = "";
            string columDigiUsuario = "";
            string columDigiPassword = "";
            string columDigiLegajo = "";
            string columDigiIdioma = "";

            IEnumerator<ENTIDAD.Usuario> enuVert = listaUsuarios.GetEnumerator();
            while (enuVert.MoveNext())
            {
                if (enuVert.Current.IdUsuario == "1")
                {
                }
                else
                {
                    columnaUsuario = columnaUsuario + enuVert.Current.usuario;
                    columnaPassword = columnaPassword + enuVert.Current.Password;
                    columnaLegajo = columnaLegajo + enuVert.Current.Legajo.ToString();
                    columnaIdioma = columnaIdioma + enuVert.Current.Idioma.ToString();
                }
            }

            IEnumerator<ENTIDAD.Usuario> enuVert2 = listaUsuarios.GetEnumerator();
            while (enuVert2.MoveNext())
            {
                if (enuVert2.Current.IdUsuario == "1")
                {
                    // No hay digito verificador de la PK
                    enuVert2.Current.usuario = this.ObtenerHash(columnaUsuario);
                    enuVert2.Current.Password = this.ObtenerHash(columnaPassword);
                    enuVert2.Current.Legajo = this.ObtenerHash(columnaLegajo);
                    enuVert2.Current.Idioma = this.ObtenerHash(columnaIdioma);
                }
            }

            listaUsuarioHash = listaUsuarios;

            string cadena = "";
            string cadenaHasheada = "";

            // #################### DIGITO VERIFICADOR HORIZONTAL ####################
            IEnumerator<ENTIDAD.Usuario> enu = listaUsuarios.GetEnumerator();
            while (enu.MoveNext())
            {
                cadena = "";
                cadenaHasheada = "";
                cadena = enu.Current.IdUsuario.ToString() + enu.Current.usuario + enu.Current.Password + enu.Current.Legajo + enu.Current.Idioma;
                cadenaHasheada = this.ObtenerHash(cadena);
                enu.Current.DigitoVerificador = cadenaHasheada;
            }
            
            return listaUsuarioHash;
        }
    }
}
