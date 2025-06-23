using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintPdfPowerBuilder;

namespace PrintPdfPwerBuilderTest
{
    [TestClass]
    public class PrintPdfTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            // Arrange
            var printPdf = new PrintPdfPowerBuilder.PrintPdf();
            string caminhoPdf = @"C:\Test\Boleto.pdf"; // Caminho do PDF
            // Act
            string resultado = printPdf.Print(caminhoPdf, 2);
            // Assert
            Assert.AreEqual(PdfEnumResult.Success.ToString(), resultado, "A impressão do PDF falhou ou o arquivo não foi encontrado.");
        }
    }
}
