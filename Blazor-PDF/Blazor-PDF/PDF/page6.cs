using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Blazor_PDF.PDF
{
    public class Page6
    {

        public static void PageList(Document pdf)
        {
            var list1 = new iTextSharp.text.List();
            list1.IndentationLeft = 12;
            list1.SetListSymbol("\u2022"); //Unicode Character 'BULLET'
            list1.Numbered = true;
            list1.Add(new ListItem("Value 1"));
            list1.Add(new ListItem("Value 2"));
            list1.Add(new ListItem("Value 3"));
            pdf.Add(list1);

            pdf.Add(new Chunk("\n")); //Tip to add Break Line

            list1 = new iTextSharp.text.List();
            list1.IndentationLeft = 20;
            list1.SetListSymbol("\u2022"); //Unicode Character 'BULLET'
            list1.Numbered = false;
            list1.Add(new ListItem("Value 1"));
            list1.Add(new ListItem("Value 2"));
            list1.Add(new ListItem("Value 3"));
            pdf.Add(list1);

            pdf.Add(new Chunk("\n")); //Tip to add Break Line


            Font _font = FontFactory.GetFont(BaseFont.ZAPFDINGBATS, 8f, Font.BOLD, BaseColor.Magenta);

            list1 = new iTextSharp.text.List();
            //list1.IndentationLeft = 18;
            list1.ListSymbol = new Chunk("H ", _font);
            list1.Numbered = false;
            list1.Add(new ListItem("Value 1"));
            list1.Add(new ListItem("Value 2"));
            list1.Add(new ListItem("Value 3"));
            pdf.Add(list1);
        }

    }
}
