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
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        public void RealizarCobroMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular)
        {
            Boolean realizarPagoResultado;
            realizarPagoResultado = ws_001.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);
        }
    }
}
