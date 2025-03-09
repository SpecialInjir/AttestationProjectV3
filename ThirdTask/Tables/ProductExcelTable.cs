using ThirdTask.Filters;
using ThirdTask.Models;
using ThirdTask.Utils;

namespace ThirdTask.Tables
{
    /// <summary>
    /// Класс для работы с таблицей Excel, содержащей товары.
    /// </summary>
    internal sealed class ProductExcelTable
    {
        // Константы для путей и названий
        private const string ExcelFileName = "Products.xlsx";
        private const string SheetName = "Товары";
        private static readonly string[] Headers = { "Наименование товара", "Цена товара" };
        private const decimal MaxProductPrice = 10000m;

        /// <summary>
        /// Создает таблицу Excel, заполняет её отфильтрованными и отсортированными данными и открывает файл.
        /// </summary>
        /// <param name="products">Спикок продуктов.</param>
        public static void CreateAndOpenExcel(IEnumerable<Product> products)
        {
            var filteredProducts = ProductFilter.FilterAndSortProducts(products, MaxProductPrice);
            string filePath = Path.Combine(FileSystemHelper.GetProjectFilesRoot(), ExcelFileName);

            ExcelHelper.ExportToExcel(filteredProducts, filePath, SheetName, Headers, p => [p.Name, p.Price]);

            Console.WriteLine($"Данные успешно экспортированы в файл: {filePath}");

            FileOpener.OpenFile(filePath);
        }
    }
}