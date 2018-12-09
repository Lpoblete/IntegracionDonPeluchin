using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace ERPCobranza
{
    public partial class Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cobranza cob = new Cobranza();
            DataTable tablaCobranza = cob.ListarIDCobranzaEspecifica(int.Parse(Request.Params["idco"]));
            DataRow datosCobranza = tablaCobranza.Rows[0];

            IDcobranza.InnerText = datosCobranza["ID_Cobranza"].ToString();
            NOfactura.InnerText = datosCobranza["Factura_NO"].ToString();
            Cliente.InnerText = datosCobranza["Nombre_Cliente"].ToString();
            metPago.InnerText = datosCobranza["MetodoPago"].ToString();
            numCuotas.InnerText = datosCobranza["NumCuotas"].ToString();

            Factura fac = new Factura();
            DataTable tablaFactura = fac.ListarNOFacturaEspecifico(int.Parse(datosCobranza["Factura_NO"].ToString()));
            DataRow datosFactura = tablaFactura.Rows[0];

            montTotal.Text = datosFactura["Total"].ToString();

            Credito cre = new Credito();
            DataTable tablaCredito = cre.ListarRutEspecifico(datosCobranza["Cliente_Rut"].ToString());
            DataRow datosCredito = tablaCredito.Rows[0];

            saldTarjeta.InnerText = datosCredito["Disp_Credito"].ToString();

            Cuotas cuo = new Cuotas();
            DataTable tablaCuotas = cuo.ListarIDCobranzaEspecifica(int.Parse(datosCobranza["ID_Cobranza"].ToString()));
            DataRow datosCuotas;

            HtmlTableRow[] cuotasDatos = new HtmlTableRow[3];

            cuotasDatos[0] = cuot1;
            cuotasDatos[1] = cuot2;
            cuotasDatos[2] = cuot3;

            TextBox[] cuotas = new TextBox[3];
            cuotas[0] = Cuota1;
            cuotas[1] = Cuota2;
            cuotas[2] = Cuota3;

            TextBox[] fechas = new TextBox[3];
            fechas[0] = Fecha1;
            fechas[1] = Fecha2;
            fechas[2] = Fecha3;

            HtmlInputText[] fechasOcultas = new HtmlInputText[3];
            fechasOcultas[0] = FechaOculta1;
            fechasOcultas[1] = FechaOculta2;
            fechasOcultas[2] = FechaOculta3;

            for (int i=0;i<int.Parse(numCuotas.InnerText); i++)
            {
                datosCuotas = tablaCuotas.Rows[i];

                if (datosCuotas["Estado"].ToString() == "Pendiente")
                {
                    cuotasDatos[i].Visible = true;
                    cuotas[i].Text = datosCuotas["Monto"].ToString();
                    fechas[i].Text = datosCuotas["Fecha"].ToString();
                }
                else
                {
                    cuotasDatos[i].Visible = false;
                    cuotas[i].Text = datosCuotas["Monto"].ToString();
                    fechasOcultas[i].Value = datosCuotas["Fecha"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime fechaHoy = DateTime.Today;
            string fecha = fechaHoy.ToString("dd/MM/yy");
            DateTime fechaHoy2 = DateTime.Today;
            string fecha2 = fechaHoy2.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            Cuotas cuo = new Cuotas();
            DataTable tablaCuotas = cuo.ListarIDCobranzaEspecifica(int.Parse(IDcobranza.InnerText));
            DataRow datosCuotas;

            string[] fechas = new string[3];

            if (int.Parse(numCuotas.InnerText) == 1)
            {
                fechas = new string[3];
                fechas[0] = FechaOculta1.Value;
                fechas[1] = "28/12/9999";
                fechas[2] = "28/12/9999";
            }
            else if (int.Parse(numCuotas.InnerText) == 2)
            {
                fechas = new string[3];
                fechas[0] = FechaOculta1.Value;
                fechas[1] = FechaOculta2.Value;
                fechas[2] = "28/12/9999";
            }
            else if (int.Parse(numCuotas.InnerText) == 3)
            {
                fechas = new string[3];
                fechas[0] = FechaOculta1.Value;
                fechas[1] = FechaOculta2.Value;
                fechas[2] = FechaOculta3.Value;
            }

            //fecha != FechaHoy
            //fechaX >= FechaHoy
            //fecha2 >= fecha1
            //fecha3 >= fecha1
            //fecha3 >= fecha2
            if (!(fechaHoy.CompareTo(Convert.ToDateTime(fechas[0])) == 1 || fechaHoy.CompareTo(Convert.ToDateTime(fechas[1])) == 1 || fechaHoy.CompareTo(Convert.ToDateTime(fechas[2])) == 1))
            {
                if (!(Convert.ToDateTime(fechas[0]).CompareTo(Convert.ToDateTime(fechas[1])) == 1 ||
                      Convert.ToDateTime(fechas[0]).CompareTo(Convert.ToDateTime(fechas[2])) == 1 ||
                      Convert.ToDateTime(fechas[1]).CompareTo(Convert.ToDateTime(fechas[2])) == 1))
                {
                if (!(fecha2 == fechas[0] ||
                      fecha2 == fechas[1] ||
                      fecha2 == fechas[2]))
                {
                if(!(fechas[0] == fechas[1] || fechas[0] == fechas[2] ||
                     fechas[1] == fechas[0] || fechas[1] == fechas[2] ||
                     fechas[2] == fechas[0] || fechas[2] == fechas[1]))
                {

                for (int i = 0; i < int.Parse(numCuotas.InnerText); i++)
                {
                    datosCuotas = tablaCuotas.Rows[i];

                    if (datosCuotas["Estado"].ToString() == "Pendiente")
                    {
                        cuo.Modificar(int.Parse(datosCuotas["ID_Cuota"].ToString()), fechas[i]);
                    }
                }
                Response.Write("<script type='text/javascript'>alert('modificacion generada'); location.href='Consultar.aspx';</script>");
                }
                else
                {
                Response.Write("<script type='text/javascript'>alert('las fechas no pueden ser iguales entre si');</script>");
                }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('las fechas no pueden ser iguales a la fecha actual');</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('la fecha(s) no tiene orden de horario');</script>");
            }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('la fecha(s) no debe ser menor que la actual');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificar.aspx");
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
