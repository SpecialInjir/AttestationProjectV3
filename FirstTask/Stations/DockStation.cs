using FirstTask.Interfaces;

namespace FirstTask.Stations
{
    /// <summary>
    /// Класс "Базовая станция".
    /// </summary>
    internal class DockStation
    {
        /// <summary>
        /// Список зарегистрированных телефонов.
        /// </summary>
        protected List<ICallable> Phones = [];

        /// <summary>
        /// Регистрирует телефон на станции.
        /// </summary>
        /// <param name="phone">Телефон для регистрации.</param>
        public virtual void Register(ICallable phone)
        {
            if (!Phones.Contains(phone))
            {
                Phones.Add(phone);
                phone.Called += DataProcessing;
                Console.WriteLine("Телефон зарегистрирован.");
            }
        }

        /// <summary>
        /// Обрабатывает исходящие вызовы.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        internal void DataProcessing(object sender, EventArgs e)
        {
            Console.WriteLine("Обработка исходящего вызова.");
        }
    }
}