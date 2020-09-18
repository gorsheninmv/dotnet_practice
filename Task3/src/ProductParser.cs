using System.Globalization;

namespace Task3
{
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

        bool parsed = decimal.TryParse(contents[1], NumberStyles.Any, cultureInfo, out decimal price);

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
