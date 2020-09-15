using System;
using System.Globalization;

namespace Task3
{
  /// <summary>
  /// Конвертер из строки в Product.
  /// </summary>
  internal static class ExcelStringToProductConverter
  {
    /// <summary>
    /// Преобразовать в объект типа Product.
    /// </summary>
    /// <param name="strRepr">Строковое представление объекта.</param>
    /// <param name="product">Объект типа Product.</param>
    /// <returns>Флаг успешности преобразования.</returns>
    /// На вход ожидается строка вида "Наименование;цена"
    public static bool Convert(string strRepr, out Product product)
    {
      var delim = ';';
      string[] productArray = strRepr.Split(delim);

      if (productArray.Length == 2)
      {
        string name = productArray[0];
        var cultureInfo = new CultureInfo("ru-RU");

        bool parsed = Decimal.TryParse(productArray[1], NumberStyles.Any, cultureInfo,
          out decimal price);

        if (parsed)
        {
          product = new Product(name, price);
          return true;
        }
      }

      product = new Product(String.Empty, 0m);
      return false;
    }
  }
}