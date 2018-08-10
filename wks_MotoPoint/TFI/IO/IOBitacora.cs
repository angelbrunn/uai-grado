using System;
using System.Data;
using System.IO;
using System.Linq;

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
            string ruta = "C:\\MotoPoint\\log_System.txt";
            Char delimitador = '|';
            bool header = false;
            DataTable dt = new DataTable();

            System.IO.StreamReader sr = new System.IO.StreamReader(ruta);
            string[] txtlines = sr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Return nothing if there's nothing in the textfile
            if ((txtlines.Count() == 0))
            {
                return null;
            }

            int column_count = 0;
            foreach (string col in txtlines[0].Split(delimitador))
            {

                if (header)
                {
                    // If there's a header then add it by it's name
                    dt.Columns.Add(col);
                    dt.Columns[column_count].Caption = col;
                }
                else
                {
                    // If there's no header then add it by the column count
                    string valorheader = "";
                    switch (column_count)
                    {
                        case 0:
                            valorheader = "TIPO";
                            break;
                        case 1:
                            valorheader = "TABLA";
                            break;
                        case 2:
                            valorheader = "COLUMNA";
                            break;
                        case 3:
                            valorheader = "GRAVEDAD";
                            break;
                        case 4:
                            valorheader = "FECHA";
                            break;
                    }
                    dt.Columns.Add(valorheader, typeof(string));
                    dt.Columns[column_count].Caption = valorheader;
                }
                column_count++;
            }
            header = true;
            if (header)
            {
                for (int rows = 1; (rows <= (txtlines.Count() - 1)); rows++)
                {
                    // start at one because there's a header for the first line(0)
                    // Declare a new datarow
                    DataRow dr = dt.NewRow();
                    // Set the column count back to 0, we can reuse this variable ;]
                    column_count = 0;
                    foreach (string col in txtlines[rows].Split(delimitador))
                    {
                        //Each column in the row
                        // The column in cue is set for the datarow
                        dr[column_count] = col;
                        column_count++;
                    }
                    // Add the row
                    dt.Rows.Add(dr);
                }

            }
            else
            {
                for (int rows = 0; (rows <= (txtlines.Count() - 1)); rows++)
                {
                    // start at zero because there's no header
                    // Declare a new datarow
                    DataRow dr = dt.NewRow();
                    // Set the column count back to 0, we can reuse this variable ;]
                    column_count = 0;
                    foreach (string col in txtlines[rows].Split(delimitador))
                    {
                        // Each column in the row
                        // The column in cue is set for the datarow
                        dr[column_count] = col;
                        column_count++;
                    }
                    // Add the row
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
    }
}
