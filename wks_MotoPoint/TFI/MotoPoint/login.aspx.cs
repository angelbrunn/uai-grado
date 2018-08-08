using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SIS.DATOS.DALBitacora dBitacora = new SIS.DATOS.DALBitacora();

            //TEST 1 ok
            //var id = dBitacora.ObtenerUltimoId();

            SIS.ENTIDAD.Bitacora oBitacora = new SIS.ENTIDAD.Bitacora();
            oBitacora.IdEvento = 5;
            oBitacora.IdUsuario = "6";
            oBitacora.Descripcion = "TESTDAL6";
            oBitacora.Fecha = "1/1/2011";
            oBitacora.DigitoVerificador = "1111111";
            //TEST 2 ok
            //dBitacora.RegistrarEnBitacoraBD(oBitacora);

            List<SIS.ENTIDAD.Bitacora> listBitacora = new List<SIS.ENTIDAD.Bitacora>();
            //TEST 3 ok
            //listBitacora = dBitacora.ObtenerEventos();

            List<SIS.ENTIDAD.Bitacora> listBitacora2 = new List<SIS.ENTIDAD.Bitacora>();
            SIS.ENTIDAD.Bitacora oBitacora2 = new SIS.ENTIDAD.Bitacora();
            SIS.ENTIDAD.Bitacora oBitacora3 = new SIS.ENTIDAD.Bitacora();

            oBitacora2.IdEvento = 1;
            oBitacora2.IdUsuario = "2";
            oBitacora2.Descripcion = "AAAAAAAT";
            oBitacora2.Fecha = "1/1/2012";
            oBitacora2.DigitoVerificador = "2222222";

            oBitacora3.IdEvento = 2;
            oBitacora3.IdUsuario = "3";
            oBitacora3.Descripcion = "BBBBBBBT";
            oBitacora3.Fecha = "1/1/2013";
            oBitacora3.DigitoVerificador = "33333333";

            listBitacora2.Add(oBitacora2);
            listBitacora2.Add(oBitacora3);
            //TEST 4 ok
            dBitacora.InsertarBitacoraDesdeBackup(listBitacora2);


            List<SIS.ENTIDAD.Bitacora> listBitacora3 = new List<SIS.ENTIDAD.Bitacora>();

            //TEST 5
            listBitacora3 = dBitacora.ObtenerTablaBitacora();



        }
    }
}