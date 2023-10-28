namespace PdfSplitter.Services;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Text;

public class PdfSplitterService
{
    public void Split(string inputPdfPath, string pageRange)
    {
        if (!File.Exists(inputPdfPath))
        {
            Console.WriteLine("The provided file does not exist.");
            return;
        }

        string outputPath = Path.Combine(
            Path.GetDirectoryName(AppContext.BaseDirectory),
            $"{Path.GetFileNameWithoutExtension(inputPdfPath)}_split.pdf"
        );

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        using (PdfDocument inputDoc = PdfReader.Open(inputPdfPath, PdfDocumentOpenMode.Import))
        using (PdfDocument outputDoc = new PdfDocument())
        {
            string[] ranges = pageRange.Split(',');
            foreach (string range in ranges)
            {
                string[] pages = range.Trim().Split('-');
                int startPage = int.Parse(pages[0]);
                int endPage = pages.Length > 1 ? int.Parse(pages[1]) : startPage;

                for (int page = startPage; page <= endPage; page++)
                {
                    PdfPage inputPage = inputDoc.Pages[page - 1];
                    PdfPage outputPage = outputDoc.AddPage(inputPage);
                }
            }

            outputDoc.Save(outputPath);
        }

        Console.WriteLine("New PDF created at: " + outputPath);
    }
}
