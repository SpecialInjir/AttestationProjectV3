using FirstTask.Enums;
using FirstTask.Models.Phones.Base;

namespace FirstTask.Models.Phones
{
    /// <summary>
    /// Класс телефон с 3G.
    /// </summary>
    internal class Phone3G : PhoneBase
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Phone3G"/>.
        /// </summary>
        /// <param name="imei">IMEI телефона.</param>
        /// <param name="networkType">Тип сети.</param>
        internal Phone3G(string imei) : base(imei)
        {
            NetworkType = NetworkType.ThreeG;
        }
    }
}