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
    public partial class CargarTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Credito cre = new Credito();
            DataTable tablaCredito = cre.ListarRutEspecifico(Rut.Text);

            if(tablaCredito.Rows.Count > 0)
            {
                if(EfectuarCupo.Checked == true)
                {
                    Response.Redirect("CargarTarjeta2.aspx?rutCr=" + Rut.Text);
                }
                else if(AumentarCupo.Checked == true)
                {
                    Response.Redirect("CargarTarjeta3.aspx?rutCr=" + Rut.Text);
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('no existe tarjeta');</script>");
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }

        protected void AumentarCupo_CheckedChanged(object sender, EventArgs e)
        {
            EfectuarCupo.Checked = false;
        }

        protected void EfectuarCupo_CheckedChanged(object sender, EventArgs e)
        {
            AumentarCupo.Checked = false;
        }
    }
}
