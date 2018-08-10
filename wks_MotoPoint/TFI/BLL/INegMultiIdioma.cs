using System.Collections.Generic;

namespace SIS.BUSINESS
{
    public interface INegMultiIdioma
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        List<ENTIDAD.MultiIdioma> ObtenerTablaMultiIdioma(string idioma);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ENTIDAD.MultiIdioma> ObtenerIdiomasDisponibles();
    }
}
