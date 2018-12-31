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
        ESCRITURA.IOBitacora interfazIOBitacora = new ESCRITURA.IOBitacora();
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
            cadena = oUsuario.IdUsuario.ToString() + oUsuario.NombreApellido.ToString() + oUsuario.FechaNacimiento.ToString() + oUsuario.CategoriaMoto.ToString() + oUsuario.usuario + oUsuario.Password + oUsuario.Idioma.ToString();

            digiVerif = this.ObtenerHash(cadena);

            return digiVerif;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool VerificarConsistenciaUsuarioBD()
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
                cadena = enu.Current.IdUsuario.ToString() + enu.Current.NombreApellido + enu.Current.FechaNacimiento + enu.Current.CategoriaMoto + enu.Current.usuario + enu.Current.Password + enu.Current.Idioma;
                cadenaHasheada = this.ObtenerHash(cadena);
                hashVerificador = enu.Current.DigitoVerificador;

                resultado = cadenaHasheada.CompareTo(hashVerificador);
                if (resultado == -1)
                    contadorErroneo = contadorErroneo + 1;
            }

            // #################### DIGITO VERIFICADOR VERTICAL ####################
            int bandera = 1;

            string columnaNombreApellido = "";
            string columnaFechaNacimiento = "";
            string columnaCategoriaMoto = "";
            string columnaUsuario = "";
            string columnaPassword = "";
            string columnaIdioma = "";

            string columnaNombreApellidoHasheada = "";
            string columnaFechaNacimientoHasheada = "";
            string columnaCategoriaMotoHasheada = "";
            string columnaUsuarioHasheada = "";
            string columnaPasswordHasheada = "";
            string columnaIdiomaHasheada = "";

            string columDigiNombreApellido = "";
            string columDigiFechaNacimiento = "";
            string columDigiCategoriaMoto = "";
            string columDigiUsuario = "";
            string columDigiPassword = "";
            string columDigiIdioma = "";

            IEnumerator<ENTIDAD.Usuario> enuVert = listaUsuarios.GetEnumerator();
            while (enuVert.MoveNext())
            {
                if (bandera == 1)
                {
                    columDigiUsuario = enuVert.Current.usuario;
                    columDigiNombreApellido= enuVert.Current.NombreApellido.ToString();
                    columDigiFechaNacimiento = enuVert.Current.FechaNacimiento.ToString();
                    columDigiCategoriaMoto = enuVert.Current.CategoriaMoto.ToString();
                    columDigiPassword = enuVert.Current.Password;
                    columDigiIdioma = enuVert.Current.Idioma.ToString();
                    bandera = 2;
                }
                else
                {
                    columnaNombreApellido = columnaNombreApellido + enuVert.Current.NombreApellido.ToString();
                    columnaFechaNacimiento = columnaFechaNacimiento + enuVert.Current.FechaNacimiento.ToString();
                    columnaCategoriaMoto = columnaCategoriaMoto + enuVert.Current.CategoriaMoto.ToString();
                    columnaUsuario = columnaUsuario + enuVert.Current.usuario;
                    columnaPassword = columnaPassword + enuVert.Current.Password;
                    columnaIdioma = columnaIdioma + enuVert.Current.Idioma.ToString();
                }
            }

            columnaNombreApellidoHasheada = this.ObtenerHash(columnaNombreApellido);
            resultado = columnaNombreApellidoHasheada.CompareTo(columDigiNombreApellido);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaFechaNacimientoHasheada = this.ObtenerHash(columnaFechaNacimiento);
            resultado = columnaFechaNacimientoHasheada.CompareTo(columnaFechaNacimiento);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaCategoriaMotoHasheada = this.ObtenerHash(columnaCategoriaMoto);
            resultado = columnaCategoriaMotoHasheada.CompareTo(columnaCategoriaMoto);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaUsuarioHasheada = this.ObtenerHash(columnaUsuario);
            resultado = columnaUsuarioHasheada.CompareTo(columDigiUsuario);
            if (resultado == 1)
                contadorErroneo = contadorErroneo + 1;

            columnaPasswordHasheada = this.ObtenerHash(columnaPassword);
            resultado = columnaPasswordHasheada.CompareTo(columDigiPassword);
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool VerificarConsistenciaBitacoraBD()
        {
            bool resultadoVerificacion;
            int resultado;
            string cadena;
            string cadenaHasheada;
            string hashVerificador;
            int contadorErroneo = 0;
            List<ENTIDAD.Bitacora> listaBitacora = new List<ENTIDAD.Bitacora>();
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
            try
            {
                listaBitacora = oDalBitacora.ObtenerTablaBitacora();
            }
            catch (EXCEPCIONES.DALExcepcion ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }

            // #################### DIGITO VERIFICADOR HORIZONTAL ####################
            IEnumerator<ENTIDAD.Bitacora> enu = listaBitacora.GetEnumerator();
            while (enu.MoveNext())
            {
                cadena = "";
                cadenaHasheada = "";
                cadena = (enu.Current.IdEvento.ToString()
                            + (enu.Current.IdUsuario
                            + (enu.Current.Descripcion + enu.Current.Fecha)));
                cadenaHasheada = this.ObtenerHash(cadena);
                hashVerificador = enu.Current.DigitoVerificador;
                resultado = cadenaHasheada.CompareTo(hashVerificador);
                if ((resultado == -1))
                {
                    contadorErroneo = (contadorErroneo + 1);
                }

            }

            // #################### DIGITO VERIFICADOR VERTICAL ####################
            int bandera = 1;
            string columnaIdUsuario = "";
            string columnaDescripcion = "";
            string columnaFecha = "";
            string columnaIdUsuarioHasheada = "";
            string columnaDescripciondHasheada = "";
            string columnaFechaHasheada = "";
            string columDigiIdUsuario = "";
            string columDigiDescripcion = "";
            string columDigiFecha = "";
            IEnumerator<ENTIDAD.Bitacora> enuVert = listaBitacora.GetEnumerator();
            while (enuVert.MoveNext())
            {
                if ((bandera == 1))
                {
                    columDigiIdUsuario = enuVert.Current.IdUsuario;
                    columDigiDescripcion = enuVert.Current.Descripcion;
                    columDigiFecha = enuVert.Current.Fecha;
                    bandera = 2;
                }
                else
                {
                    columnaIdUsuario = (columnaIdUsuario + enuVert.Current.IdUsuario);
                    columnaDescripcion = (columnaDescripcion + enuVert.Current.Descripcion);
                    columnaFecha = (columnaFecha + enuVert.Current.Fecha);
                }

            }

            columnaIdUsuarioHasheada = this.ObtenerHash(columnaIdUsuario);
            resultado = columnaIdUsuarioHasheada.CompareTo(columDigiIdUsuario);
            if ((resultado == 1))
            {
                contadorErroneo = (contadorErroneo + 1);
                interfazIOBitacora.RegistrarLogSystem("TBL_BITACORA", "COL_USUARIOS");
            }

            columnaDescripciondHasheada = this.ObtenerHash(columnaDescripcion);
            resultado = columnaDescripciondHasheada.CompareTo(columDigiDescripcion);
            if ((resultado == 1))
            {
                contadorErroneo = (contadorErroneo + 1);
                interfazIOBitacora.RegistrarLogSystem("TBL_BITACORA", "COL_DESCRIPCION");
            }

            columnaFechaHasheada = this.ObtenerHash(columnaFechaHasheada);
            resultado = columnaFechaHasheada.CompareTo(columDigiFecha);
            if ((resultado == 1))
            {
                contadorErroneo = (contadorErroneo + 1);
                interfazIOBitacora.RegistrarLogSystem("TBL_BITACORA", "COL_FECHA");
            }

            // ###### EVALUACION FINAL ######
            // Evaluaci�n final para saber si hubo algun error de comprobaci�n
            // en los digitos verificadores tanto verticales como horizontales.
            if ((contadorErroneo == 0))
            {
                resultadoVerificacion = true;
            }
            else
            {
                resultadoVerificacion = false;
            }

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
            string columnaNombreApellido = "";
            string columnaFechaNacimiento = "";
            string columnaCategoriaMoto = "";

            string columnaUsuario = "";
            string columnaPassword = "";
            string columnaIdioma = "";

            string columDigiIdUsuario = "";
            string columDigiNombreApellido = "";
            string columDigiUsuario = "";
            string columDigiPassword = "";
            string columDigiIdioma = "";

            IEnumerator<ENTIDAD.Usuario> enuVert = listaUsuarios.GetEnumerator();
            while (enuVert.MoveNext())
            {
                if (enuVert.Current.IdUsuario == "1")
                {
                }
                else
                {
                    columnaNombreApellido = columnaNombreApellido + enuVert.Current.NombreApellido.ToString();
                    columnaFechaNacimiento = columnaFechaNacimiento + enuVert.Current.FechaNacimiento.ToString();
                    columnaCategoriaMoto = columnaCategoriaMoto + enuVert.Current.CategoriaMoto.ToString();
                    columnaUsuario = columnaUsuario + enuVert.Current.usuario;
                    columnaPassword = columnaPassword + enuVert.Current.Password;
                    columnaIdioma = columnaIdioma + enuVert.Current.Idioma.ToString();
                }
            }

            IEnumerator<ENTIDAD.Usuario> enuVert2 = listaUsuarios.GetEnumerator();
            while (enuVert2.MoveNext())
            {
                if (enuVert2.Current.IdUsuario == "1")
                {
                    // No hay digito verificador de la PK
                    enuVert2.Current.NombreApellido = this.ObtenerHash(columnaNombreApellido);
                    enuVert2.Current.FechaNacimiento = this.ObtenerHash(columnaFechaNacimiento);
                    enuVert2.Current.CategoriaMoto = this.ObtenerHash(columnaCategoriaMoto);
                    enuVert2.Current.usuario = this.ObtenerHash(columnaUsuario);
                    enuVert2.Current.Password = this.ObtenerHash(columnaPassword);
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
                cadena = enu.Current.IdUsuario.ToString() + enu.Current.NombreApellido + enu.Current.FechaNacimiento + enu.Current.CategoriaMoto + enu.Current.usuario + enu.Current.Password + enu.Current.Idioma;
                cadenaHasheada = this.ObtenerHash(cadena);
                enu.Current.DigitoVerificador = cadenaHasheada;
            }
            
            return listaUsuarioHash;
        }
        /// <summary>
        /// 
        /// </summary>
        public void CalcularHashTablaBitacora()
        {
            ENTIDAD.Bitacora oUpdateBitacora = new ENTIDAD.Bitacora();
            DATOS.DALBitacora oDalBitacora = new DATOS.DALBitacora();
            List<ENTIDAD.Bitacora> listaBitacora = new List<ENTIDAD.Bitacora>();
            try
            {
                listaBitacora = oDalBitacora.ObtenerTablaBitacora();
            }
            catch (EXCEPCIONES.DALExcepcion ex)
            {
                throw new EXCEPCIONES.BLLExcepcion(ex.Message);
            }

            // #################### DIGITO VERIFICADOR VERTICAL ####################
            int bandera = 1;
            string columnaIdUsuario = "";
            string columnaDescripcion = "";
            string columnaFecha = "";
            string columnaDigitoVerficador = "";
            string columnaIdUsuarioHasheada = "";
            string columnaDescripciondHasheada = "";
            string columnaFechaHasheada = "";
            string columnaDigitoVerficadorHasheada = "";
            string columDigiIdUsuario = "";
            string columDigiDescripcion = "";
            string columDigiFecha = "";
            string columnaDigiIdEvento = "";
            IEnumerator<ENTIDAD.Bitacora> enuVert = listaBitacora.GetEnumerator();
            while (enuVert.MoveNext())
            {
                if ((bandera == 1))
                {
                    columnaDigiIdEvento = enuVert.Current.IdEvento.ToString();
                    columDigiIdUsuario = enuVert.Current.IdUsuario;
                    columDigiDescripcion = enuVert.Current.Descripcion;
                    columDigiFecha = enuVert.Current.Fecha;
                    bandera = 2;
                }
                else
                {
                    columnaIdUsuario = (columnaIdUsuario + enuVert.Current.IdUsuario);
                    columnaDescripcion = (columnaDescripcion + enuVert.Current.Descripcion);
                    columnaFecha = (columnaFecha + enuVert.Current.Fecha);
                }

            }
            
            // ARQ.BASE - CALCULAMOS LOS NUEVOS VALORES DE DIGITOS VERIFICADORES
            columnaIdUsuarioHasheada = this.ObtenerHash(columnaIdUsuario);
            columnaDescripciondHasheada = this.ObtenerHash(columnaDescripcion);
            columnaFechaHasheada = this.ObtenerHash(columnaFechaHasheada);
            object headerVerificador = (columnaDigiIdEvento
                        + (columnaIdUsuarioHasheada
                        + (columnaDescripciondHasheada + columnaFechaHasheada)));
            columnaDigitoVerficadorHasheada = this.ObtenerHash(System.Convert.ToString(headerVerificador));
            oUpdateBitacora.IdEvento = 1;
            oUpdateBitacora.IdUsuario = columnaIdUsuarioHasheada;
            oUpdateBitacora.Descripcion = columnaDescripciondHasheada;
            oUpdateBitacora.Fecha = columnaFechaHasheada;
            oUpdateBitacora.DigitoVerificador = columnaDigitoVerficadorHasheada;
            // ARQ.BASE - ACTUALIZO LA TABLA DE BITACORA CON LOS DIG. VERIFICADORES
            oDalBitacora.ActualizarDigitoVerificadorBitacora(oUpdateBitacora);
        }
    }
}
