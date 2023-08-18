using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Proyectos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = iTextSharp.text.Image;

namespace DIRU.Views.InversionLotes.Evaluaciones
{
    /// <summary>
    /// Interaction logic for EvaluacionVulnerabilidad.xaml
    /// </summary>
    public partial class EvaluacionVulnerabilidad : UserControl
    {
        public static DataGrid datagrid;
        public static Button Edit;
        private readonly ICapacidadService _capacidadService;
        public EvaluacionVulnerabilidad()
        {
            InitializeComponent();
            datagrid = dgVulnerabilidad;
            Edit = EditCapacidad;
            _capacidadService = DependencyRegister._capacidadService;
            CapacidadSearchOptions options = new CapacidadSearchOptions { ProyectoId = MainWindow.currentProject.Id };
            dgVulnerabilidad.ItemsSource = _capacidadService.FindAllCapacidads(options);
        }
        private void EditCapacidad_Click(object sender, RoutedEventArgs e)
        {
            Capacidad capacidad = dgVulnerabilidad.SelectedItem as Capacidad;
            VulneravilidadForm page = new VulneravilidadForm(_capacidadService, capacidad);
            page.ShowDialog();
        }
        private void dgCapacidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditCapacidad.IsEnabled = true;
           

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //        switch (comboFilter.Text)
            //        {
            //            case "Provincia":
            //                dgCapacidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
            //((Capacidad)f).Provincia.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
            //                dgCapacidad.Items.Refresh();
            //                break;
            //            default:
            //                dgCapacidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
            //((Capacidad)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
            //                dgCapacidad.Items.Refresh();
            //                break;

