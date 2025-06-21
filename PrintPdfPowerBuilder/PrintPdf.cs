
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using PdfiumViewer;
using System.IO;
using System;

namespace PrintPdfPowerBuilder
{

    [ComVisible(true)]
    [Guid("A1112223-B444-5678-C999-123456789ABC")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PrintPdf : IPrintPdf
    {
        public int Print(string caminhoPdf)
        {
            try
            {
                if (!File.Exists(caminhoPdf))
                    return 0;

                PdfiumLoader.Load();

                using (var doc = PdfDocument.Load(caminhoPdf))
                {
                    using (var printDoc = doc.CreatePrintDocument())
                    {
                        printDoc.PrintController = new StandardPrintController(); // silencioso  
                        printDoc.PrinterSettings = new PrinterSettings(); // usa a padrão  
                        printDoc.Print();
                    }
                }

                return 1;
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("Ocorreu um erro ao executar a impressao. Detalhes: " + ex.Message, ex);
            }
        }
    }

    [ComVisible(true)]
    [Guid("C9876543-1234-4321-ABCD-76543210FEDC")]
    public interface IPrintPdf
    {
        int Print(string caminhoPdf);
    }
}
