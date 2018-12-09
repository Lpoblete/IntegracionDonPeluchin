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
    public partial class BloquearTarjeta : System.Web.UI.Page
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
                Credito cre2 = new Credito();

                if (Bloqueado.Checked == true)
                {
                    cre2.ModificarEstado("Bloqueado", Rut.Text);
                    Response.Write("<script type='text/javascript'>alert('tarjeta en estado bloqueado'); location.href='Consultar.aspx';</script>");
                }
                else if (Vigente.Checked == true)
                {
                    cre2.ModificarEstado("Vigente", Rut.Text);
                    Response.Write("<script type='text/javascript'>alert('tarjeta en estado vigente'); location.href='Consultar.aspx';</script>");
                }
                else if(Vigente.Checked == false || Bloqueado.Checked == false)
                {
                    Response.Write("<script type='text/javascript'>alert('elija un estado');</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('no existe tarjeta');</script>");
            }
        }

        protected void Bloqueado_CheckedChanged(object sender, EventArgs e)
        {
            Vigente.Checked = false;
        }

        protected void Vigente_CheckedChanged(object sender, EventArgs e)
        {
            Bloqueado.Checked = false;
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}