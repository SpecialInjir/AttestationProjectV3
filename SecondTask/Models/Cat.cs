using SecondTask.Models.Base;

namespace SecondTask.Models
{
    /// <summary>
    /// Подкласс для кошек.
    /// </summary>
    internal class Cat : Animal
    {
        /// <summary>
        /// Цвет кошки.
        /// </summary>
        internal required string Color { get; set; }
    }
}
