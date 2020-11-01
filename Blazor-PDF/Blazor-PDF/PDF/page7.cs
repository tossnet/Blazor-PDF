using System;
using System.Runtime.CompilerServices;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class page7
    {
        public static void PageShapes(Document pdf, PdfWriter writer)
        {

            PdfContentByte cb = writer.DirectContent;


            // LINES 
            var title = new Paragraph("Lines", new Font(Font.HELVETICA, 20, Font.BOLD + Font.UNDERLINE));
            pdf.Add(title);

            
            cb.SetLineWidth(5);
            cb.SetColorStroke(new BaseColor(0, 140, 180));
            
            cb.MoveTo(40f, InverseY(120f));
            cb.LineTo(200f, InverseY(120f));
            cb.Stroke();

            cb.SetColorStroke(new BaseColor(10, 180, 80));
            cb.SetLineDash(20f,10f);
            cb.MoveTo(40f, InverseY(140f));
            cb.LineTo(200f, InverseY(140f));
            
            cb.Stroke();

            // Reset 
            cb.SetLineWidth(1);
            cb.SetLineDash(0);
            cb.SetColorStroke(new BaseColor(0, 0, 0));

            // SHAPES 
            ColumnText ct = new ColumnText(cb);
            Phrase ctitle = new Phrase("Shapes", new Font(Font.HELVETICA, 20, Font.BOLD + Font.UNDERLINE));
            ct.SetSimpleColumn(ctitle, 40f, 0, 580, InverseY(170f), 15, Element.ALIGN_LEFT);
            //lower-left-x
            //lower-left-y
            //upper-right-x(llx + width)
            //upper-right-y(lly + height)
            //leading(The amount of blank space between lines of print)
            ct.Go();

            //title = new Paragraph("Shapes", new Font(Font.HELVETICA, 20, Font.BOLD + Font.UNDERLINE));
            //pdf.Add(title);

            
            cb.Rectangle(40f, InverseY(200f), 120f, -50f);
            cb.Stroke();

            cb.SetColorStroke(BaseColor.Red);
            cb.Circle(200f, InverseY(230f), 30f);
            cb.Stroke();

            cb.SaveState();
            {
                PdfGState gs = new PdfGState();
                gs.FillOpacity = 0.5f;
                cb.SetGState(gs);
                cb.SetColorFill(BaseColor.Green);
                cb.Circle(220f, InverseY(240f), 30f);
                cb.Fill();
            }
            cb.RestoreState();

            cb.SetColorStroke(BaseColor.Blue);
            cb.Arc(300f, InverseY(220f), 360f, InverseY(280f), 45, 270);
            cb.Stroke();
            //

        }



        private static float InverseY(float Y)
        {
            // PDF uses a coordinate system which starts in the left corner at the BOTTOM of the page, not at the Top
            return PageSize.A4.Height - Y;
        }
    }
}
