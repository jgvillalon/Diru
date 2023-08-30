using ApplicationService.Informes.IService;
using ApplicationService.InversionLotes.IService;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos;
using Entity.Entitys.Proyectos.InversionesLotes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using Repository.InversionesLotes.IRepository;
using Repository.Proyectos.IRepository;
using Repository.Proyectos.Options;
using Repository.Proyectos.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using static iTextSharp.text.TabStop;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;

namespace ApplicationService.Informes.Service
{
    public class InformeService : IInformeService
    {

        private readonly IProyectoRepository _proyectoRepository;
        private readonly ICapacidadRepository _capacidadRepository;

        public InformeService(IProyectoRepository proyectoRepository, ICapacidadRepository capacidadRepository)
        {

            _proyectoRepository = proyectoRepository;
            _capacidadRepository = capacidadRepository;
        }

        public void GenerateInformeGeneral(Proyecto project)
        {
            // Crea una instancia de la clase SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

          

            saveFileDialog.FileName = project.Nombre + "_Informe_General_" + DateTime.Now.ToString("dd-MM-yyyy");

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
                var cellRowAreas = new PdfPCell(new Phrase(project.Nombre + "-" + project.Tipo.ToString(), dataFont))
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                logoTable.AddCell(cellRowAreas);
                document.Add(logoTable);
                // Agregar  líneas en blanco
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                document.Add(new Paragraph("Datos Cliente:"));

                Paragraph clineteNombre = new Paragraph("Nombre : " + project.Cliente.NombreCompleto);
                document.Add(clineteNombre);
                Paragraph clineteCI = new Paragraph("Documento Id : " + project.Cliente.CI);
                document.Add(clineteCI);
                Paragraph clineteDireccion = new Paragraph("Dirección : " + project.Cliente.Direccion);
                document.Add(clineteDireccion);
                Paragraph clineteCodigo = new Paragraph("Codigo Reup/Nit :" + project.Cliente.Codigo);
                document.Add(clineteCodigo);
                Paragraph clinetePhone = new Paragraph("Telefono : " + project.Cliente.Telefono);
                document.Add(clinetePhone);
                Paragraph clineteCorreo = new Paragraph("Telefono : " + project.Cliente.Correo);
                document.Add(clineteCorreo);

                document.Add(new Paragraph(" "));

                document.Add(new Paragraph("Datos Inversion:"));

                
                Paragraph inversionZona = new Paragraph("Zona : " + project.Inversion.Zona?.Nombre);
                document.Add(inversionZona);
                Paragraph inversionProvincia = new Paragraph("Provincia : " + project.Inversion.Provincia?.Nombre);
                document.Add(inversionProvincia);
                Paragraph inversionMunicipio = new Paragraph("Municipio : " + project.Inversion.Municipio?.Nombre);
                document.Add(inversionMunicipio);
                Paragraph inversionReparto = new Paragraph("Reparto : " + project.Inversion.Reparto);
                document.Add(inversionReparto);
                Paragraph inversionManzana = new Paragraph("Manzana : " + project.Inversion.Manzana);
                document.Add(inversionManzana);
                Paragraph inversionDireccion = new Paragraph("Dirección : " + project.Inversion.NoCalle +" / "+ project.Inversion.ECalle);
                document.Add(inversionDireccion);
                Paragraph inversionCircunscripcion = new Paragraph("Circunscripción : " + project.Inversion.Circunscripcion);
                document.Add(inversionCircunscripcion);
                Paragraph inversionConsejoPopular = new Paragraph("Consejo Popular : " + project.Inversion.ConsejoPopular);
                document.Add(inversionConsejoPopular);
                Paragraph inversionEquipos = new Paragraph("Equipos : " + project.Inversion.Equipos);
                document.Add(inversionEquipos);
                Paragraph inversionOtros = new Paragraph("Otros : " + project.Inversion.Otros);
                document.Add(inversionOtros);
                Paragraph inversionConstruccion = new Paragraph("Construcción y Montaje : " + project.Inversion.ConstruccionMontaje);
                document.Add(inversionConstruccion);
                Paragraph inversionValorEstimado = new Paragraph("Valor Estimado : " + project.Inversion.ValorEstimadoConstruccion.ToString("0.00"));
                document.Add(inversionValorEstimado);
                Paragraph inversionValorAprobado = new Paragraph("Valor Aprobado : " + project.Inversion.ValorEstimadoAprobadoConstruccion.ToString("0.00"));
                document.Add(inversionValorAprobado);

                document.Add(new Paragraph(" "));

                document.Add(new Paragraph("Datos Generales:"));
                Paragraph superficieTotal = new Paragraph("Superficie Total : " + project.SuperficieTotal.ToString("0.00"));
                document.Add(superficieTotal);
                Paragraph areaOcupada = new Paragraph("Área Ocupada : " + project.AreaOcupada.ToString("0.00"));
                document.Add(areaOcupada);
                Paragraph cantidadPlantas = new Paragraph("Cantidad de Plantas : " + project.InversionLotes.CantidadPlantas.ToString());
                document.Add(cantidadPlantas);

                #region Diagnostico del terreno
                if (project.InversionLotes.NoTerreno > 0)
                { 
               
                var diagnostico = new Paragraph("Diagnostico del Terreno:");
               // diagnostico.Alignment = Element.ALIGN_CENTER;
                document.Add(diagnostico);
                document.Add(new Paragraph(" "));
                    Paragraph superficieVerde = new Paragraph("Superficie Verde : " + project.InversionLotes.SuperficieVerde.ToString("0.00"));
                    document.Add(superficieVerde);
                    Paragraph superficieHidrica = new Paragraph("Superficie Hidrica : " + project.InversionLotes.SuperficieHidrica.ToString("0.00"));
                    document.Add(superficieHidrica);
                    Paragraph profundidadManto = new Paragraph("Profundidad del Manto Freatico: " + project.InversionLotes.ProfundidadManto.ToString("0.00"));
                    document.Add(profundidadManto);
                    Paragraph topografia = new Paragraph("Topografía de Pendiente : " + project.InversionLotes.TopografiaPendiente.ToString("0.00"));
                    document.Add(topografia);
                    Paragraph cantHabitantes = new Paragraph("Cantidad de Habitantes : " + project.InversionLotes.CantidadHabitantes.ToString());
                    document.Add(cantHabitantes);
                    Paragraph transporte = new Paragraph("Vías de Transporte Público : " + project.InversionLotes.ViasTransportePublico);
                    document.Add(transporte);
                    document.Add(new Paragraph(" "));
                    if (!string.IsNullOrWhiteSpace(project.InversionLotes.UrlEvaluaciones)) {
                        document.NewPage();
                        var aptitudesPrimarias = new Paragraph("Aptitud Primaria General de un Territorio:");
                        aptitudesPrimarias.Alignment = Element.ALIGN_CENTER;
                        document.Add(aptitudesPrimarias);
                        document.Add(new Paragraph(" "));
                        Paragraph blankLine = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.WHITE, Element.ALIGN_LEFT, 1)));

