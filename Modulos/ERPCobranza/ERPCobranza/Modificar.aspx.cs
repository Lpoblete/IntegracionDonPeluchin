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
    public partial class Modificar2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cobranza cob = new Cobranza();

                DataRow datosCobranza;
                DataTable tablaCobranza = cob.ListarIDCobranzaEspecifica(int.Parse(IDCobranza.Text));

                if(tablaCobranza.Rows.Count > 0)
                {
                    datosCobranza = tablaCobranza.Rows[0];

                if(datosCobranza["MetodoPago"].ToString() == "Tarjeta" && datosCobranza["Estado"].ToString() == "Pendiente")
                {
                    Response.Redirect("Modificar2.aspx?idco=" + IDCobranza.Text);
                }
                else
                {
                        Response.Write("<script type='text/javascript'>alert('solamente se puede modificar cobranzas con metodo de pago tarjeta y que esten pendientes');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('el id que has ingresado no existe');</script>");
                }
            }
            catch (Exception ex)
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
