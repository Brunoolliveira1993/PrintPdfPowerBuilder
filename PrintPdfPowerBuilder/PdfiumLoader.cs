using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PrintPdfPowerBuilder
{
    public static class PdfiumLoader
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        public static void Load()
        {
            string path = @"C:\Curso C#\PowerBuilder\pdfium.dll";
            IntPtr handle = LoadLibrary(path);
            if (handle == IntPtr.Zero)
            {
                throw new Exception($"Não foi possível carregar a DLL: {path}");
            }
        }
    }
}
