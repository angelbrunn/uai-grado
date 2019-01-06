using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace SIS.BUSINESS
{
    /// <summary>
    ///  FacadeNegocio | https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class NegNegocio : INegNegocio
    {
        //ESTE SERVICIO WEB DA SERVICIO DE COBRO
        BLL.localhost.Service ws_001 = new BLL.localhost.Service();
        /// <summary>
        /// 
        /// </summary>
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        public void RealizarCobroMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular)
        {
            Boolean realizarPagoResultado;
            realizarPagoResultado = ws_001.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoriaMoto> ObtenerCategoriaMoto()
        {
            List<CategoriaMoto> listadoCategoriaMoto = new List<CategoriaMoto>();
            DATOS.DALCategoriaMoto oDalCategoriaMoto = new DATOS.DALCategoriaMoto();
            listadoCategoriaMoto = oDalCategoriaMoto.ObtenerTablaCategoriaMoto();
            return listadoCategoriaMoto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int RegistrarMembresiaParaUsuario(string idMembresia, string idUsuario)
        {
            int resultadoValidacion = 1;
            MembresiaUsuario oMembresiaUsuario = new MembresiaUsuario();
            oMembresiaUsuario.IdMembresia = idMembresia;
            oMembresiaUsuario.IdUsuario = idUsuario;

            try
            {
                resultadoValidacion = 0;
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.InsertarMembresiaParaUsuario(oMembresiaUsuario);
            }
            catch(Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaSegunTipo(string tipoMembresia)
        {
            int idMembresia = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresia = oDalMembresia.ObtenerMembresiaSegunTipo(tipoMembresia);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresia;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaPrecio(string idMembresia)
        {
            int idMembresiaPrecio = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresiaPrecio = oDalMembresia.ObtenerMembresiaPrecio(idMembresia);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresiaPrecio;

        }
    }
}
