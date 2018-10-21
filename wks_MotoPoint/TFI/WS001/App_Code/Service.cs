using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

[WebService(Namespace = "http://motopoint.com.ar/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Boolean PagoMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular) {
        Boolean resultadoPago;

        //VALIDAR QUE TODOS LOS CAMPOS ESTEN CORRECTOS
        if (numeroTarjeta != "" && numeroSeguridad != "" && fechaValidez != "" && nombreTitular != "")
        {
            resultadoPago = true;
        }
        else
        {
            resultadoPago = false;
        }

        XmlTextWriter miEscritor = new XmlTextWriter("C:\\MotoPoint\\pagos.xml", null);
        miEscritor.Formatting = Formatting.Indented;

        miEscritor.WriteStartDocument();
        miEscritor.WriteComment("Registros pago via web!");
        miEscritor.WriteStartElement("TransaccionesPago");

        miEscritor.WriteStartElement("NumeroTarjeta");
        miEscritor.WriteString(numeroTarjeta);
        miEscritor.WriteEndElement();

        miEscritor.WriteStartElement("FechaTransaccion");
        miEscritor.WriteString(DateTime.Now.ToString());
        miEscritor.WriteEndElement();

        miEscritor.WriteStartElement("EstadoTransaccion");
        miEscritor.WriteString(resultadoPago.ToString());
        miEscritor.WriteEndElement();

        miEscritor.WriteEndDocument();
        miEscritor.Flush();
        miEscritor.Close();

        return resultadoPago;
    }
    
}