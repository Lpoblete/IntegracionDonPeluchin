using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace ERPCredito
{
    public partial class ConsRegCargas : System.Web.UI.Page
    {
        public DataTable cargas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Carga car = new Carga();

            cargas = car.Listar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultar.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Carga ca = new Carga();

            if (Rut.Text.Length > 0)
            {
                cargas = ca.ListarRutEspecifico(Rut.Text);
            }
            else if (Fecha1.Text.Length > 0)
            {
                cargas = ca.ListarFechaEspecifica(Fecha1.Text);
            }
            else
            {
                cargas = ca.Listar();
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
