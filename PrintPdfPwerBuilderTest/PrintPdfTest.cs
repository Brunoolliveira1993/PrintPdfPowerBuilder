using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string caminhoPdf = @"C:\Curso C#\PowerBuilder\Boleto.pdf"; // Certifique-se de que o caminho do PDF é válido
            // Act
            int resultado = printPdf.Print(caminhoPdf);
            // Assert
            Assert.AreEqual(1, resultado, "A impressão do PDF falhou ou o arquivo não foi encontrado.");
        }
    }
}
