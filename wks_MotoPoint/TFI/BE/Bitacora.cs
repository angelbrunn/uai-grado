﻿using System;

namespace SIS.ENTIDAD
{
    /// <summary>
    /// 
    /// </summary>
    public class Bitacora
    {
        /// <summary>
        /// 
        /// </summary>
        public Bitacora()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        private int idEventoField;
        /// <summary>
        /// 
        /// </summary>
        public int IdEvento
        {
            get
            {
                return idEventoField;
            }
            set
            {
                idEventoField = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private String idUsuarioField;
        /// <summary>
        /// 
        /// </summary>
        public String IdUsuario
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
        private String fechaField;
        /// <summary>
        /// 
        /// </summary>
        public String Fecha
        {
            get
            {
                return fechaField;
            }
            set
            {
                fechaField = value;
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
        private string digitoVerificador;
        /// <summary>
        /// 
        /// </summary>
        public string DigitoVerificador
        {
            get
            {
                return digitoVerificador;
            }
            set
            {
                digitoVerificador = value;
            }
        }
    }
}
