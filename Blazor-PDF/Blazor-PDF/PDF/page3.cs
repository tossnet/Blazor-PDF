using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class Page3
    {

        public static void PageImage(Document pdf, PdfWriter writer)
        {

            string image = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\Logo.png"}";
            Image img = Image.GetInstance(image);

            img.SetAbsolutePosition(
                    (PageSize.A4.Width - img.ScaledWidth) / 2,
                    (PageSize.A4.Height - img.ScaledHeight) / 2);

            pdf.Add(img);


            //PdfContentByte cb = writer.DirectContent;
            //cb.SetLineWidth(3f);
            //cb.MoveTo(50, 20);
            //cb.LineTo(20, 80);
        }
    }
}
