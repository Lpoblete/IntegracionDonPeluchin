using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace ERPCobranza
{
    public partial class CobranzaPendiente2 : System.Web.UI.Page
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
                saldPendiente.Text = datosCobranza["Saldo"].ToString();

                Factura fac = new Factura();
                DataTable tablaFactura = fac.ListarNOFacturaEspecifico(int.Parse(datosCobranza["Factura_NO"].ToString()));
                DataRow datosFactura = tablaFactura.Rows[0];

                montTotal.Text = datosFactura["Total"].ToString();

                if (Request.Params["metpa"] == "efectivo")
                {
                    efect.Visible = true;
                    efect2.Visible = true;
                }
                else if (Request.Params["metpa"] == "tarjeta")
                {
                    tarj.Visible = true;
                    tarj2.Visible = true;
                    tarj3.Visible = true;

                    Credito cre = new Credito();
                    DataTable tablaCredito = cre.ListarRutEspecifico(datosCobranza["Cliente_Rut"].ToString());
                    DataRow datosCredito = tablaCredito.Rows[0];

                    saldTarjeta.InnerText = datosCredito["Disp_Credito"].ToString();
                    numCuotas.InnerText = datosCobranza["NumCuotas"].ToString();

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

                    CheckBox[] cuotasCheck = new CheckBox[3];
                    cuotasCheck[0] = PagadoCuo1;
                    cuotasCheck[1] = PagadoCuo2;
                    cuotasCheck[2] = PagadoCuo3;

                    HtmlAnchor[] mensajeCobro = new HtmlAnchor[3];
                    mensajeCobro[0] = mensajeCobro1;
                    mensajeCobro[1] = mensajeCobro2;
                    mensajeCobro[2] = mensajeCobro3;

                    for (int i = 0; i < int.Parse(numCuotas.InnerText); i++)
                    {
                        cuotasDatos[i].Visible = true;
                        datosCuotas = tablaCuotas.Rows[i];
                        cuotas[i].Text = datosCuotas["Monto"].ToString();
                        fechas[i].Text = datosCuotas["Fecha"].ToString();

                        if (datosCuotas["Estado"].ToString() == "Pagado")
                        {
                            cuotasCheck[i].Checked = true;
                            cuotasCheck[i].Enabled = false;
                            mensajeCobro[i].InnerText = "Pagado";
                        }
                    }

                int saldoPendiente = int.Parse(saldPendiente.Text);
                int saldoTarj = int.Parse(saldTarjeta.InnerText);

                if (saldoPendiente > saldoTarj)
                {
                    Response.Write("<script type='text/javascript'>alert('Saldo tarjeta es menor que saldo pendiente. Saldo Tarjeta: " + saldoTarj + " Saldo Pendiente: " + saldoPendiente + " '); location.href='CobranzaPendiente.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CobranzaPendiente.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cobranza cob = new Cobranza();
            DataTable tablaCobranza = cob.ListarIDCobranzaEspecifica(int.Parse(Request.Params["idco"]));
            DataRow datosCobranza = tablaCobranza.Rows[0];

            Cuotas cuo = new Cuotas();
            DataTable tablaCuota = cuo.ListarIDCobranzaEspecifica(int.Parse(IDcobranza.InnerText));
            DataRow datosCuota;

            Credito cre = new Credito();

            CheckBox[] cuotasCheck = new CheckBox[3];
            cuotasCheck[0] = PagadoCuo1;
            cuotasCheck[1] = PagadoCuo2;
            cuotasCheck[2] = PagadoCuo3;

            int saldoPendiente = int.Parse(saldPendiente.Text);
            int saldoTarj = int.Parse(saldTarjeta.InnerText);
            int total = 0;
            int totalTarj = 0;
            int tarjeta = 0;
            string estadoComprobante = "";

            string[] cuotasComprobante = new string[] { "", "", "" };

            if (cuotasCheck[0].Checked == true || cuotasCheck[1].Checked == true || cuotasCheck[2].Checked == true)
            {
                    for (int i = 0; i < int.Parse(numCuotas.InnerText); i++)
                    {
                    datosCuota = tablaCuota.Rows[i];

                    if (cuotasCheck[i].Checked == true)
                        {
                        tarjeta = tarjeta + int.Parse(datosCuota["Monto"].ToString());
                        cuo.ModificarEstado(int.Parse(datosCuota["ID_Cuota"].ToString()), 0, "Pagado");
                        cuotasComprobante[i] = i + 1 + ".- 0 - " + datosCuota["Fecha"] + " Pagado";
                        }
                        else
                        {
                        cuotasComprobante[i] = i + 1 + ".- " + datosCuota["Monto"] + " - " + datosCuota["Fecha"] + " Pendiente";
                        }
                    }
                        total = saldoPendiente - tarjeta;
                        totalTarj = saldoTarj - tarjeta;

                    if (total == 0)
                    {
                        estadoComprobante = "Pagado";
                        cob.ModificarSaldoPendiente(int.Parse(IDcobranza.InnerText), total, estadoComprobante);
                        cre.ModificarSaldo(totalTarj, datosCobranza["Cliente_Rut"].ToString());
                    }
                    else
                    {
                        estadoComprobante = "Pendiente";
                        cob.ModificarSaldoPendiente(int.Parse(IDcobranza.InnerText), total, estadoComprobante);
                        cre.ModificarSaldo(totalTarj, datosCobranza["Cliente_Rut"].ToString());
                    }

                DateTime fechaHoy = DateTime.Today;
                string fecha = fechaHoy.ToString("dd/MM/yy");

                Pago pag2 = new Pago();
                DataTable totalDatosPag = pag2.Listar();
                int acumulandoIDPago = totalDatosPag.Rows.Count + 1;

                string[] textoPDF = new string[]
                {
                    "Don Peluchín",
                    "Venta de insumos para",
                    "pesca y mineria",
                    " ",
                };

                string[] textoPDF2 = new string[]
                {
                    "RUT :                           " + datosCobranza["Cliente_Rut"].ToString(),
                    "ID Pago :                       " + acumulandoIDPago,
                    " ",
                    "Nombre Cliente :                " + datosCobranza["Nombre_Cliente"].ToString(),
                    " ",
                    "Metodo de pago :                Tarjeta",
                    " ",
                    "Cuotas : ",
                    cuotasComprobante[0],
                    cuotasComprobante[1],
                    cuotasComprobante[2],
                    "Estado : " + estadoComprobante,
                    " ",
                    "Monto Total :                   " + montTotal.Text,
                    "Saldo Pendiente :               " + total,
                    " ",
                    "Fecha Impresion :               " + fecha
                };

                Document doc = new Document();
                MemoryStream ms = new MemoryStream();
                PdfWriter.GetInstance(doc, ms);

                doc.Open();
                for (int i = 0; i < textoPDF.Length; i++)
                {
                    Paragraph parag = new Paragraph(textoPDF[i], new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                    parag.Alignment = Element.ALIGN_CENTER;
                    doc.Add(parag);
                }
                for (int i = 0; i < textoPDF2.Length; i++)
                {
                    Paragraph parag = new Paragraph(textoPDF2[i], new Font(Font.FontFamily.COURIER, 10, Font.BOLD));
                    parag.Alignment = Element.ANCHOR;
                    doc.Add(parag);
                }
                doc.Close();

                byte[] bytes = ms.ToArray();
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                string PDFURL = "data:application/pdf;base64," + base64String;

                Pago pag = new Pago(acumulandoIDPago, int.Parse(IDcobranza.InnerText), fecha, PDFURL);
                pag.Agregar();

                Response.Write("<script type='text/javascript'>alert('cobro generado'); location.href='Consultar.aspx';</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('no ha tachado ningun pago');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cobranza cob = new Cobranza();
                DataTable tablaCobranza = cob.ListarIDCobranzaEspecifica(int.Parse(Request.Params["idco"]));
                DataRow datosCobranza = tablaCobranza.Rows[0];

                int efecti = int.Parse(Efectivo.Text);
                int saldoPendiente = int.Parse(saldPendiente.Text);
                int total = 0;
                string estadoCob = "";

                if (!(efecti > saldoPendiente))
                {
                    total = saldoPendiente - efecti;

                    if (total == 0)
                    {
                        estadoCob = "Pagado";
                        cob.ModificarSaldoPendiente(int.Parse(IDcobranza.InnerText), total, estadoCob);
                    }
                    else
                    {
                        estadoCob = "Pendiente";
                        cob.ModificarSaldoPendiente(int.Parse(IDcobranza.InnerText), total, estadoCob);
                    }

                    DateTime fechaHoy = DateTime.Today;
                    string fecha = fechaHoy.ToString("dd/MM/yy");

                    Pago pag2 = new Pago();
                    DataTable totalDatosPag = pag2.Listar();
                    int acumulandoIDPago = totalDatosPag.Rows.Count + 1;

                    string[] textoPDF = new string[]
                    {
                    "Don Peluchin",
                    "Venta de insumos para",
                    "pesca y mineria",
                    " ",
                    };

                    string[] textoPDF2 = new string[]
                    {
                    "RUT :                           " + datosCobranza["Cliente_Rut"].ToString(),
                    "ID Pago :                       " + acumulandoIDPago,
                    " ",
                    "Nombre Cliente :                " + datosCobranza["Nombre_Cliente"].ToString(),
                    " ",
                    "Metodo de pago :                Efectivo",
                    " ",
                    "Monto Total :                   " + montTotal.Text,
                    "Monto Total Pendiente :          " + saldPendiente.Text,
                    "Monto a Pagar :                 " + efecti,
                    "Saldo Pendiente :               " + total,
                    "Estado :                        " + estadoCob,
                    " ",
                    "Fecha Impresion :               " + fecha
                        };

                    Document doc = new Document();
                    MemoryStream ms = new MemoryStream();
                    PdfWriter.GetInstance(doc, ms);

                    doc.Open();
                    for (int i = 0; i < textoPDF.Length; i++)
                    {
                        Paragraph parag = new Paragraph(textoPDF[i], new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                        parag.Alignment = Element.ALIGN_CENTER;
                        doc.Add(parag);
                    }
                    for (int i = 0; i < textoPDF2.Length; i++)
                    {
                        Paragraph parag = new Paragraph(textoPDF2[i], new Font(Font.FontFamily.COURIER, 10, Font.BOLD));
                        parag.Alignment = Element.ANCHOR;
                        doc.Add(parag);
                    }
                    doc.Close();

                    byte[] bytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string PDFURL = "data:application/pdf;base64," + base64String;

                    Pago pag = new Pago(acumulandoIDPago, int.Parse(IDcobranza.InnerText), fecha, PDFURL);
                    pag.Agregar();

                    Response.Write("<script type='text/javascript'>alert('cobro generado'); location.href='Consultar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('el monto pagar no debe ser mayor que el monto pendiente');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('"+ex.Message+"');</script>");
            }
        }

        protected void PagadoCuo1_CheckedChanged(object sender, EventArgs e)
        {
            if(PagadoCuo1.Checked == false)
            {
                PagadoCuo2.Checked = false;
                PagadoCuo3.Checked = false;
            }
        }

        protected void PagadoCuo2_CheckedChanged(object sender, EventArgs e)
        {
            if (PagadoCuo1.Checked == false || (PagadoCuo1.Checked == true && PagadoCuo3.Checked == true))
            {
                PagadoCuo2.Checked = false;
                PagadoCuo3.Checked = false;
            }
        }

        protected void PagadoCuo3_CheckedChanged(object sender, EventArgs e)
        {
            if (PagadoCuo1.Checked == false || PagadoCuo2.Checked == false)
            {
                PagadoCuo3.Checked = false;
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
