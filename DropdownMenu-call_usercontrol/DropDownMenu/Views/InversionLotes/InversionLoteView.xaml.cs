using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.InversionLotes.Diagnostico;
using DIRU.Views.InversionLotes.Evaluaciones;
using DIRU.Views.RegulacionesUrbanas.Alturas;
using DIRU.Views.RegulacionesUrbanas.DatosEntradaDiseño;
using DIRU.Views.RegulacionesUrbanas.Edificacion;
using DIRU.Views.RegulacionesUrbanas.EstadosTecnico;
using DIRU.Views.RegulacionesUrbanas.Estructura;
using DIRU.Views.RegulacionesUrbanas.Fachada;
using DIRU.Views.RegulacionesUrbanas.Indicadores;
using DIRU.Views.RegulacionesUrbanas.NuevoDiseño;
using DIRU.Views.RegulacionesUrbanas.Plantas;
using Entity.Entitys.Proyectos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Paragraph = iTextSharp.text.Paragraph;
using Entity.Entitys.Proyectos.InversionesLotes;
using System.Drawing;
using Image = iTextSharp.text.Image;
using DIRU.Views.RegulacionesUrbanas.Funciones;
using DIRU.Views.RegulacionesUrbanas.AreasParques;

namespace DropDownMenu.Views.InversionLotes
{
    /// <summary>
    /// Interaction logic for InversionLote.xaml
    /// </summary>
    public partial class InversionLoteView : UserControl
    {
        public static MenuItem mDiagnostico;
        public static MenuItem mEvaluaciones;
        public static MenuItem mVulnerabilidad;
        public static MenuItem mInfoAptitudPrimaria;
        public static MenuItem mRegulacionUrbana;
        public static MenuItem mDatosDiseño;
        public static MenuItem mInmuebles;
        public static MenuItem mInfGeneral;
        
        public static MenuItem mProject;
       
        public static Grid MainInversion;
        public static Proyecto currentProject;
        public InversionLoteView()
        {
            InitializeComponent();
            mDiagnostico = menuDiagnostico;
            mEvaluaciones = menuEvaluaciones;
            mVulnerabilidad = menuVulnerabilidad;
            mInfoAptitudPrimaria = menuAptitudPrimaria;
            mRegulacionUrbana = menuRegulacionUrbana;
            mDatosDiseño = menuDatosDiseño;
            mInmuebles = menuInfoInmueble;
            mInfGeneral = menuInfoGeneral;
            MainWindow.menuGenerales = menuGenerales;
            mProject = menuProject;
           
            MainInversion = Main;
            currentProject = null;
        }

