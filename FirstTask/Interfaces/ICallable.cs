namespace FirstTask.Interfaces
{
    /// <summary>
    /// Интерфейс осуществляющий звонок.
    /// </summary>
    internal interface ICallable
    {
        /// <summary>
        /// Событие вызова.
        /// </summary>
        internal event EventHandler Called;
    }
}
