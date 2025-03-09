using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ThirdTask.Utils
{
    /// <summary>
    /// Утилиты для открытия файлов.
    /// </summary>
    internal static class FileOpener
    {
        /// <summary>
        /// Открывает файл с помощью стандартного приложения.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        internal static void OpenFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", filePath);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", filePath);
                }
                else
                {
                    throw new PlatformNotSupportedException("Операционная система не поддерживается.");
                }

                Console.WriteLine("Файл успешно открыт.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось открыть файл: {ex.Message}");
            }
        }
    }
}