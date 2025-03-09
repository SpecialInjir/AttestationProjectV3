namespace FirstTask.Handlers
{
    /// <summary>
    /// Обработчик вызовов.
    /// </summary>
    internal class CallHandler
    {
        /// <summary>
        /// Обрабатывает событие вызова.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        internal void HandleCall(object sender, EventArgs e)
        {
            Console.WriteLine("Обработка вызова...");
        }
    }
}
