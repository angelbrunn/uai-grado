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
            SIS.DATOS.DALGrupo dDALGrupo = new SIS.DATOS.DALGrupo();

            List<SIS.ENTIDAD.Grupo> listGrupo = new List<SIS.ENTIDAD.Grupo>();

            //TEST1
            listGrupo = dDALGrupo.ObtenerGrupos();

            SIS.ENTIDAD.Grupo oGrupo1 = new SIS.ENTIDAD.Grupo();

            //TEST2
            oGrupo1 = dDALGrupo.ObtenerGrupoPorId(1);

            //TEST3
            String nombre = dDALGrupo.ObtenerDescripcionGrupoPorNombreGrupo("Admin");

            SIS.ENTIDAD.Grupo oGrupo2 = new SIS.ENTIDAD.Grupo();

            //TEST4
            oGrupo2 = dDALGrupo.obtenerGrupoPorNombreGrupo("Admin");


        }
    }
}