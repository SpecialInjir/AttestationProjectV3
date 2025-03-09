using SecondTask.Models.Base;

namespace SecondTask.Models
{
    /// <summary>
    /// Подкласс для собак.
    /// </summary>
    internal sealed class Dog : Animal
    {
        /// <summary>
        /// Порода собаки.
        /// </summary>
        internal required string Breed { get; set; }
    }
}