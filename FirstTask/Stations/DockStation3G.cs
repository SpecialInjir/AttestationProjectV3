using FirstTask.Interfaces;
using FirstTask.Models.Phones;

namespace FirstTask.Stations
{
    /// <summary>
    /// Класс "Базовая станция с 3G".
    /// </summary>
    internal class DockStation3G : DockStation
    {
        /// <inheritdoc />
        internal override void Register(ICallable phone)
        {
            if (phone is Phone3G)
            {
                base.Register(phone);
                Console.WriteLine("3G телефон зарегистрирован.");
            }
            else
            {
                Console.WriteLine("Только 3G телефоны могут быть зарегистрированы на этой станции.");
            }
        }
    }
}