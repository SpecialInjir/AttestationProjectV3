using ThirdTask.Models;

namespace ThirdTask.Filters
{
    /// <summary>
    /// Класс для фильтрации и сортировки товаров.
    /// </summary>
    internal static class ProductFilter
    {
        internal static IEnumerable<Product> FilterAndSortProducts(IEnumerable<Product> products, decimal maxPrice)
        {
            return products
                .Where(p => p.Price < maxPrice)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
