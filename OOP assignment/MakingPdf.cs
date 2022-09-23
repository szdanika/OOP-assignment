using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment
{
    internal class MakingPdf
    {
        public void MakePdf(DataTable dt, string directory,string docname, string head, string[] columnames)
        {
            PdfWriter pw = new PdfWriter(""+directory+"/"+ docname +"1.pdf");
            PdfDocument pd = new PdfDocument(pw);
            Document doc = new Document(pd);

            Paragraph header = new Paragraph(head).SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
            doc.Add(header);
            foreach(DataRow row in dt.Rows)
            {
                string cust = "";
                foreach(string col in columnames)
                {
                    cust += row[col] + "-";
                }
                Paragraph r = new Paragraph(cust);
                doc.Add(r);
            }

            doc.Close();
        }
    }
}
