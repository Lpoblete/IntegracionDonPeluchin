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
    public partial class VerComprobantes : System.Web.UI.Page
    {
        public DataTable pagos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Pago pa = new Pago();

            pagos = pa.Listar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pago pa = new Pago();

                if (!(Fecha1.Text.Length > 0 || Fecha2.Text.Length > 0 || Fecha3.Text.Length > 0) && IDCobranza.Text.Length > 0)
                {
                    pagos = pa.ListarRutEspecifica(IDCobranza.Text);
                }
                else if (!(IDCobranza.Text.Length > 0 || Fecha2.Text.Length > 0 || Fecha3.Text.Length > 0) && Fecha1.Text.Length > 0)
                {
                    pagos = pa.ListarFechaEspecifica(Fecha1.Text);
                }
                else if (!(IDCobranza.Text.Length > 0 || Fecha1.Text.Length > 0) && Fecha2.Text.Length > 0 && Fecha3.Text.Length > 0)
                {
                    pagos = pa.ListarFechaDesdeHasta(Fecha2.Text, Fecha3.Text);
                }
                else
                {
                    pagos = pa.Listar();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}