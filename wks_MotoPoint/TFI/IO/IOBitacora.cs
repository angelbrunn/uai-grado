using System;
using System.Data;
using System.IO;

namespace SIS.ESCRITURA
{
    /// <summary>
    /// 
    /// </summary>
    public class IOBitacora
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oBitacora"></param>
        public void RegistrarEnBitacoraIO(ENTIDAD.Bitacora oBitacora)
        {
            string delimitador = ";";
            string ruta = @"C:\Logs MotoPoint\log.csv";
            string cabecera = "idEvento" + delimitador + "idUsuario" + delimitador + "descripcion" + delimitador + "fecha";
            try
            {
                StreamWriter archivo = new StreamWriter(ruta, true);
                archivo.WriteLine(cabecera);
                string linea;
                string idEvento = oBitacora.IdEvento.ToString();
                string idUsuario = oBitacora.IdUsuario.ToString();
                string descripcion = oBitacora.Descripcion.ToString();
                string fecha = oBitacora.Fecha.ToString();
                linea = idEvento + delimitador + idUsuario + delimitador
                + descripcion + delimitador + fecha;
                archivo.WriteLine(linea);
                archivo.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorTabla"></param>
        /// <param name="errorColumna"></param>
        public void RegistrarLogSystem(string errorTabla, string errorColumna)
        {
            string delimitador = "|";
            string ruta = "C:\\MotoPoint\\log_System.txt";
            try
            {
                StreamWriter archivo = new StreamWriter(ruta, true);
                string linea;
                string ERROR_TABLA = errorTabla;
                string ERROR_COLUMNA = errorColumna;
                string ERROR_FECHA = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                linea = ("ERROR"
                            + (delimitador
                            + (ERROR_TABLA
                            + (delimitador
                            + (ERROR_COLUMNA
                            + (delimitador + ("SE PRODUJO ERROR CRITICO"
                            + (delimitador + ERROR_FECHA))))))));
                archivo.WriteLine(linea);
                archivo.Close();
            }
            catch (Exception ex)
            {
                throw new EXCEPCIONES.IOException(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTable LeerLogSystem()
        {
            DataTable dt = new DataTable();

            return dt;
        }
    }
}
