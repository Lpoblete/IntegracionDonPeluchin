using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;

namespace ERPCredito
{
    public partial class CrearTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime fechaHoy = DateTime.Today;
            string fecha = fechaHoy.ToString("dd/MM/yyyy");

            FechaEmision.Text = fecha;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Credito cre = new Credito();
            DataTable tablaCredito = cre.Listar();
            //select top 1 * from Credito order by ID_Credito DESC

            int acumuladorID = tablaCredito.Rows.Count + 1;

            Credito cre2 = new Credito();
            DataTable tablaCredito2 = cre2.ListarRutEspecifico(Rut.Text);

            Cliente cli = new Cliente();
            DataTable tablaCliente = cli.ListarRutEspecifico(Rut.Text);

            try
            {
                if (tablaCliente.Rows.Count > 0)
                {
                    if (!(Convert.ToDateTime(FechaEmision.Text).CompareTo(Convert.ToDateTime(Fecha1.Text)) == 1))
                    {
                        if (int.Parse(LimitCredito.Text) >= int.Parse(SaldoCredito.Text))
                        {
                            if (!(tablaCredito2.Rows.Count > 0))
                            {
                                Credito cre3 = new Credito(acumuladorID, Rut.Text, FechaEmision.Text, Fecha1.Text, int.Parse(LimitCredito.Text), int.Parse(SaldoCredito.Text), "Vigente");
                                cre3.Agregar();

                                Response.Write("<script type='text/javascript'>alert('tarjeta creada'); location.href='Consultar.aspx';</script>");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('el cliente ya posee una tarjeta, no puede tener mas de una');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script type='text/javascript'>alert('el saldo sobrepasa el limite');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('la fecha vencimiento es inferior a la fecha emision');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('no existe el cliente');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('"+ex.Message+"');</script>");
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
