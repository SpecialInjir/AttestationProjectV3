namespace ThirdTask.Models
{
    /// <summary>
    /// Структура, представляющая товар.
    /// </summary>
    internal struct Product
    {
        /// <summary>
        /// Наименование товара.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// Цена товара.
        /// </summary>
        internal decimal Price { get; }

        /// <summary> 
        /// Конструктор. 
        /// </summary> 
        /// <param name="name">Название.</param> 
        /// <param name="price">Цена.</param> 
        internal Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
