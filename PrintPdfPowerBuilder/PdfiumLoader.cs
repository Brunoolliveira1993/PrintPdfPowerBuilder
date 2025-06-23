using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;



namespace PrintPdfPowerBuilder
{
    public static class PdfiumLoader
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        //private static extern IntPtr LoadLibrary(string lpFileName);
        static extern bool SetDllDirectory(string lpPathName);

        public static string Load()
        {
            String pathDll = GetDirectoryDll();

            if (!Directory.Exists(pathDll))
            {
                return PdfEnumResult.DirectoryNotFound.ToString() + " : " + pathDll; 

                
            }

            Boolean dllDirectorySet = SetDllDirectory(pathDll);

            if (!dllDirectorySet)
            {
                return PdfEnumResult.DirectorySetError.ToString() + " : " + pathDll;
            }

            return PdfEnumResult.Success.ToString();
        }

        private static string GetDirectoryDll()
        {
            Boolean is64Bits = Environment.Is64BitProcess;

            string diretorioDll = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string arquitetura = is64Bits ? "X64" : "X86";

            return Path.Combine(diretorioDll, "pdfium", arquitetura);
          
        }
    }
}
