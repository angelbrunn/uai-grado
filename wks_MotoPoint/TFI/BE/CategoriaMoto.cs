using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.ENTIDAD
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriaMoto
    {
        /// <summary>
        /// 
        /// </summary>
        private string idCategoriaMotoField;
        /// <summary>
        /// 
        /// </summary>
        public string idCategoriaMoto
        {
            get
            {
                return idCategoriaMotoField;
            }
            set
            {
                idCategoriaMotoField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string categoriaMotoField;
        /// <summary>
        /// 
        /// </summary>
        public string categoriaMoto
        {
            get
            {
                return categoriaMotoField;
            }
            set
            {
                categoriaMotoField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string descripcionField;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return descripcionField;
            }
            set
            {
                descripcionField = value;
            }
        }
    }
}
