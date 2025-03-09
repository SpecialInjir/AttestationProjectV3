using OfficeOpenXml;

/// <summary>
/// Класс для работы с Excel файлами.
/// </summary>
internal static class ExcelHelper
{
    private const int HeaderRow = 1;
    private const int FirstDataRow = 2;

    /// <summary>
    /// Экспортирует данные в Excel-файл.
    /// </summary>
    /// <typeparam name="T">Тип данных.</typeparam>
    /// <param name="data">Коллекция данных.</param>
    /// <param name="filePath">Путь к файлу для сохранения.</param>
    /// <param name="sheetName">Название листа.</param>
    /// <param name="headers">Заголовки столбцов.</param>
    /// <param name="valueSelector">Делегат для извлечения значений из данных.</param>
    internal static void ExportToExcel<T>(
        IEnumerable<T> data,
        string filePath,
        string sheetName,
        IList<string> headers,
        Func<T, IList<object>> valueSelector)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data), "Коллекция данных не может быть null.");
        }

        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath), "Путь к файлу не может быть пустым.");
        }

        if (string.IsNullOrEmpty(sheetName))
        {
            throw new ArgumentNullException(nameof(sheetName), "Название листа не может быть пустым.");
        }

        if (headers == null || headers.Count == 0)
        {
            throw new ArgumentNullException(nameof(headers), "Заголовки столбцов не могут быть null или пустыми.");
        }

        if (valueSelector == null)
        {
            throw new ArgumentNullException(nameof(valueSelector), "Делегат для извлечения значений не может быть null.");
        }

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add(sheetName);

            for (int i = 0; i < headers.Count; i++)
            {
                worksheet.Cells[HeaderRow, i + 1].Value = headers[i];
            }

            int row = FirstDataRow;
            foreach (var item in data)
            {
                var values = valueSelector(item);
                for (int col = 0; col < values.Count; col++)
                {
                    worksheet.Cells[row, col + 1].Value = values[col];
                }
                row++;
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            package.SaveAs(new FileInfo(filePath));
        }
    }
}
