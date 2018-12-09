using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;

namespace ERPCobranza
{
    public partial class Consultar : System.Web.UI.Page
    {
        public DataTable cobranzas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Cobranza co = new Cobranza();

            cobranzas = co.Listar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cobranza co = new Cobranza();

            if (!(Fecha1.Text.Length > 0 || Fecha2.Text.Length > 0 || Fecha3.Text.Length > 0) && Rut.Text.Length > 0)
            {
                cobranzas = co.ListarRutEspecifica(Rut.Text);
            }
            else if (!(Rut.Text.Length > 0 || Fecha2.Text.Length > 0 || Fecha3.Text.Length > 0) && Fecha1.Text.Length > 0)
            {
                cobranzas = co.ListarFechaEspecifica(Fecha1.Text);
            }
            else if (!(Rut.Text.Length > 0 || Fecha1.Text.Length > 0) && Fecha2.Text.Length > 0 && Fecha3.Text.Length > 0)
            {
                cobranzas = co.ListarFechaDesdeHasta(Fecha2.Text, Fecha3.Text);
            }
            else
            {
                cobranzas = co.Listar();
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
