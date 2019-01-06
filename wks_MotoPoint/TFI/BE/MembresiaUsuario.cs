using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.ENTIDAD
{
    public class MembresiaUsuario
    {
        /// <summary>
        /// 
        /// </summary>
        private string idMembresiaField;
        /// <summary>
        /// 
        /// </summary>
        public string IdMembresia
        {
            get
            {
                return idMembresiaField;
            }
            set
            {
                idMembresiaField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string idUsuarioField;
        /// <summary>
        /// 
        /// </summary>
        public string IdUsuario
        {
            get
            {
                return idUsuarioField;
            }
            set
            {
                idUsuarioField = value;
            }
        }
    }
}
