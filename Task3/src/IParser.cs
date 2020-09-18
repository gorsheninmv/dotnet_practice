namespace Task3
{
  /// <summary>
  /// Стартегия создания объекта из строкового представления этого объекта.
  /// </summary>
  /// <typeparam name="T">Тип объекта, в который происходит преобразование.</typeparam>
  internal interface IParser<T>
  {
    /// <summary>
    /// Попытаться преобразовать в объект из строкового представления его полей.
    /// </summary>
    /// <param name="contents">Последовательность строк, описывающая объект типа T.</param>
    /// <param name="result">Объект типа T.</param>
    /// <returns>Успешно ли преобразование.</returns>
    bool TryParse(string[] contents, out T result);
  }
}
