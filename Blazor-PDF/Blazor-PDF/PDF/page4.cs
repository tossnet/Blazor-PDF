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


            title = new Paragraph("Helvetica")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bfHelvetica = BaseFont.CreateFont(BaseFont.HELVETICA, encoding: BaseFont.CP1252, embedded: false);
            Examples(pdf, bfHelvetica);


            title = new Paragraph("Symbol")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bSymbol = BaseFont.CreateFont(BaseFont.SYMBOL, encoding: BaseFont.CP1252, embedded: false);
            Examples(pdf, bSymbol);


            title = new Paragraph("ZapfDingBats®")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bZapfDingBats = BaseFont.CreateFont(BaseFont.ZAPFDINGBATS, encoding: BaseFont.CP1252, embedded: false);
            Examples(pdf, bZapfDingBats);
        }


        private static void Examples(Document pdf, BaseFont basefont)
        {
            string text = "0123456789 ABDCEFGHIJKLMNOPQRSTXYWZ abcdefghijklmnopqrstuvwxyz @&*$€";
            float fontSize = 12;

            Font font = new Font(basefont, fontSize, Font.NORMAL, BaseColor.Black);
            var paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);


            if (basefont.PostscriptFontName == BaseFont.SYMBOL) return;
            if (basefont.PostscriptFontName == BaseFont.ZAPFDINGBATS) return;


            font = new Font(basefont, fontSize, Font.BOLD, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, fontSize, Font.ITALIC, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, fontSize, Font.UNDERLINE, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, fontSize, Font.BOLD + Font.ITALIC, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);

            font = new Font(basefont, fontSize, Font.STRIKETHRU, BaseColor.Black);
            paragraph = new Paragraph(text, font);
            pdf.Add(paragraph);
        }
    }
}
