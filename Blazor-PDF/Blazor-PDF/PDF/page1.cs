using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class Page1
    {
        private readonly static string _lopsem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas dictum felis ut turpis viverra, a ultrices nisi tempor. Aliquam suscipit dui sit amet facilisis aliquam. In scelerisque sem ut elit molestie tempor. In finibus sagittis nulla, vitae vestibulum ante tristique sit amet. Phasellus facilisis rhoncus nunc id scelerisque. Praesent cursus erat nec turpis interdum condimentum. Aenean ut facilisis eros. Nam semper tincidunt libero in porttitor. Praesent nec dui vitae leo vulputate varius ut non risus. Quisque imperdiet euismod ipsum facilisis finibus. Duis ac felis eget leo malesuada gravida id at felis. Cras posuere, tortor sit amet bibendum tincidunt, augue lectus pulvinar nisl, ac blandit velit arcu sed nulla. Mauris id venenatis turpis, ut fringilla nunc. Aenean commodo fermentum nulla, non porta sapien viverra sed. Sed sed risus interdum, maximus sapien ac, bibendum diam.";

        public static void PageText(Document pdf)
        {
            var title = new Paragraph("Text and Paragraphe", new Font(Font.HELVETICA, 20, Font.BOLD));
            title.SpacingAfter = 18f;

            pdf.Add(title);

            Font _fontStyle = FontFactory.GetFont("Tahoma", 8f, Font.ITALIC);

            var phrase = new Phrase(_lopsem, _fontStyle);
            pdf.Add(phrase);

            // Create and add a Paragraph
            var p = new Paragraph("Paragraph On the Right", _fontStyle);
            p.SpacingBefore = 20f;
            p.SetAlignment("RIGHT");

            pdf.Add(p);


            float margeborder = 1.5f;
            float widhtColumn = 8.5f;
            float space = 1.0f;

            MultiColumnText columns = new MultiColumnText();
            columns.AddSimpleColumn(margeborder.ToDpi(), 
                                    pdf.PageSize.Width - margeborder.ToDpi() - space.ToDpi() - widhtColumn.ToDpi());
            columns.AddSimpleColumn(margeborder.ToDpi() + widhtColumn.ToDpi() + space.ToDpi(), 
                                    pdf.PageSize.Width - margeborder.ToDpi());

            Paragraph para = new Paragraph(_lopsem, new Font(Font.HELVETICA, 8f));
            para.SpacingAfter = 9f;
            para.Alignment = Element.ALIGN_JUSTIFIED;

            columns.AddElement(para);

            pdf.Add(columns);
        }
    }
}
