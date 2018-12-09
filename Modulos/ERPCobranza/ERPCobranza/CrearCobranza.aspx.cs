using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;

namespace ERPCobranza
{
    public partial class CrearCobranza : System.Web.UI.Page
    {
        public DataTable facturas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Factura fa = new Factura();

            facturas = fa.Listar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cobranza cob = new Cobranza();
                Factura fac = new Factura();

                DataTable tablaCobranza = cob.ListarNOFacturaEspecifica(int.Parse(NumFactura.Text));
                DataTable tablaFactura = fac.ListarNOFacturaEspecifico(int.Parse(NumFactura.Text));

                if (fac.BuscarNOFactura(int.Parse(NumFactura.Text)))
                {
                if (tablaCobranza.Rows.Count > 0)
                {
                   DataRow datosFac = tablaFactura.Rows[0];
                   DataRow datosCob = tablaCobranza.Rows[0];

                    if (!(datosCob["Factura_NO"].ToString() == datosFac["NoFactura"].ToString()))
                    {
                            Response.Redirect("CrearCobranza2.aspx?nfactu=" + NumFactura.Text);
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('este numero de factura ya esta cobrado');</script>");
                    }
                }
                else
                {
                        Response.Redirect("CrearCobranza2.aspx?nfactu=" + NumFactura.Text);
                }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('el numero que has ingresado no existe');</script>");
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
