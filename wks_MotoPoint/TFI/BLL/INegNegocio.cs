using SIS.ENTIDAD;
using System.Collections.Generic;

namespace SIS.BUSINESS
{
    public interface INegNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        void RealizarCobroMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular);
        /// <summary>
        /// 
        /// </summary>
        List<CategoriaMoto> ObtenerCategoriaMoto();
    }
}
