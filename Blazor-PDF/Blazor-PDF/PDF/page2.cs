using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class Page2
    {
        private readonly static string _lopsem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas dictum felis ut turpis viverra, a ultrices nisi tempor. Aliquam suscipit dui sit amet facilisis aliquam. In scelerisque sem ut elit molestie tempor. In finibus sagittis nulla, vitae vestibulum ante tristique sit amet. Phasellus facilisis rhoncus nunc id scelerisque. Praesent cursus erat nec turpis interdum condimentum. Aenean ut facilisis eros. Nam semper tincidunt libero in porttitor. Praesent nec dui vitae leo vulputate varius ut non risus. Quisque imperdiet euismod ipsum facilisis finibus. Duis ac felis eget leo malesuada gravida id at felis. Cras posuere, tortor sit amet bibendum tincidunt, augue lectus pulvinar nisl, ac blandit velit arcu sed nulla. Mauris id venenatis turpis, ut fringilla nunc. Aenean commodo fermentum nulla, non porta sapien viverra sed. Sed sed risus interdum, maximus sapien ac, bibendum diam.";

        public static void PageBookmark(Document pdf)
        {
            float indentation = 20;
            Font _fontStyle = FontFactory.GetFont("Tahoma", 8f, Font.ITALIC);
            Font _linkStyle = FontFactory.GetFont("Tahoma", 8f, Font.UNDERLINE, BaseColor.Blue);

            Chapter chapter1 = new Chapter(new Paragraph("Bookmarks and Links"), 1)
            {
                BookmarkTitle = "Text & co",
                BookmarkOpen = true
            };
            chapter1.AddSection(indentation, "Section 1.1", 2);

            pdf.Add(chapter1);


            // Add a link to anchor
            var click = new Anchor("Click to an anchor-target in this document", _linkStyle)
            {
                Reference = "#target"
            };
            var paragraph1 = new Paragraph();
            paragraph1.IndentationLeft = indentation;
            paragraph1.Add(click);

            pdf.Add(paragraph1);


            // Add Paragraph
            var paragraph = new Paragraph(_lopsem, _fontStyle)
            {
                SpacingBefore = 10f,
                SpacingAfter = 10f,
                IndentationLeft = indentation,
                Alignment = Element.ALIGN_JUSTIFIED
            };

            pdf.Add(paragraph);


            // Add simple Link
            Anchor link = new Anchor("www.sodeasoft.com", _linkStyle)
            {
                Reference = "https://www.sodeasoft.com"
            };
            var paragraph3 = new Paragraph("Web link : ", _fontStyle)
            {
                IndentationLeft = indentation
            };
            paragraph3.Add(link);

            pdf.Add(paragraph3);


            // To add paragraph and add at the end the link:
            // paragraph.Add(link);

            Section section2 = chapter1.AddSection(indentation, "Section 1.2", 2);
            {
                section2.TriggerNewPage = false;

                Section subsection1 = section2.AddSection(indentation, "Subsection 1.2.1", 3);
                Section subsection2 = section2.AddSection(20f, "Subsection 1.2.2", 3);
                subsection2.AddSection(indentation, "Sub Subsection 1.2.2.1", 4);
                
            }

            pdf.Add(section2);


            Chapter chapter2 = new Chapter(new Paragraph("This is Chapter 2"), 2)
            {
                BookmarkOpen = false,
                TriggerNewPage = true
            };

            Section section3 = chapter2.AddSection("Section 2.1", 3);
            section3.AddSection("Subsection 2.1.1", 4);
            chapter2.AddSection("Section 2.2", 3);


            pdf.Add(chapter2);

            // Add the target from the Anchor above
            Anchor target = new Anchor("This is the Target");
            target.Name = "target";
            Paragraph paragraph2 = new Paragraph
            {
                target
            };
            pdf.Add(paragraph2);
        }

    }
}
