using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;
using System.Threading;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Globalization;

namespace ERPCobranza
{
    public partial class CrearCobranza2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                efectivo.Checked = true;

                Factura fac = new Factura();
                Credito cre = new Credito();

                DataTable tablaFac = fac.ListarNOFacturaEspecifico(int.Parse(Request.Params["nfactu"]));

                DataRow factura = tablaFac.Rows[0];

                numFactura.InnerText = factura["NoFactura"].ToString();
                rutCli.InnerText = factura["Cliente"].ToString();
                nomCli.InnerText = factura["Nombre_Cliente"].ToString();
                montTotal.Text = factura["Total"].ToString();

                DataTable tablaCre = cre.ListarRutEspecifico(factura["Cliente"].ToString());
                DataRow credito;

                if (tablaCre.Rows.Count > 0)
                {
                    credito = tablaCre.Rows[0];
                    saldoTarj.InnerText = credito["Disp_Credito"].ToString();

                if (credito["Estado"].ToString() == "Bloqueado")
                {
                    tarjeta.Disabled = true;
                    estTarjeta.InnerText = "Bloqueado";
                }
                else if (credito["Estado"].ToString() == "Vigente")
                {
                    estTarjeta.InnerText = "Vigente";
                }
                }
                else
                {
                    tarjeta.Disabled = true;
                    estTarjeta.InnerText = "Sin tarjeta";
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cobranza cob2 = new Cobranza();
            DataTable totalDatosCob = cob2.Listar();
            int acumulandoID = totalDatosCob.Rows.Count + 1;

            Pago pag2 = new Pago();
            DataTable totalDatosPag = pag2.Listar();
            int acumulandoIDPago = totalDatosPag.Rows.Count + 1;

            string estadoCob = "";

            DateTime fechaHoy = DateTime.Today;
            string fecha = fechaHoy.ToString("dd-MM-yy");

            try
            {
                int montoPagar = int.Parse(MontPagar.Text);
                int montoTotal = int.Parse(montTotal.Text);

                int totalSaldo = montoTotal - montoPagar;

                if (!(montoPagar > montoTotal))
                {
                    if (totalSaldo == 0) { estadoCob = "Pagado"; }
                    else { estadoCob = "Pendiente";  }

                    string[] textoPDF = new string[]
                    {
                    "Don Peluchin",
                    "Venta de insumos para",
                    "pesca y mineria",
                    " ",
                    };

                    string[] textoPDF2 = new string[]
                    {
                    "RUT :                           " + rutCli.InnerText,
                    "ID Pago :                       " + acumulandoIDPago,
                    " ",
                    "Nombre Cliente :                " + nomCli.InnerText,
                    " ",
                    "Metodo de pago :                Efectivo",
                    " ",
                    "Monto Total :                   " + montTotal.Text,
                    "Monto a Pagar :                 " + MontPagar.Text,
                    "Saldo Pendiente :               " + totalSaldo,
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
                        parag.Alignment = Element.ALIGN_LEFT;
                        doc.Add(parag);
                    }
                    doc.Close();

                    byte[] bytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string PDFURL = "data:application/pdf;base64," + base64String;

                    Pago pag = new Pago(acumulandoIDPago, acumulandoID, fecha, PDFURL);
                    Cobranza cob = new Cobranza(acumulandoID, int.Parse(numFactura.InnerText), rutCli.InnerText, fecha, totalSaldo, "Efectivo", 0, estadoCob);
                    cob.Agregar();
                    pag.Agregar();

                    Response.Write("<script type='text/javascript'>alert('cobranza generada'); location.href='Consultar.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('el monto pagar no debe ser mayor que el monto total');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int numeroCuotas = int.Parse(numCuotas.Value);

            DateTime fechaHoy = DateTime.Today;
            string fecha = fechaHoy.ToString("dd/MM/yy");
            DateTime fechaHoy2 = DateTime.Today;
            string fecha2 = fechaHoy2.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            Cobranza cob2 = new Cobranza();

            DataTable totalDatosCob = cob2.Listar();
            int acumulandoIDcob = totalDatosCob.Rows.Count + 1;

            Cuotas cuo2 = new Cuotas();
            DataTable totalDatosCuo = cuo2.Listar();
            int acumulandoIDcuo = totalDatosCuo.Rows.Count;

            Pago pag2 = new Pago();
            DataTable totalDatosPag = pag2.Listar();
            int acumulandoIDPago = totalDatosPag.Rows.Count + 1;

            try
            {
                    if (numeroCuotas > 0)
                    {
                        if (!(int.Parse(montTotal.Text) > int.Parse(saldoTarj.InnerText)))
                        {
                            double[] cuotas = new double[4];
                            string[] fechas = new string[4];
                            int ajuste = 0;

                            if (numeroCuotas == 1)
                            {
                                cuotas = new double[2];
                                cuotas[0] = 0;
                                cuotas[1] = double.Parse(Cuota1.Text);

                                fechas = new string[4];
                                fechas[0] = "";
                                fechas[1] = Fecha1.Text;
                             fechas[2] = "28/12/9999";
                            fechas[3] = "28/12/9999";
                        }
                            else if (numeroCuotas == 2)
                            {
                                cuotas = new double[3];
                                cuotas[0] = 0;
                                cuotas[1] = double.Parse(Cuota1.Text);

                                if ((int.Parse(Cuota1.Text) + int.Parse(Cuota2.Text)) == int.Parse(montTotal.Text))
                                {
                                    cuotas[2] = double.Parse(Cuota2.Text);
                                }
                                else
                                {
                                    ajuste = int.Parse(montTotal.Text) - (int.Parse(Cuota1.Text) + int.Parse(Cuota2.Text));
                                    cuotas[2] = double.Parse(Cuota2.Text) + ajuste;
                                }

                                fechas = new string[4];
                                fechas[0] = "";
                                fechas[1] = Fecha1.Text;
                                fechas[2] = Fecha2.Text;
                            fechas[3] = "28/12/9999";
                        }
                            else if (numeroCuotas == 3)
                            {
                                cuotas = new double[4];
                                cuotas[0] = 0;
                                cuotas[1] = double.Parse(Cuota1.Text);
                                cuotas[2] = double.Parse(Cuota2.Text);

                                if ((int.Parse(Cuota1.Text) + int.Parse(Cuota2.Text) + int.Parse(Cuota3.Text)) == int.Parse(montTotal.Text))
                                {
                                    cuotas[3] = double.Parse(Cuota3.Text);
                                }
                                else
                                {
                                    ajuste = int.Parse(montTotal.Text) - (int.Parse(Cuota1.Text) + int.Parse(Cuota2.Text) + int.Parse(Cuota3.Text));
                                    cuotas[3] = double.Parse(Cuota3.Text) + ajuste;
                                }

                                fechas = new string[4];
                                fechas[0] = "";
                                fechas[1] = Fecha1.Text;
                                fechas[2] = Fecha2.Text;
                                fechas[3] = Fecha3.Text;
                            }

                            if (Fecha1.Text.Length > 0 || Fecha2.Text.Length > 0 || Fecha3.Text.Length > 0)
                            {
                            if (!(fechaHoy.CompareTo(Convert.ToDateTime(fechas[1])) == 1 || fechaHoy.CompareTo(Convert.ToDateTime(fechas[2])) == 1 || fechaHoy.CompareTo(Convert.ToDateTime(fechas[3])) == 1))
                            {
                                if (!(Convert.ToDateTime(fechas[1]).CompareTo(Convert.ToDateTime(fechas[2])) == 1 ||
                                      Convert.ToDateTime(fechas[1]).CompareTo(Convert.ToDateTime(fechas[3])) == 1 ||
                                      Convert.ToDateTime(fechas[2]).CompareTo(Convert.ToDateTime(fechas[3])) == 1))
                                {
                                if (!(fecha2 == fechas[0] ||
                      fecha2 == fechas[1] ||
                      fecha2 == fechas[2]))
                                    {
                                        if (!(fechas[0] == fechas[1] || fechas[0] == fechas[2] ||
                                             fechas[1] == fechas[0] || fechas[1] == fechas[2] ||
                                             fechas[2] == fechas[0] || fechas[2] == fechas[1]))
                                        {
                                            Cobranza cob = new Cobranza(acumulandoIDcob, int.Parse(numFactura.InnerText), rutCli.InnerText, fecha, int.Parse(montTotal.Text), "Tarjeta", numeroCuotas, "Pendiente");

                                cob.Agregar();
                                Cuotas cuo = new Cuotas();

                                string[] cuotasComprobante = new string[] { "", "", "", "" };

                                for (int i = 1; i <= numeroCuotas; i++)
                                {
                                        cuotasComprobante[i] = i + ".- " + cuotas[i] + " - " + fechas[i] + " Pendiente";
                                        cuo = new Cuotas(acumulandoIDcuo + i, acumulandoIDcob, cuotas[i], fechas[i], "Pendiente");
                                        cuo.Agregar();
                                }

                                string ajusteComprobante = "";

                                if (ajuste > 0) { ajusteComprobante = "Ajuste : " + ajuste; }

                                string[] textoPDF = new string[]
                                {
                    "Don Peluchín",
                    "Venta de insumos para",
                    "pesca y mineria",
                    " ",
                                };

                                string[] textoPDF2 = new string[]
                                {
                    "RUT :                           " + rutCli.InnerText,
                    "ID Pago :                       " + acumulandoIDPago,
                    " ",
                    "Nombre Cliente :                " + nomCli.InnerText,
                    " ",
                    "Metodo de pago :                Tarjeta",
                    " ",
                    "Cuotas : ",
                    cuotasComprobante[1],
                    cuotasComprobante[2],
                    cuotasComprobante[3],
                    ajusteComprobante,
                    "Estado : Pendiente",
                    " ",
                    "Monto Total :                   " + montTotal.Text,
                    "Saldo Pendiente :               " + montTotal.Text,
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

                                Pago pag = new Pago(acumulandoIDPago, acumulandoIDcob, fecha, PDFURL);
                                pag.Agregar();

                                Response.Write("<script type='text/javascript'>alert('cobranza generada'); location.href='Consultar.aspx';</script>");
                                }
                                else
                                {
                                    efectivo.Checked = true;
                                    tarjeta.Checked = false;
                                    numCuotas.Value = "0";
                                    Response.Write("<script type='text/javascript'>alert('las fechas no pueden ser iguales entre si');</script>");
                                }
                                    }
                                    else
                                    {
                                        efectivo.Checked = true;
                                        tarjeta.Checked = false;
                                        numCuotas.Value = "0";
                                        Response.Write("<script type='text/javascript'>alert('las fechas no pueden ser iguales a la fecha actual');</script>");
                                    }
                                }
                                else
                                {
                                    efectivo.Checked = true;
                                    tarjeta.Checked = false;
                                    numCuotas.Value = "0";
                                    Response.Write("<script type='text/javascript'>alert('la fecha(s) no tiene orden de horario');</script>");
                                }
                            }
                            else
                            {
                                efectivo.Checked = true;
                                tarjeta.Checked = false;
                                numCuotas.Value = "0";
                                Response.Write("<script type='text/javascript'>alert('la fecha(s) no debe ser menor que la actual');</script>");
                            }
                            }
                            else
                            {
                                efectivo.Checked = true;
                                tarjeta.Checked = false;
                                numCuotas.Value = "0";
                                Response.Write("<script type='text/javascript'>alert('debe rellenar las fechas');</script>");
                            }
                        }
                        else
                        {
                            efectivo.Checked = true;
                            tarjeta.Checked = false;
                            numCuotas.Value = "0";
                            Response.Write("<script type='text/javascript'>alert('no hay saldo suficiente en tu tarjeta');</script>");
                        }
                    }
                    else
                    {
                        efectivo.Checked = true;
                        tarjeta.Checked = false;
                        numCuotas.Value = "0";
                        Response.Write("<script type='text/javascript'>alert('elija numero de cuotas');</script>");
                    }
            }
            catch (Exception ex)
            {
                efectivo.Checked = true;
                tarjeta.Checked = false;
                numCuotas.Value = "0";
                Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCobranza.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCobranza.aspx");
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
