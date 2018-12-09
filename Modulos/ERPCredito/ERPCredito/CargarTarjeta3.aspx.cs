using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPCredito
{
    public partial class CargarTarjeta3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Credito cre = new Credito();
            DataTable tablaCredito = cre.ListarRutEspecifico(Request.Params["rutCr"]);
            DataRow datosCredito = tablaCredito.Rows[0];

            rutCre.InnerText = datosCredito["Cliente_Rut"].ToString();
            limCreActual.InnerText = datosCredito["LimiteCredito"].ToString();
            saldDisponible.Text = datosCredito["Disp_Credito"].ToString();

            if (datosCredito["Estado"].ToString() == "Bloqueado")
            {
                Response.Write("<script type='text/javascript'>alert('esta tarjeta esta bloqueada'); location.href='CargarTarjeta.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(limiteCred.Text) >= int.Parse(saldDisponible.Text))
                {
                    Credito cre2 = new Credito();
                    cre2.ModificarLimite(int.Parse(limiteCred.Text), rutCre.InnerText);

                    Response.Write("<script type='text/javascript'>alert('limite credito modificado'); location.href='Consultar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('limite credito no debe ser menor que cupo disponible');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarTarjeta.aspx");
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
