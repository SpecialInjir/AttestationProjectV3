using FirstTask.Enums;
using FirstTask.Interfaces;

namespace FirstTask.Models.Phones.Base
{
    /// <summary>
    /// Абстрактный базовый класс для телефонов.
    /// </summary>
    internal abstract class PhoneBase : ICallable
    {
        /// <summary>
        /// IMEI телефона.
        /// </summary>
        public string Imei { get; }

        /// <summary>
        /// Тип сети телефона.
        /// </summary>
        public NetworkType NetworkType { get; protected set; }

        /// <summary>
        /// Список контактов.
        /// </summary>
        private readonly List<Contact> _contacts = new();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PhoneBase"/>.
        /// </summary>
        /// <param name="imei">IMEI телефона.</param>
        protected PhoneBase(string imei)
        {
            Imei = imei;
        }

        /// <summary>
        /// Добавляет контакт в справочник.
        /// </summary>
        /// <param name="contact">Контакт для добавления.</param>
        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        /// <summary>
        /// Осуществляет звонок по номеру телефона.
        /// </summary>
        /// <param name="number">Номер телефона.</param>
        public void Call(string number)
        {
            Console.WriteLine($"Звонок по номеру: {number} (Сеть: {NetworkType})");
            Called?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc />
        public event EventHandler Called;
    }
}