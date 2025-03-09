using FirstTask.Enums;
using FirstTask.Models.Phones.Base;

namespace FirstTask.Models.Phones
{
    /// <summary>
    /// Класс дефолтный телефон.
    /// </summary>
    internal class Phone : PhoneBase
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Phone"/>.
        /// </summary>
        /// <param name="imei">IMEI телефона.</param>
        internal Phone(string imei) : base(imei)
        {
            NetworkType = NetworkType.Default;
        }
    }
}