            //        }
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {

          String tipoInforme = "Aptitud Primaria General de un Territorio";
            Document document = new Document();
            string pdfName = "Aptitud Primaria General" + Guid.NewGuid() + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "/downloads/" + pdfName, FileMode.Create));
            document.Open();
            document.AddTitle(tipoInforme);


            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN) { Size = 12 };
            dataFont.SetStyle(iTextSharp.text.Font.BOLD);

            PdfPTable logoTable = new PdfPTable(1)
            {
                WidthPercentage = 100f
            };
            logoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            System.Drawing.Image image = System.Drawing.Image.FromFile("Assets/logoDIRU-removebg-preview (1).png");


            image = (System.Drawing.Image)(new Bitmap(image, new System.Drawing.Size(100, 40)));
            Image picture = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Png);

            //  document.Add(picture);
            var cellRowLogoEntidad = new PdfPCell(picture)
            {

                HorizontalAlignment = Element.ALIGN_LEFT,
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                VerticalAlignment = Element.ALIGN_MIDDLE,

            };
            logoTable.AddCell(cellRowLogoEntidad);
            var cellRowAreas = new PdfPCell(new Phrase(tipoInforme, dataFont))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER
            };

            logoTable.AddCell(cellRowAreas);
            document.Add(logoTable);
            iTextSharp.text.Paragraph blankLine = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.WHITE, Element.ALIGN_LEFT, 1)));
                        document.Add(blankLine);
            iTextSharp.text.Font font5 = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                        PdfPTable table = new PdfPTable(5);

            Array floatArray = Array.CreateInstance(typeof(float),5);
            //float[] widths = new float[] { };
            for (int i = 0; i < 5; i++)
                floatArray.SetValue(4f, i);

            table.SetWidths((float[])floatArray);

            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Aptitud Primaria de un Terreno"));

            cell.Colspan = 5;
            table.AddCell(cell);
            table.AddCell(new Phrase("No Zonas Analisis", font5));
            table.AddCell(new Phrase("Aptitud Primaria Capacidad", font5));
            table.AddCell(new Phrase("Aptitud Primaria Vulnerabilidad", font5));
            table.AddCell(new Phrase("Aptitud Territorial", font5));
            table.AddCell(new Phrase("Aptitud Primaria", font5));
                       if (dgVulnerabilidad.Items.Count > 0)
            {
                foreach (Capacidad r in dgVulnerabilidad.Items)
                {


                    table.AddCell(new Phrase(r.Zona.ToString(), font5));
                    table.AddCell(new Phrase(r.EvalGeneral, font5));
                    table.AddCell(new Phrase(r.EvalGeneralVulnerabilidad, font5));
                    table.AddCell(new Phrase(r.EvalGeneral + r.EvalGeneralVulnerabilidad, font5));

                    string aptitudPrimaria = r.EvalGeneral + r.EvalGeneralVulnerabilidad;
                           switch (aptitudPrimaria)
                    {
                        case "AA":
                            table.AddCell(new Phrase("SL", font5));
                            break;
                        case "AB":
                            table.AddCell(new Phrase("A(IVA)", font5));
                            break;
                        case "BA":
                            table.AddCell(new Phrase("A(VTE)", font5));
                            break;
                        case "BB":
                            table.AddCell(new Phrase("A(IVA y VTE)", font5));
                            break;
                        case "AC":
                            table.AddCell(new Phrase("DES", font5));
                            break;
                        case "BC":
                            table.AddCell(new Phrase("DES", font5));
                            break;
                        case "CA":
                            table.AddCell(new Phrase("NP", font5));
                            break;
                        case "CB":
                            table.AddCell(new Phrase("NP", font5));
                            break;
                        case "CC":
                            table.AddCell(new Phrase("NP", font5));
                            break;


                    }


                  
                  

                }
            }
                       document.Add(table);

            document.Add(blankLine);
            //////////////////////////////////////////////////////
            PdfPTable tableLeyenda = new PdfPTable(3);

            Array floatArray1 = Array.CreateInstance(typeof(float), 3);
            //float[] widths = new float[] { };
            for (int i = 0; i < 3; i++)
                floatArray1.SetValue(4f, i);

            tableLeyenda.SetWidths((float[])floatArray1);

            tableLeyenda.WidthPercentage = 100;
            PdfPCell cell1 = new PdfPCell(new Phrase("Ánalisis integral de los níveles de aptitud primaria"));

            cell1.Colspan = 3;

            tableLeyenda.AddCell(cell1);
            tableLeyenda.AddCell(new Phrase("Aptitudes Primarias", font5));
            tableLeyenda.AddCell(new Phrase("Clasificación", font5));
            tableLeyenda.AddCell(new Phrase("Significado", font5));

            tableLeyenda.AddCell(new Phrase("AA", font5));
            tableLeyenda.AddCell(new Phrase("SL", font5));
            tableLeyenda.AddCell(new Phrase("Sin limitaciones", font5));

            tableLeyenda.AddCell(new Phrase("AB", font5));
            tableLeyenda.AddCell(new Phrase("A(IVA)", font5));
            tableLeyenda.AddCell(new Phrase("Impacto ambiental corregible", font5));

            tableLeyenda.AddCell(new Phrase("BA", font5));
            tableLeyenda.AddCell(new Phrase("A(VTE)", font5));
            tableLeyenda.AddCell(new Phrase("Víabilidad técnica aceptable", font5));

            tableLeyenda.AddCell(new Phrase("BB", font5));
            tableLeyenda.AddCell(new Phrase("A(IVA y VTE)", font5));
            tableLeyenda.AddCell(new Phrase("Impacto ambiental y víabilidad técnica", font5));

            tableLeyenda.AddCell(new Phrase("AC", font5));
            tableLeyenda.AddCell(new Phrase("DES", font5));
            tableLeyenda.AddCell(new Phrase("Desenvolvimiento urbano no sotenible por la destruccion de valores ambientales", font5));


            tableLeyenda.AddCell(new Phrase("BC", font5));
            tableLeyenda.AddCell(new Phrase("DES", font5));
            tableLeyenda.AddCell(new Phrase("Desenvolvimiento urbano no sotenible por la destruccion de valores ambientales", font5));
            
            tableLeyenda.AddCell(new Phrase("CA", font5));
            tableLeyenda.AddCell(new Phrase("NP", font5));
            tableLeyenda.AddCell(new Phrase("Usos urbanos prohibidos por la generación de situaciones de riesgos catastróficos", font5));

            tableLeyenda.AddCell(new Phrase("CB", font5));
            tableLeyenda.AddCell(new Phrase("NP", font5));
            tableLeyenda.AddCell(new Phrase("Usos urbanos prohibidos por la generación de situaciones de riesgos catastróficos", font5));
           
            tableLeyenda.AddCell(new Phrase("CC", font5));
            tableLeyenda.AddCell(new Phrase("NP", font5));
            tableLeyenda.AddCell(new Phrase("Usos urbanos prohibidos por la generación de situaciones de riesgos catastróficos", font5));

            document.Add(tableLeyenda);

            document.Add(blankLine);

            /////////////////////////////////////////
            ///
            var vulnerabilidades = dgVulnerabilidad.ItemsSource as List<Capacidad>;

            PdfPTable tableTotales = new PdfPTable(3);

            Array floatArray2 = Array.CreateInstance(typeof(float), 3);
            //float[] widths = new float[] { };
            for (int i = 0; i < 3; i++)
                floatArray2.SetValue(4f, i);

            tableLeyenda.SetWidths((float[])floatArray2);

            tableTotales.WidthPercentage = 100;
            PdfPCell cell2 = new PdfPCell(new Phrase("Ánalisis integral de los níveles de aptitud primaria"));

            cell2.Colspan = 3;

            tableTotales.AddCell(cell2);
            tableTotales.AddCell(new Phrase("Aptitudes Primarias", font5));
            tableTotales.AddCell(new Phrase("Clasificación", font5));
            tableTotales.AddCell(new Phrase("Cantidad de Zonas", font5));

            tableTotales.AddCell(new Phrase("AA", font5));
            tableTotales.AddCell(new Phrase("SL", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v =>(v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "AA").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("AB", font5));
            tableTotales.AddCell(new Phrase("A(IVA)", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "AB").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("BA", font5));
            tableTotales.AddCell(new Phrase("A(VTE)", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "BA").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("BB", font5));
            tableTotales.AddCell(new Phrase("A(IVA y VTE)", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "BB").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("AC", font5));
            tableTotales.AddCell(new Phrase("DES", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "AC").Count().ToString(), font5));


            tableTotales.AddCell(new Phrase("BC", font5));
            tableTotales.AddCell(new Phrase("DES", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "BC").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("CA", font5));
            tableTotales.AddCell(new Phrase("NP", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "CA").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("CB", font5));
            tableTotales.AddCell(new Phrase("NP", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "CB").Count().ToString(), font5));

            tableTotales.AddCell(new Phrase("CC", font5));
            tableTotales.AddCell(new Phrase("NP", font5));
            tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "CC").Count().ToString(), font5));

            document.Add(tableTotales);

            document.Close();
           
               string pdfPath = System.AppDomain.CurrentDomain.BaseDirectory + "/downloads/" + pdfName;
            MainWindow.currentProject.InversionLotes.UrlEvaluaciones = pdfPath;
            MainWindow.currentProject.Estado = EstadoProyecto.EnRegeneracionUrbana;
            DependencyRegister._proyectoService.UpdateProyecto(MainWindow.currentProject);
            InversionLoteView.mInfoAptitudPrimaria.IsEnabled = true;
            InversionLoteView.mRegulacionUrbana.IsEnabled = true;

            Process.Start(pdfPath);

        }
    }
}
