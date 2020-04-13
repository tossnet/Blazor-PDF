using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class PDFHeaderFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);

            PdfPTable header = new PdfPTable(1)
            {
                SpacingAfter = 30F,
                TotalWidth = PageSize.A4.Width - document.LeftMargin -document.RightMargin,
                LockedWidth = true
            };

            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);

            var labelHeader = new Chunk("Header Blazor PDF", fontStyle);

            PdfPCell cell = new PdfPCell(new Phrase(labelHeader))
            {
                BackgroundColor = new BaseColor(133, 76, 199),
                Border = 0,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_TOP
            };

            header.AddCell(cell);

            header.WriteSelectedRows(0, -1, document.LeftMargin, document.Top, writer.DirectContent);

            //var f = FontFactory.GetFont("Arial", 16, BaseColor.Green);
            //Paragraph p = new Paragraph("ESZRFGZSEFGZEF", f);
            //document.Add(p);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("Footer"));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }
}
