﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;

namespace ERPCobranza
{
    public partial class CobranzaPendiente : System.Web.UI.Page
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

                string metPago = "";

                if (tablaCobranza.Rows.Count > 0)
                {
                    datosCobranza = tablaCobranza.Rows[0];

                    if (datosCobranza["Estado"].ToString() == "Pendiente")
                    {
                        if (datosCobranza["MetodoPago"].ToString() == "Efectivo") { metPago = "efectivo"; }
                        else if (datosCobranza["MetodoPago"].ToString() == "Tarjeta") { metPago = "tarjeta"; }
                        Response.Redirect("CobranzaPendiente2.aspx?idco=" + IDCobranza.Text+ "&metpa=" + metPago);
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('solamente se puede cobrar cobranzas que esten pendientes');</script>");
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
