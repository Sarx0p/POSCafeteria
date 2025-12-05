using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;        
using QuestPDF.Helpers;       
using QuestPDF.Infrastructure;

namespace proyectoPOScafeteria.Reportes
{
    public class ReporteVentasDocumento : IDocument
    {
        private readonly ReporteVentasModel Modelo;

        // Constructor que recibe el modelo de ventas
        public ReporteVentasDocumento(ReporteVentasModel modelo)
        {
            Modelo = modelo;
        }

        // =============================
        // 1) METADATA DEL DOCUMENTO PDF
        // =============================
        // QuestPDF permite definir título, autor, sujeto, etc.
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        // ===================================
        // 2) CONFIGURACIONES DEL DOCUMENTO PDF
        // ===================================
        // En esta versión de QuestPDF no se necesita modificar nada.
        public DocumentSettings GetSettings() => new DocumentSettings();

        // ==========================================
        // 3) COMPOSICIÓN: AQUÍ SE DIBUJA EL DOCUMENTO
        // ==========================================
        public void Compose(IDocumentContainer container)
        {
            // Definimos que el documento contiene una sola página completa
            container.Page(page =>
            {
                page.Size(PageSizes.A4);     // Tamaño carta internacional (A4)
                page.Margin(30);             // Márgenes alrededor

                // -----------------------
                // SECCIÓN DE ENCABEZADO
                // -----------------------
                page.Header().Column(col =>
                {
                    col.Item().Text("CAFÉ DULCE AROMA")
                        .Bold().FontSize(20);

                    col.Item().Text("Reporte de Ventas por Período")
                        .FontSize(14);

                    col.Item().Text($"Desde {Modelo.Inicio:dd/MM/yyyy} — Hasta {Modelo.Fin:dd/MM/yyyy}")
                        .FontSize(11);
                });

                // -----------------------
                // CUERPO PRINCIPAL (TABLA)
                // -----------------------
                page.Content().PaddingTop(20)
                    .Element(GenerarTabla);

                // -----------------------
                // PIE DE PÁGINA
                // -----------------------
                page.Footer().AlignCenter().Text(txt =>
                {
                    txt.Span("Generado el ").SemiBold();
                    txt.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    txt.Line(" — Sistema POS Café Dulce Aroma");
                });
            });
        }

        // ===========================================================
        // MÉTODO QUE DIBUJA LA TABLA DE VENTAS EN EL CUERPO DEL PDF
        // ===========================================================
        private void GenerarTabla(IContainer container)
        {
            container.Table(table =>
            {
                // ---------------------------
                // DEFINICIÓN DE COLUMNAS
                // ---------------------------
                table.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn(3); // Producto
                    cols.RelativeColumn(1); // Cantidad
                    cols.RelativeColumn(1); // Precio Unitario
                    cols.RelativeColumn(1); // Subtotal
                });

                // ---------------------------
                // ENCABEZADO DE LA TABLA
                // ---------------------------
                table.Header(header =>
                {
                    header.Cell().Background("#EAEAEA").Padding(5).Text("Producto").SemiBold();
                    header.Cell().Background("#EAEAEA").Padding(5).Text("Cantidad").SemiBold();
                    header.Cell().Background("#EAEAEA").Padding(5).Text("Precio").SemiBold();
                    header.Cell().Background("#EAEAEA").Padding(5).Text("Subtotal").SemiBold();
                });

                decimal totalGeneral = 0; // Para acumular el total del período

                // ---------------------------
                // RECORRER TODAS LAS FILAS
                // ---------------------------
                foreach (DataRow row in Modelo.Tabla.Rows)
                {
                    string producto = row["Nombre"].ToString();
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal precio = Convert.ToDecimal(row["PrecioUnitario"]);
                    decimal subtotal = Convert.ToDecimal(row["SubTotal"]);

                    totalGeneral += subtotal; // Suma al total general

                    table.Cell().Padding(4).Text(producto);
                    table.Cell().Padding(4).Text(cantidad.ToString());
                    table.Cell().Padding(4).Text(precio.ToString("C2"));
                    table.Cell().Padding(4).Text(subtotal.ToString("C2"));
                }

                // ---------------------------
                // FILA FINAL: TOTAL GENERAL
                // ---------------------------
                table.Cell().ColumnSpan(4).AlignRight().Padding(10)
                    .Text($"TOTAL GENERAL: {totalGeneral:C2}")
                    .Bold().FontSize(14);
            });
        }
    }

}