                       Font font5 = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                        PdfPTable table = new PdfPTable(5);

                        Array floatArray = Array.CreateInstance(typeof(float), 5);
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

                      var  capacidad = _capacidadRepository.FindAllCapacidads(new CapacidadSearchOptions { ProyectoId = project.Id });
                        if (capacidad.Count > 0)
                        {
                            foreach (Capacidad r in capacidad)
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
                        var vulnerabilidades = capacidad;

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
                        tableTotales.AddCell(new Phrase(vulnerabilidades.Where(v => (v.EvalGeneral + v.EvalGeneralVulnerabilidad) == "AA").Count().ToString(), font5));

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
                    }
                }
                #endregion



                #region Plantas
                var plantas = project.InversionLotes.Plantas.OrderBy(p => p.Id);
                if (plantas != null && plantas.Any())
                {
                    document.NewPage();
                    var inmubleConstruido = new Paragraph("Inmueble Construido:");
                    inmubleConstruido.Alignment = Element.ALIGN_CENTER;
                    document.Add(inmubleConstruido);

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
                        Paragraph total = new Paragraph("Area Ocupada:" + planta.Area.ToString("0.00"));
                        total.Alignment = Element.ALIGN_CENTER;
                        document.Add(total);

                        document.Add(new Paragraph(" "));

                    }

                    document.NewPage();
                    var inmubleNuevo = new Paragraph("Inmueble Nuevo:");
                    inmubleNuevo.Alignment = Element.ALIGN_CENTER;
                    document.Add(inmubleNuevo);

                  
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

                }
                #endregion

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
