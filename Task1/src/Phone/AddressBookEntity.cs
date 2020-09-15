using System;

namespace Task1.Phone
{
  /// <summary>
  /// Элемент адресной книги.
  /// </summary>
  internal class AddressBookEntity
  {
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

    /// <summary>
    /// Конструктор.
    /// </summary>
    public AddressBookEntity()
    {
      FirstName = LastName = Surname = PhoneNumber = String.Empty;
    }
  }
}