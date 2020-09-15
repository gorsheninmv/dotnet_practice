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
}