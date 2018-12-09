using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;

namespace ERPCredito
{
    public partial class ConsTarjetas : System.Web.UI.Page
    {
        public DataTable tarjetas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Credito cre = new Credito();

            tarjetas = cre.Listar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultar.aspx");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Vige.Checked = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Bloq.Checked = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Credito cr = new Credito();

            string estado = "";

            if (Vige.Checked == true) { estado = "Vigente"; }
            else if (Bloq.Checked == true) { estado = "Bloqueado"; }

            if (Rut.Text.Length > 0)
            {
                tarjetas = cr.ListarRutYEstadoEspecifico(Rut.Text,estado);
            }
            else if (Fecha1.Text.Length > 0)
            {
                tarjetas = cr.ListarFechaEmiEspecifico(Fecha1.Text);
            }
            else if (Fecha2.Text.Length > 0)
            {
                tarjetas = cr.ListarFechaVencEspecifico(Fecha2.Text);
            }
            else
            {
                tarjetas = cr.Listar();
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}