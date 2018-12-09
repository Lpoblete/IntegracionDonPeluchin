using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace ModuloLogistica
{
    public partial class Eliminar : System.Web.UI.Page
    {
        public SqlConnection Conn = new SqlConnection();
        public SqlCommand Tabb = new SqlCommand();
        public SqlDataAdapter Dadap = new SqlDataAdapter();
        public DataSet Dset = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void ConectarBD()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IntegracionBD"].ConnectionString);
            Conn.Open();
        }

        protected void CargarTabla()
        {
            Tabb = new SqlCommand("SELECT * FROM Existencia", Conn);
            Dadap.SelectCommand = Tabb;
            Dadap.Fill(Dset, "Existencia");

        }

        protected void Elimina()
        {
            try
            {
                int rowsaffected = 0;
                ConectarBD();
                CargarTabla();
                Tabb = new SqlCommand("SP_RestaExistencia", Conn);
                Tabb.CommandType = CommandType.StoredProcedure;
                Tabb.Parameters.AddWithValue("@Codigo_bodega", Convert.ToString(radio.SelectedValue));
                Tabb.Parameters.AddWithValue("@Codigo_producto", Convert.ToString(cbxproducto.SelectedValue));
                Tabb.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtcantidad.Text));
                Tabb.Parameters.AddWithValue("@Fecha_Ingreso", Convert.ToDateTime(txtfecha.Text));

                //SqlDataReader dr = Tabb.ExecuteReader();
                rowsaffected = Tabb.ExecuteNonQuery();
                if (rowsaffected < 1)
                {
                    MessageBox.Show("Eliminado Con Éxito", "Don Peluchin Te Informa",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                GridView1.DataBind();
                //LimpiarCasillas();

            }
            catch (Exception RR)
            {
                Response.Write("Error en el Grabar Datos" + RR.Message);
            }
        }

        protected void Cantidad()
        {
            try
            {
                ConectarBD();
                Tabb = new SqlCommand("SELECT Cantidad FROM Existencia WHERE Codigo_producto = @Codigo_producto", Conn);
                Dadap.SelectCommand = Tabb;
                Dadap.SelectCommand.Parameters.Add("@Codigo_producto", SqlDbType.Int).Value = Convert.ToInt32(cbxproducto.SelectedValue);
                Dadap.SelectCommand.ExecuteNonQuery();


                int n;
                n = Convert.ToInt32(Tabb.ExecuteScalar());
                if (n >= Convert.ToInt32(txtcantidad.Text))
                {
                    Elimina();
                    MessageBox.Show("Eliminado Con Éxito", "Don Peluchin Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La cantidad ingresada supera el stock", "Don Peluchin Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception RR)
            {
                Response.Write("Error en el Grabar Datos" + RR.Message);
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(txtcantidad.Text == "")
            {
                MessageBox.Show("Debe seleccionar una cantidad a Eliminar", "Don Peluchin Te Informa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Cantidad();
                Limpia();
                
            }
            
        }

        protected void BtnBodega_Click(object sender, EventArgs e)
        {

            if (radio.SelectedValue != "")
            {
                radio.Enabled = false;
                BtnBodega.Enabled = false;
                cbxproducto.Enabled = true;
                BtnCodigo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Bodega","DonPeluchin Te Informa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        protected void BtnCodigo_Click(object sender, EventArgs e)
        {
            if(cbxproducto.SelectedValue!="")
            {
                txtcantidad.Enabled = true;
                BtnEliminar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Debes seleccionar un producto","Don Peluchin Te Informa",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            radio.ClearSelection();
            radio.Enabled = true;
            ListBox1.Items.Clear();
            cbxproducto.Items.Clear();
            txtcantidad.Text = "";
            cbxproducto.Enabled = false;
            ListBox1.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnBodega.Enabled = true;
            BtnCodigo.Enabled = false;
            
        }

        protected void Limpia()
        {
            radio.ClearSelection();
            radio.Enabled = true;
            ListBox1.Items.Clear();
            cbxproducto.Items.Clear();
            txtcantidad.Text = "";
            txtcantidad.Enabled = false;
            cbxproducto.Enabled = false;
            ListBox1.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnBodega.Enabled = true;
            BtnCodigo.Enabled = false;
        }

        protected void button_Click(object sender, EventArgs e)
        {
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

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
    }
