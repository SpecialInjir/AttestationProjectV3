namespace FirstTask.Models
{
    /// <summary>
    /// Класс "Контакт".
    /// </summary>
    internal sealed class Contact
    {
        /// <summary>
        /// Имя контакта.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        internal string Number { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="number">Номер телефона.</param>
        internal Contact(string name, string number)
        {
            this.Name = name;
            this.Number = number;
        }
    }
}