using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_PDF.PDF
{
    public class Report
    {

        Document _doc;
        MemoryStream memoryStream = new MemoryStream();
        Font _fontStyle;

        private byte[] ReportPDF()
        {
            _doc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_doc, memoryStream);
            _doc.Open();

            var phrase = new Phrase("Planning", _fontStyle);

            _doc.Add(phrase);

            _doc.Close();
            return memoryStream.ToArray();
        }

        public void Generate(IJSRuntime js)
        {
            js.InvokeVoidAsync(
                "saveAsFile",
                "report.pdf",
                Convert.ToBase64String(ReportPDF())
                );
        }
    }
}
