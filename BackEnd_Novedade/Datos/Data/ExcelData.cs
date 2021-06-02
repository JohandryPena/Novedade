

using OfficeOpenXml;
using System.IO;
using System.Linq;

namespace Datos.Data
{
    public class ExcelData
    {
        public static ExcelPackage get()
        {
    
            
                string path = @"C:\Users\johan\Desktop\Nueva carpeta\Canguro\Canguro\Asset\Cuentas de nomina (Formato para Pagos).xlsx";
                FileInfo file = new FileInfo(path);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //Load excel stream
                ExcelPackage package = new ExcelPackage(file);
               var worksheet = package.Workbook.Worksheets.First();
                worksheet.Cells[1, 1].Value = "1";
                return package;
          
            
        }

    }
}
