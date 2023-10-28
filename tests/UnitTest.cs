namespace PdfSplitter.UnitTests;

using PdfSplitter.Services;

public class UnitTest
{
    [Fact]
    public void Test()
    {
        var pdfSplitter = new PdfSplitterService();
        pdfSplitter.Split(Path.Combine(AppContext.BaseDirectory, "../../../data/study-methods.pdf"), "2-3");

        Assert.True(File.Exists(Path.Combine(AppContext.BaseDirectory, "study-methods_split.pdf")));
    }
}
