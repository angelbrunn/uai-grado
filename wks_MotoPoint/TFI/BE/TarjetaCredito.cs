namespace SIS.ENTIDAD
{
    /// <summary>
    /// 
    /// </summary>
    public class TarjetaCredito
    {
        /// <summary>
        /// 
        /// </summary>
        private string numeroTarjetaField;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroTarjeta
        {
            get
            {
                return numeroTarjetaField;
            }
            set
            {
                numeroTarjetaField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string numeroSeguridadField;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroSeguridad
        {
            get
            {
                return numeroSeguridadField;
            }
            set
            {
                numeroSeguridadField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string fechaValidezField;
        /// <summary>
        /// 
        /// </summary>
        public string FechaValidez
        {
            get
            {
                return fechaValidezField;
            }
            set
            {
                fechaValidezField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string nombreTitularField;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTitular
        {
            get
            {
                return nombreTitularField;
            }
            set
            {
                nombreTitularField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string saldoField;
        /// <summary>
        /// 
        /// </summary>
        public string Saldo
        {
            get
            {
                return saldoField;
            }
            set
            {
                saldoField = value;
            }
        }
    }
}
