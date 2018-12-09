using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPCredito
{
    public partial class ConsultarTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsTarjetas.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsRegCargas.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsClientes.aspx");
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}