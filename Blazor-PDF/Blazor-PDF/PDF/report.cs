using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazor_PDF;

namespace Blazor_PDF.PDF
{
    public class Report
    {

        private Document _docPDF;
        private PdfWriter writer;

        public void Generate(IJSRuntime js)
        {
            js.InvokeVoidAsync(
                "saveAsFile",
                "report.pdf",
                Convert.ToBase64String(ReportPDF())
                );
        }

        private byte[] ReportPDF()
        {
            var memoryStream = new MemoryStream();

            float margeLeft = 1.5f;
            float margeRight= 1.5f;
            float margeTop = 2f;
            float margeBottom = 2f;

            _docPDF = new Document(
                            PageSize.A4,
                            margeLeft.ToDpi(),
                            margeRight.ToDpi(),
                            margeTop.ToDpi(),
                            margeBottom.ToDpi());

            writer = PdfWriter.GetInstance(_docPDF, memoryStream);
            _docPDF.Open();

            PageText(_docPDF);

            _docPDF.Close();
            return memoryStream.ToArray();
        }


        private void PageText(Document docPDF)
        {
            Font _fontStyle = FontFactory.GetFont("Tahoma", 8f, Font.NORMAL);

            var lopsem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas dictum felis ut turpis viverra, a ultrices nisi tempor. Aliquam suscipit dui sit amet facilisis aliquam. In scelerisque sem ut elit molestie tempor. In finibus sagittis nulla, vitae vestibulum ante tristique sit amet. Phasellus facilisis rhoncus nunc id scelerisque. Praesent cursus erat nec turpis interdum condimentum. Aenean ut facilisis eros. Nam semper tincidunt libero in porttitor. Praesent nec dui vitae leo vulputate varius ut non risus. Quisque imperdiet euismod ipsum facilisis finibus. Duis ac felis eget leo malesuada gravida id at felis. Cras posuere, tortor sit amet bibendum tincidunt, augue lectus pulvinar nisl, ac blandit velit arcu sed nulla. Mauris id venenatis turpis, ut fringilla nunc. Aenean commodo fermentum nulla, non porta sapien viverra sed. Sed sed risus interdum, maximus sapien ac, bibendum diam.";

            var phrase = new Phrase(lopsem, _fontStyle);

            // Create and add a Paragraph
            Paragraph p = new Paragraph("Paragraph On the Right", _fontStyle);
            p.SetAlignment("RIGHT");
            docPDF.Add(p);

            // Create and add an Image
            string image = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\Logo.png"}";
            Image img = Image.GetInstance(image);
            //img.SetAbsolutePosition(
            //        (PageSize.POSTCARD.getWidth() - img.getScaledWidth()) / 2,
            //        (PageSize.POSTCARD.getHeight() - img.getScaledHeight()) / 2);
            docPDF.Add(img);


            PdfContentByte cb = writer.DirectContent;
            //cb.SetLineWidth(3f);
            //cb.MoveTo(50, 20);
            //cb.LineTo(20, 80);

            ColumnText ct = new ColumnText(cb);
            float urx = 5;
            float ury = 5;
            ct.SetSimpleColumn(phrase,20,20, urx.ToDpi(), ury.ToDpi(),8, Element.ALIGN_JUSTIFIED);
            
            ct.Go();

            docPDF.Add(phrase);
        }
    }
}
