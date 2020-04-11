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


            //PdfContentByte cb = writer.DirectContent;
            //cb.SetLineWidth(3f);
            //cb.MoveTo(100, 700);
            //cb.LineTo(200, 800);

            //ColumnText ct = new ColumnText( cb);
            //ct.SetSimpleColumn((new Rectangle(0, 0, 523, 50));
            //ct.addElement(new Paragraph("This could be a very long sentence that needs to be wrapped"));
            //ct.go();

            docPDF.Add(phrase);
        }
    }
}
