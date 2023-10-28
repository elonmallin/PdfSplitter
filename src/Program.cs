using PdfSplitter.Services;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Drag and drop a PDF file onto this program.");
            return;
        }

        Console.Write("Enter the page range (e.g., 1-5, 7, 10-12): ");
        string pageRange = Console.ReadLine();

        var pdfSplitter = new PdfSplitterService();
        pdfSplitter.Split(args[0], pageRange);
    }
}
