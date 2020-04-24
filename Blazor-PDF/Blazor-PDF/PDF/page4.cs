using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class Page4
    {
        public static void PageFonts(Document pdf, PdfWriter writer)
        {
            var title = new Paragraph("Fonts standard", new Font(Font.HELVETICA, 20, Font.BOLD));
            pdf.Add(title);


            // Fonts

            title = new Paragraph("Times Roman")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);


            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, encoding:BaseFont.CP1252, embedded:false);
            Examples(pdf, bfTimes);


            title = new Paragraph("Courier")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bfCourier= BaseFont.CreateFont(BaseFont.COURIER, encoding: BaseFont.CP1252, embedded: false);
            Examples(pdf, bfCourier);
        }


        private static void Examples(Document pdf, BaseFont basefont)
        {
            string text = "0123456789 ABDCEFGHIJKLMNOPQRSTXYWZ abcdefghijklmnopqrstuvwxyz @&*$€";

            Font font = new Font(basefont, 12, Font.NORMAL, BaseColor.Black);
            var paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, 12, Font.BOLD, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, 12, Font.ITALIC, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, 12, Font.UNDERLINE, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, 12, Font.BOLD + Font.ITALIC, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, 12, Font.STRIKETHRU, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);
        }
    }
}
