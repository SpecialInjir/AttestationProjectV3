using OfficeOpenXml;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ThirdTask.Filters;
using ThirdTask.Services;
using ThirdTask.Tables;

namespace ThirdTask
{
    static class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //Получение тестовых данных
            var products = TestDataProvider.GetTestProducts();

            _ = new ProductExcelTable();
            ProductExcelTable.CreateAndOpenExcel(products);
        }
      
    }

}
