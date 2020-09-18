using System.Globalization;

namespace Task3
{
  /// <summary>
  /// Товар.
  /// </summary>
  internal struct Product
  {
    /// <summary>
    /// Наименование товара.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Цена товара.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Наименование товара.</param>
    /// <param name="price">Цена товара.</param>
    public Product(string name, decimal price)
    {
      this.Name = name;
      this.Price = price;
    }
  }

  /// <summary>
  /// Парсер товара.
  /// </summary>
  internal class ProductParser : IParser<Product>
  {
    public bool TryParse(string[] contents, out Product result)
    {
      if (contents.Length == 2)
      {
        string name = contents[0];
        var cultureInfo = new CultureInfo("ru-RU");

        bool parsed = decimal.TryParse(contents[1], NumberStyles.Any, cultureInfo,
          out decimal price);

        if (parsed)
        {
          result = new Product(name, price);
          return true;
        }
      }

      result = new Product(string.Empty, 0m);
      return false;
    }
  }
}
