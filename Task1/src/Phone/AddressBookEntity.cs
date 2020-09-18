namespace Task1.Phone
{
  /// <summary>
  /// Элемент адресной книги.
  /// </summary>
  internal class AddressBookEntity
  {
    #region Поля и свойства

    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия абонента.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество абонента.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Номер телефона абонента.
    /// </summary>
    public string PhoneNumber { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="surname">Отчество.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    public AddressBookEntity(string firstName, string lastName, string surname, string phoneNumber)
    {
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Surname = surname;
      this.PhoneNumber = phoneNumber;
    }

    #endregion
  }
}
