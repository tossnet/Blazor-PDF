using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class Page4
    {
        public static void PageTable(Document pdf, PdfWriter writer)
        {

            // TABLES 
            var title = new Paragraph("My First Table", new Font(Font.HELVETICA, 20, Font.BOLD));
            pdf.Add(title);


            Table datatable = new Table(3);
            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 6, 20, 32 };

            datatable.Widths = headerwidths;
            datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;

            int m = 0;
            for (int i = 0; i < 12; i++)
            {
                m += i;
                datatable.AddCell(i.ToString());
                datatable.AddCell("Blazor is super simple.");
                datatable.AddCell("right?");
            }


            datatable.AddCell("=" + m.ToString());
            datatable.AddCell("Yes");
            datatable.AddCell("Strongly agree");

            pdf.Add(datatable);
            
        }
    }
}
