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
    public class PagoUsuario
    {
        /// <summary>
        /// 
        /// </summary>
        public PagoUsuario()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        private int idNumeroOrdenField;
        /// <summary>
        /// 
        /// </summary>
        public int IdNumeroOrden
        {
            get
            {
                return idNumeroOrdenField;
            }
            set
            {
                idNumeroOrdenField = value;
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
        /// <summary>
        /// 
        /// </summary>
        private string nombreApellidoField;
        /// <summary>
        /// 
        /// </summary>
        public string NombreApellido
        {
            get
            {
                return nombreApellidoField;
            }
            set
            {
                nombreApellidoField = value;
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
        /// <summary>
        /// 
        /// </summary>
        private string montoField;
        /// <summary>
        /// 
        /// </summary>
        public string Monto
        {
            get
            {
                return montoField;
            }
            set
            {
                montoField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string fechaPagoField;
        /// <summary>
        /// 
        /// </summary>
        public string FechaPago
        {
            get
            {
                return fechaPagoField;
            }
            set
            {
                fechaPagoField = value;
            }
        }
    }
}
