namespace ThirdTask.Utils
{
    /// <summary>
    /// Утилиты для работы с файловой системой.
    /// </summary>
    internal static class FileSystemHelper
    {
        private const string FilesFolderName = "Files";

        /// <summary>
        /// Возвращает корневую директорию проекта.
        /// </summary>
        /// <returns>Корневая директория проекта.</returns>
        /// <exception cref="InvalidOperationException">Если не удается определить корневую директорию.</exception>
        internal static string GetProjectRoot()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(currentDirectory);

            if (parentDirectory == null || parentDirectory.Parent == null || parentDirectory.Parent.Parent == null)
            {
                throw new InvalidOperationException("Не удалось определить корневую директорию проекта.");
            }

            return parentDirectory.Parent.Parent.FullName;
        }

        /// <summary>
        /// Возвращает директорию для хранения файлов.
        /// </summary>
        /// <returns>Директория для хранения файлов.</returns>
        internal static string GetProjectFilesRoot()
        {
            var projectRoot = GetProjectRoot();
            var path = Path.Combine(projectRoot, FilesFolderName);

            CreateFolderIfNotExists(path);

            return path;
        }

        /// <summary>
        /// Создает папку, если она не существует.
        /// </summary>
        /// <param name="folderPath">Путь к папке.</param>
        internal static void CreateFolderIfNotExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Папка создана: {folderPath}");
            }
        }
    }
}