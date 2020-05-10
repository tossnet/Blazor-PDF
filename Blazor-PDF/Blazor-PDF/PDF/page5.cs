using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Blazor_PDF.PDF
{
    public class Page5
    {
        public static void PageFonts(Document pdf, PdfWriter writer)
        {

            // FONTS 
            var title = new Paragraph("Fonts standard", new Font(Font.HELVETICA, 20, Font.BOLD));
            pdf.Add(title);


            // --- TIMES ROMAN
            title = new Paragraph("Times Roman")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);


            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, encoding:BaseFont.CP1252, embedded:false);
            Pattern(pdf, bfTimes);


            // --- COURIER
            title = new Paragraph("Courier")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bfCourier= BaseFont.CreateFont(BaseFont.COURIER, encoding: BaseFont.CP1252, embedded: false);
            Pattern(pdf, bfCourier);


            // --- HELVETICA
            title = new Paragraph("Helvetica")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bfHelvetica = BaseFont.CreateFont(BaseFont.HELVETICA, encoding: BaseFont.CP1252, embedded: false);
            Pattern(pdf, bfHelvetica);


            // --- SYMBOL
            title = new Paragraph("Symbol")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bSymbol = BaseFont.CreateFont(BaseFont.SYMBOL, encoding: BaseFont.CP1252, embedded: false);
            Pattern(pdf, bSymbol);


            // --- ZAPDINGBATS
            title = new Paragraph("ZapfDingBats®")
            {
                SpacingBefore = 18f,
                SpacingAfter = 9f
            };
            pdf.Add(title);

            BaseFont bZapfDingBats = BaseFont.CreateFont(BaseFont.ZAPFDINGBATS, encoding: BaseFont.CP1252, embedded: false);
            Pattern(pdf, bZapfDingBats);


            // BREAK RETURN : so easy ^^
            pdf.NewPage();


            // FONTS  EMBEDDED INTO THE PDF
            title = new Paragraph("Font embedded", new Font(Font.HELVETICA, 20, Font.BOLD));
            pdf.Add(title);

            BaseFont myfont = BaseFont.CreateFont(@"Assets/Moder DOS 437.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font = new Font(myfont, 14);

            string s = "Add your own font in your document as here the Moder DOS";

            pdf.Add(new Paragraph(s, font));

            
            Table datatable = new Table(16);
            datatable.Padding = 2;
            datatable.Spacing = 0;
            datatable.Border = 0;
            float[] headerwidths = Enumerable.Range(0, 16).Select(i => 1.6f).ToArray();
            datatable.Widths = headerwidths;
            datatable.DefaultHorizontalAlignment = Element.ALIGN_CENTER;

            int m = 9;
            string charater;

            for (int r = 0; r < 16; r++)
            {
                for (int c = 0; c < 16; c++)
                {
                    if (m > 31)
                    {
                        charater = Convert.ToChar(m).ToString();
                        datatable.AddCell(new Paragraph(charater, font));
                    }
                    m++;
                }
            }
            pdf.Add(datatable);

        }



        private static void Pattern(Document pdf, BaseFont basefont)
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
