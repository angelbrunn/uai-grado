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
    /// <summary>
    /// 
    /// </summary>
    String ruta = "C:\\MotoPoint\\pagos.xml";
    /// <summary>
    /// 
    /// </summary>
    public Service()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Boolean PagoMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular)
    {
        Boolean resultadoPago;
        String estadoTrans;

        //VALIDAR QUE TODOS LOS CAMPOS ESTEN CORRECTOS
        if (numeroTarjeta != "" && numeroSeguridad != "" && fechaValidez != "" && nombreTitular != "")
        {
            resultadoPago = true;
            estadoTrans = "PAGO REALIZADO CON EXITO";
        }
        else
        {
            resultadoPago = false;
            estadoTrans = "PAGO RECHAZADO";
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(ruta);

        XmlNode transferencia = this.CrearNodoXml(xmlDoc,numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular, estadoTrans);

        //Obtenemos el nodo raiz del documento.
        XmlNode nodoRaiz = xmlDoc.DocumentElement;

        //Insertamos el nodo transferencia al final del archivo
        nodoRaiz.InsertAfter(transferencia, nodoRaiz.LastChild);

        xmlDoc.Save(ruta);

        return resultadoPago;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="numeroTarjeta"></param>
    /// <param name="numeroSeguridad"></param>
    /// <param name="fechaValidez"></param>
    /// <param name="nombreTitular"></param>
    /// <param name="estadoTrans"></param>
    /// <returns></returns>
    private XmlNode CrearNodoXml(XmlDocument xmlDoc,string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular, string estadoTrans)
    {
        //Creamos el nodo que deseamos insertar.
        XmlElement transaccionPago = xmlDoc.CreateElement("Transacciones");

        //Creamos el elemento numeroTarjeta.
        XmlElement numTarjeta = xmlDoc.CreateElement("numeroTarjeta");
        numTarjeta.InnerText = numeroTarjeta;
        transaccionPago.AppendChild(numTarjeta);

        //Creamos el elemento numeroSeguridad.
        XmlElement numSeguridad = xmlDoc.CreateElement("numeroSeguridad");
        numSeguridad.InnerText = numeroSeguridad;
        transaccionPago.AppendChild(numSeguridad);

        //Creamos el elemento fechaValidez.
        XmlElement fecValidez = xmlDoc.CreateElement("fechaValidez");
        fecValidez.InnerText = fechaValidez;
        transaccionPago.AppendChild(fecValidez);

        //Creamos el elemento nombreTitular.
        XmlElement nomTitular = xmlDoc.CreateElement("nombreTitular");
        nomTitular.InnerText = nombreTitular;
        transaccionPago.AppendChild(nomTitular);

        //Creamos el elemento estadoTrans.
        XmlElement estado = xmlDoc.CreateElement("estadoTrans");
        estado.InnerText = estadoTrans;
        transaccionPago.AppendChild(estado);

        return transaccionPago;
    }
}