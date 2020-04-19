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
        private int _pagenumber;
        private readonly string _lopsem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas dictum felis ut turpis viverra, a ultrices nisi tempor. Aliquam suscipit dui sit amet facilisis aliquam. In scelerisque sem ut elit molestie tempor. In finibus sagittis nulla, vitae vestibulum ante tristique sit amet. Phasellus facilisis rhoncus nunc id scelerisque. Praesent cursus erat nec turpis interdum condimentum. Aenean ut facilisis eros. Nam semper tincidunt libero in porttitor. Praesent nec dui vitae leo vulputate varius ut non risus. Quisque imperdiet euismod ipsum facilisis finibus. Duis ac felis eget leo malesuada gravida id at felis. Cras posuere, tortor sit amet bibendum tincidunt, augue lectus pulvinar nisl, ac blandit velit arcu sed nulla. Mauris id venenatis turpis, ut fringilla nunc. Aenean commodo fermentum nulla, non porta sapien viverra sed. Sed sed risus interdum, maximus sapien ac, bibendum diam.";

        public void Generate(IJSRuntime js, int pagenumber, string filename = "report.pdf")
        {
            _pagenumber = pagenumber;
            js.InvokeVoidAsync(
                "saveAsFile",
                filename,
                Convert.ToBase64String(ReportPDF())
                );
        }

        private byte[] ReportPDF()
        {
            var memoryStream = new MemoryStream();

            // Marge in centimeter, then I convert with .ToDpi()
            float margeLeft = 1.5f;
            float margeRight= 1.5f;
            float margeTop = 1.0f;
            float margeBottom = 15.0f;

            _docPDF = new Document(
                                    PageSize.A4,
                                    margeLeft.ToDpi(),
                                    margeRight.ToDpi(),
                                    margeTop.ToDpi(),
                                    margeBottom.ToDpi()
                                   );

            _docPDF.AddTitle("Blazor-PDF");
            _docPDF.AddAuthor( "Christophe Peugnet");
            _docPDF.AddCreationDate();
            _docPDF.AddKeywords("blazor");
            _docPDF.AddSubject("Create a pdf file with iText");

            writer = PdfWriter.GetInstance(_docPDF, memoryStream);

            //HEADER and FOOTER
            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
            var labelHeader = new Chunk("Header Blazor PDF", fontStyle);
            HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
            {
                BackgroundColor = new BaseColor(133, 76, 199),
                Alignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER
            };
            //header.Border = Rectangle.NO_BORDER;
            _docPDF.Header = header;


            var labelFooter = new Chunk("Page", fontStyle);
            HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), true)
            {
                Border = Rectangle.NO_BORDER,
                Alignment = Element.ALIGN_RIGHT
            };
            _docPDF.Footer = footer;

            _docPDF.Open();


            if ( _pagenumber == 1 )
                PageText();
            else if ( _pagenumber == 2 )
                PageBookmark();
            else if ( _pagenumber == 3 )
                PageImage();

            _docPDF.Close();

            return memoryStream.ToArray();
        }


        private void PageText()
        {
            Font _fontStyle = FontFactory.GetFont("Tahoma", 8f, Font.NORMAL);

            var phrase = new Phrase(_lopsem, _fontStyle);

            // Create and add a Paragraph
            Paragraph p = new Paragraph("Paragraph On the Right", _fontStyle)
            {
                SpacingBefore = 20f
            };
            p.SetAlignment("RIGHT");
            _docPDF.Add(p);

            PdfContentByte cb = writer.DirectContent;

            ColumnText ct = new ColumnText(cb);
            float urx = 5;
            float ury = 5;
            ct.SetSimpleColumn(phrase,20,20, urx.ToDpi(), ury.ToDpi(),8, Element.ALIGN_JUSTIFIED);
            
            ct.Go();

            _docPDF.Add(phrase);
        }


        private void PageBookmark()
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

            _docPDF.Add(chapter1);


            // Add a link to anchor
            var click = new Anchor("Click to an anchor-target in this document", _linkStyle)
            {
                Reference = "#target"
            };
            var paragraph1 = new Paragraph
            {
                IndentationLeft = indentation
            };
            paragraph1.Add(click);

            _docPDF.Add(paragraph1);


            // Add Paragraph
            var paragraph = new Paragraph(_lopsem, _fontStyle)
            {
                SpacingBefore = 10f,
                SpacingAfter = 10f,
                IndentationLeft= indentation,
                Alignment=Element.ALIGN_JUSTIFIED
            };

            _docPDF.Add(paragraph);


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

            _docPDF.Add(paragraph3);


            // To add paragraph and add at the end the link:
            // paragraph.Add(link);

            Section section2 = chapter1.AddSection(indentation, "Section 1.2", 2);
            {
                section2.TriggerNewPage = false;

                Section subsection1 = section2.AddSection(indentation, "Subsection 1.2.1", 3);
                Section subsection2 = section2.AddSection(20f, "Subsection 1.2.2", 3);
                {
                    Section subsubsection = subsection2.AddSection(indentation, "Sub Subsection 1.2.2.1", 4);
                }
            }

            _docPDF.Add(section2);


            Chapter chapter2 = new Chapter(new Paragraph("This is Chapter 2"),2)
            {
                BookmarkOpen = false,
                TriggerNewPage = true
            };
          
            Section section3 = chapter2.AddSection("Section 2.1", 3);

            Section subsection3 = section3.AddSection("Subsection 2.1.1", 4);

            Section section4 = chapter2.AddSection("Section 2.2", 3);


            _docPDF.Add(chapter2);

            // Add the target from the Anchor above
            Anchor target = new Anchor("This is the Target");
            target.Name = "target";
            Paragraph paragraph2 = new Paragraph
            {
                target
            };
            _docPDF.Add(paragraph2);
        }




        private void PageImage()
        {
            
            string image = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\Logo.png"}";
            Image img = Image.GetInstance(image);

            img.SetAbsolutePosition(
                    (PageSize.A4.Width - img.ScaledWidth) / 2,
                    (PageSize.A4.Height - img.ScaledHeight) / 2);

            _docPDF.Add(img);


            //PdfContentByte cb = writer.DirectContent;
            //cb.SetLineWidth(3f);
            //cb.MoveTo(50, 20);
            //cb.LineTo(20, 80);
        }


    }
}
