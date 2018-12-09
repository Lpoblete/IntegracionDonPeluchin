using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace VistaVentas
{
    public partial class MV_Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdFactura_CheckedChanged(object sender, EventArgs e)
        {
            DropDownList2.Visible = true;
            DropDownList1.Visible = false;
        }

        protected void rdDetalle_CheckedChanged(object sender, EventArgs e)
        {
            DropDownList1.Visible = true;
            DropDownList2.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdFactura.Checked)
            {
                GridView2.Visible = true;
                GridView1.Visible = false;
            }
            else if(rdDetalle.Checked)
            {
                GridView2.Visible = false;
                GridView1.Visible = true;
            }
        }

        protected void btnimprir_Click(object sender, EventArgs e)
        {
            if (rdDetalle.Checked){

                int columnsCount = GridView1.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(columnsCount);

                // Loop thru each cell in GrdiView header row
                foreach (TableCell gridViewHeaderCell in GridView1.HeaderRow.Cells)
                {
                    // Create the Font Object for PDF document
                    Font font = new Font();
                    // Set the font color to GridView header row font color
                    font.Color = new BaseColor(GridView1.HeaderStyle.ForeColor);

                    // Create the PDF cell, specifying the text and font
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                    pdfCell.BackgroundColor = new BaseColor(GridView1.HeaderStyle.BackColor);

                    // Add the cell to PDF table
                    pdfTable.AddCell(pdfCell);
                }

                // Loop thru each datarow in GrdiView
                foreach (GridViewRow gridViewRow in GridView1.Rows)
                {
                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            Font font = new Font();
                            font.Color = new BaseColor(GridView1.RowStyle.ForeColor);

                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                            pdfCell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);

                            pdfTable.AddCell(pdfCell);
                        }
                    }
                }

                // Create the PDF document specifying page size and margins
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
                string[] textoPDF = new string[]
                        {
                    "Don Peluchín",
                    "Venta de insumos para",
                    "pesca y mineria",
                    " ",
                        };
                DateTime fechaHoy = DateTime.Today; string fecha = fechaHoy.ToString("dd/MM/yy");


                pdfDocument.Open();
                for (int i = 0; i < textoPDF.Length; i++)
                {
                    Paragraph parag = new Paragraph(textoPDF[i], new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                    parag.Alignment = Element.ALIGN_CENTER;
                    pdfDocument.Add(parag);
                }
                pdfDocument.Add(pdfTable);
                Paragraph date = new Paragraph(fecha);
                date.Alignment = Element.ALIGN_CENTER;
                pdfDocument.Add(date);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition",
                    "attachment;filename=Consulta.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            else if(rdFactura.Checked)
            {

                int columnsCount = GridView2.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(columnsCount);

                // Loop thru each cell in GrdiView header row
                foreach (TableCell gridViewHeaderCell in GridView2.HeaderRow.Cells)
                {
                    // Create the Font Object for PDF document
                    Font font = new Font();
                    // Set the font color to GridView header row font color
                    font.Color = new BaseColor(GridView2.HeaderStyle.ForeColor);

                    // Create the PDF cell, specifying the text and font
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                    pdfCell.BackgroundColor = new BaseColor(GridView2.HeaderStyle.BackColor);

                    // Add the cell to PDF table
                    pdfTable.AddCell(pdfCell);
                }

                // Loop thru each datarow in GrdiView
                foreach (GridViewRow gridViewRow in GridView2.Rows)
                {
                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            Font font = new Font();
                            font.Color = new BaseColor(GridView2.RowStyle.ForeColor);

                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                            pdfCell.BackgroundColor = new BaseColor(GridView2.RowStyle.BackColor);

                            pdfTable.AddCell(pdfCell);
                        }
                    }
                }

                // Create the PDF document specifying page size and margins
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
                string[] textoPDF = new string[]
                        {
                    "Don Peluchín",
                    "Venta de insumos para",
                    "pesca y mineria",
                    "Facturas ",
                        };
                DateTime fechaHoy = DateTime.Today; string fecha = fechaHoy.ToString("dd/MM/yy");


                pdfDocument.Open();
                for (int i = 0; i < textoPDF.Length; i++)
                {
                    Paragraph parag = new Paragraph(textoPDF[i], new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
                    parag.Alignment = Element.ALIGN_CENTER;
                    pdfDocument.Add(parag);
                }
                pdfDocument.Add(pdfTable);
                Paragraph date = new Paragraph(fecha);
                date.Alignment = Element.ALIGN_CENTER;
                pdfDocument.Add(date);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition",
                    "attachment;filename=Consulta.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}