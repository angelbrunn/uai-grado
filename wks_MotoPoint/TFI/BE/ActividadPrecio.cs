using System;

namespace SIS.ENTIDAD
{
    public class ActividadPrecio
    {
        /// <summary>
        /// 
        /// </summary>
        private string idActividadPrecioField;
        /// <summary>
        /// 
        /// </summary>
        public string IdActividadPrecio
        {
            get
            {
                return idActividadPrecioField;
            }
            set
            {
                idActividadPrecioField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string codActField;
        /// <summary>
        /// 
        /// </summary>
        public string CodAct
        {
            get
            {
                return codActField;
            }
            set
            {
                codActField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string tituloActividadField;
        /// <summary>
        /// 
        /// </summary>
        public string TituloActividad
        {
            get
            {
                return tituloActividadField;
            }
            set
            {
                tituloActividadField = value;
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
        private string precioField;
        /// <summary>
        /// 
        /// </summary>
        public string Precio
        {
            get
            {
                return precioField;
            }
            set
            {
                precioField = value;
            }
        }
    }
}