        private void DatosGenerales_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new DatosGenerales());
        }

        private void Diagnostico_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Diagnosticos(currentProject, DependencyRegister._proyectoService));
        }

       

        private void DatosCliente_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new DatosCliente());
        }

        private void Vulnerabilidad_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new EvaluacionVulnerabilidad());
        }

        private void Capacidad_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new EvaluacionCapacidad());

        }

        private void AptitudesPrimarias_Click(object sender, RoutedEventArgs e)
        {
           if(!string.IsNullOrWhiteSpace(MainWindow.currentProject.InversionLotes.UrlEvaluaciones))
                Process.Start(MainWindow.currentProject.InversionLotes.UrlEvaluaciones);
        }

        #region Regulacion Urbana 
     

        private void Estructura_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new EstructuraManzana());
        }

        private void Altura_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Altura());
        }

        private void Disposicion_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Disposicion());
        }

        private void Alineacion_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Alineacion());
        }

        private void Fachada_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new FachadaPrincipal());
        }

        private void Funciones_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new UsosFunciones());
        }

        private void Areas_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new AreasParques());
        }

        private void Plantas_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Plantas());
        }

        private void Comercio_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Indicadores_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new IndicadoresProyecto());

        }

        private void EstadoTecnico_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new EstadoTecnicoView(currentProject, DependencyRegister._proyectoService));
        }

        private void DatosEntrada_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new DatosEntradaDiseño());
        }

        private void InmuebleNuevo_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new NuevosDatosEntrada());
        }

        private void InformeGeneral_Click(object sender, RoutedEventArgs e)
        {
            DependencyRegister._informeService.GenerateInformeGeneral(currentProject);
        }

        private void InfoInmuebleConstruido_Click(object sender, RoutedEventArgs e)
        {

            var plantas = currentProject.InversionLotes.Plantas;

            // Crea una instancia de la clase SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = currentProject.Nombre+ "_Inmueble_Construido_" + DateTime.Now.ToString("dd-MM-yyyy");

            // Configura el cuadro de diálogo de guardado de archivos para que solo muestre archivos PDF como opciones de archivo
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

            // Muestra el cuadro de diálogo de guardado de archivos y comprueba si el usuario ha seleccionado una ubicación para guardar el archivo
            if (saveFileDialog.ShowDialog() == true)
            {
                // El usuario seleccionó una ubicación para guardar el archivo
                string fileName = saveFileDialog.FileName;


                // Crear el documento PDF
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                // Abrir el documento y agregar el título
                document.Open();
                iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN) { Size = 12 };
                dataFont.SetStyle(iTextSharp.text.Font.BOLD);

                PdfPTable logoTable = new PdfPTable(1)
                {
                    WidthPercentage = 100f
                };
                logoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                System.Drawing.Image image = System.Drawing.Image.FromFile("D:/Works/Proyecto Felix/Diru Development/DropdownMenu-call_usercontrol/DropDownMenu/Assets/logoDIRU-removebg-preview (1).png");


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
                var cellRowAreas = new PdfPCell(new Phrase(currentProject.Nombre + " - Inmueble Construido", dataFont))
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                logoTable.AddCell(cellRowAreas);
                document.Add(logoTable);
                // Agregar  líneas en blanco
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                var oldPlantas = plantas.Where(p => !p.Nuevo).OrderBy(p => p.Id);

                foreach (var planta in oldPlantas)
                {
                    Paragraph subtitle = new Paragraph("Planta : " + planta.Descripcion);
                    document.Add(subtitle);

                    document.Add(new Paragraph(" "));




                    if (planta.Locales.Any())
                    { 
                    PdfPTable table = new PdfPTable(3);
                    table.AddCell("Local");
                    table.AddCell("Area Ocupada");
                    table.AddCell("Estado");

                    // Establecer el ancho relativo de cada columna en la tabla
                    table.SetWidthPercentage(new float[] { 30f, 20f, 20f }, PageSize.A8);
                    decimal totalprice = 0;
                    foreach (LocalPlanta local in planta.Locales)
                    {
                        
                        table.AddCell(local.Local);
                        table.AddCell(local.AreaOcupada.ToString("0.00"));
                        table.AddCell(local.Estado.ToString());
                       

                       
                    }

                    document.Add(table);
                  
                    }
                    Paragraph total = new Paragraph("Area Ocupada:"+ planta.Area.ToString("0.00"));
                    total.Alignment = Element.ALIGN_CENTER;
                    document.Add(total);

                    document.Add(new Paragraph(" "));

                }
                document.Close();
                writer.Close();

               

                // Abre el archivo PDF con la aplicación predeterminada para archivos PDF en el sistema del usuario
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C start \"\" \"{fileName}\"";
                Process.Start(startInfo);

            }
        }

        private void InfoInmuebleNuevo_Click(object sender, RoutedEventArgs e)
        {
            var plantas = currentProject.InversionLotes.Plantas.OrderBy(p => p.Id);

            // Crea una instancia de la clase SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = currentProject.Nombre + "_Inmueble_Nuevo_" + DateTime.Now.ToString("dd-MM-yyyy");

            // Configura el cuadro de diálogo de guardado de archivos para que solo muestre archivos PDF como opciones de archivo
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

            // Muestra el cuadro de diálogo de guardado de archivos y comprueba si el usuario ha seleccionado una ubicación para guardar el archivo
            if (saveFileDialog.ShowDialog() == true)
            {
                // El usuario seleccionó una ubicación para guardar el archivo
                string fileName = saveFileDialog.FileName;


                // Crear el documento PDF
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                // Abrir el documento y agregar el título
                document.Open();
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
                var cellRowAreas = new PdfPCell(new Phrase(currentProject.Nombre + " - Inmueble Nuevo", dataFont))
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };

                logoTable.AddCell(cellRowAreas);
                document.Add(logoTable);
                //Paragraph title = new Paragraph(currentProject.Nombre + " - Inmueble Nuevo");
                //document.Add(title);
                // Agregar  líneas en blanco
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

               

                foreach (var planta in plantas)
                {
                    Paragraph subtitle = new Paragraph("Planta : " + planta.Descripcion);
                    document.Add(subtitle);

                    document.Add(new Paragraph(" "));




                    if (planta.Locales.Any())
                    {
                        PdfPTable table = new PdfPTable(3);
                        table.AddCell("Local");
                        table.AddCell("Area Ocupada");
                        table.AddCell("Estado");

                        // Establecer el ancho relativo de cada columna en la tabla
                        table.SetWidthPercentage(new float[] { 30f, 20f, 20f }, PageSize.A8);

                        var locales = planta.Locales.Where(l => l.Nuevo);
                        foreach (LocalPlanta local in locales)
                        {

                            table.AddCell(local.Local);
                            table.AddCell(local.AreaOcupada.ToString("0.00"));
                            table.AddCell(local.Estado.ToString());

                        }

                        document.Add(table);
                       
                    }
                    Paragraph total = new Paragraph("Area Ocupada:" + planta.Area.ToString("0.00"));
                    total.Alignment = Element.ALIGN_CENTER;
                    document.Add(total);

                    document.Add(new Paragraph(" "));

                }
                document.Close();
                writer.Close();



                // Abre el archivo PDF con la aplicación predeterminada para archivos PDF en el sistema del usuario
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C start \"\" \"{fileName}\"";
                Process.Start(startInfo);

            }

        }
    }
}
