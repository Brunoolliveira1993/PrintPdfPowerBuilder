using System;
using System.Drawing.Printing;
using System.IO;
using PdfiumViewer;

namespace PrintPdfPowerBuilder
{
    public class PrintPdf
    {
        public string Print(string pathPdf, string printerName, short numberCopies)
        {
            try
            {

                string path = pathPdf.Trim();

                if (string.IsNullOrEmpty(path))
                {
                    return $"{PdfEnumResult.PdfPathNotFound} : {path}";
                }

                if (!File.Exists(path))
                {
                    return $"{PdfEnumResult.PdfFileNotFound} : {path}";
                }

                String loadPdfium = PdfiumLoader.Load();

                if (!loadPdfium.Equals(PdfEnumResult.Success.ToString()))
                {
                    return loadPdfium;
                }

                using (var doc = PdfDocument.Load(path))

                using (var printDoc = doc.CreatePrintDocument())
                {
                    printDoc.PrintController = new StandardPrintController();
                    printDoc.PrinterSettings = new PrinterSettings
                    {

                        PrinterName = string.IsNullOrEmpty(printerName) ? new PrinterSettings().PrinterName : printerName,
                        Copies = numberCopies == 0 ? (short)1 : numberCopies,

                    };
                    printDoc.Print();
                }

                return PdfEnumResult.Success.ToString();
            }
            catch (Exception ex)
            {
                return $"{PdfEnumResult.Error} : {ex}";
            }
        }

        public string Print(string pathPdf, string printerName)
        {
            return Print(pathPdf, printerName, 1);
        }

        public string Print(string pathPdf, short numberCopies)
        {
            return Print(pathPdf, string.Empty, numberCopies);
        }

        public string Print(string pathPdf)
        {
            return Print(pathPdf, string.Empty, 1);
        }
    }
}