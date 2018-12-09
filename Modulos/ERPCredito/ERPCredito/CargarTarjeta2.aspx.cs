using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace ERPCredito
{
    public partial class CargarTarjeta2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Credito cre = new Credito();
            DataTable tablaCredito = cre.ListarRutEspecifico(Request.Params["rutCr"]);
            DataRow datosCredito = tablaCredito.Rows[0];

            rutCre.InnerText = datosCredito["Cliente_Rut"].ToString();
            limiteCred.Text = datosCredito["LimiteCredito"].ToString();
            saldDisponible.Text = datosCredito["Disp_Credito"].ToString();

            if (datosCredito["Estado"].ToString() == "Bloqueado")
            {
                Response.Write("<script type='text/javascript'>alert('esta tarjeta esta bloqueada'); location.href='CargarTarjeta.aspx';</script>");
            }
            else if (int.Parse(limiteCred.Text) == int.Parse(saldDisponible.Text))
            {
                Response.Write("<script type='text/javascript'>alert('tarjeta totalmente cargada'); location.href='CargarTarjeta.aspx';</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int sumaTotal = 0;

                if (int.Parse(saldCargar.Text) > 0)
                {
                    sumaTotal = int.Parse(saldDisponible.Text) + int.Parse(saldCargar.Text);

                    if (!(sumaTotal > int.Parse(limiteCred.Text)))
                    {
                        Credito cre2 = new Credito();
                        cre2.ModificarSaldo(sumaTotal, rutCre.InnerText);

                        DateTime fechaHoy = DateTime.Today;
                        string fecha = fechaHoy.ToString("dd/MM/yy");

                        Cliente cli = new Cliente();
                        DataTable tablaCliente = cli.ListarRutEspecifico(rutCre.InnerText);
                        DataRow datosCliente = tablaCliente.Rows[0];

                        Carga car = new Carga();
                        DataTable tablaCarga = car.Listar();
                        int acumulandoIDCarga = tablaCarga.Rows.Count + 1;

                        string[] textoPDF = new string[]
                        {
                    "Don Peluchín",
                    "Venta de insumos para",
                    "pesca y mineria",
                    " ",
                        };

                        string[] textoPDF2 = new string[]
                        {
                    "RUT :                           " + rutCre.InnerText,
                    "Nombre Cliente :                " + datosCliente["Nombre_Cliente"].ToString(),
                    "ID Carga :                      " + acumulandoIDCarga,
                    " ",
                    "Saldo Disponible :              " + saldDisponible.Text,
                    "Cupo Aumentado :                " + saldCargar.Text,
                    "Saldo Actual :                  " + sumaTotal,
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

                        Carga car2 = new Carga(acumulandoIDCarga,rutCre.InnerText,fecha, PDFURL);
                        car2.Agregar();

                        Response.Write("<script type='text/javascript'>alert('el cupo de la tarjeta ha sido aumentado'); location.href='Consultar.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('el cupo sobrepasa el limite');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('no ha cargado la tarjeta');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('"+ex.Message+"');</script>");
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