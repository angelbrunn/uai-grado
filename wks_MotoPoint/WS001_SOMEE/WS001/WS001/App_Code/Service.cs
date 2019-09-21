using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public string GetData(int value)
    {
        throw new NotImplementedException();
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        throw new NotImplementedException();
    }

    [WebMethod]
    public Boolean PagoMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular)
    {
        Boolean resultadoPago;
        string estadoTrans;

        /* ONLY DEV MODE */
        //VALIDAR QUE TODOS LOS CAMPOS ESTEN CORRECTOS
        if (numeroTarjeta != "" && numeroSeguridad != "" && fechaValidez != "" && nombreTitular != "")
        {
            switch (numeroTarjeta.Substring(0, 4))
            {
                case "4338":
                    Console.WriteLine("PAGO CON VISA");
                    resultadoPago = true;
                    estadoTrans = "PAGO REALIZADO CON EXITO";
                    break;
                case "3777":
                    Console.WriteLine("PAGO CON AMEX");
                    resultadoPago = true;
                    estadoTrans = "PAGO REALIZADO CON EXITO";
                    break;
                case "5323":
                    Console.WriteLine("PAGO CON MS");
                    resultadoPago = true;
                    estadoTrans = "PAGO REALIZADO CON EXITO";
                    break;
                default:
                    Console.WriteLine("Invalid Card");
                    resultadoPago = false;
                    estadoTrans = "PAGO RECHAZADO";
                    break;
            }
        }
        else
        {
            resultadoPago = false;
            estadoTrans = "PAGO RECHAZADO";
        }

        return resultadoPago;
    }
}
