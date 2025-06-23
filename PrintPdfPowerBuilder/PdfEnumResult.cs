using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPdfPowerBuilder
{
    public enum PdfEnumResult
    {
        Success = 1,
        PdfFileNotFound = -1,
        DirectoryNotFound = -2,
        DirectorySetError = -3,
        PdfPathNotFound = -4,
        Error = -5

    }
    
}
