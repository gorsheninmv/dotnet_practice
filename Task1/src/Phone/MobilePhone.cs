using System;
using System.Collections.Generic;

namespace Task1.Phone
{
  /// <summary>
  /// Мобильный телефон.
  /// </summary>
  internal class MobilePhone
  {
    #region Поля и свойства.

    /// <summary>
    /// IMEI телефона.
    /// </summary>
    public string Imei { get; }

    /// <summary>
    /// Абонентский номер.
    /// </summary>
    public string SimNumber { get; set; }

    /// <summary>
    /// Адресная книга.
    /// </summary>
    public List<AddressBookEntity> AddressBook { get; }

    #endregion

    #region Методы.

    /// <summary>
    /// Подключиться к сети.
    /// </summary>
    public void Connect()
    {
      this.EstablishConnection();
    }

    /// <summary>
    /// Позвонить абоненту.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <returns>Удалось ли дозвониться.</returns>
    public bool Call(string phoneNumber)
    {
      Console.WriteLine($"Call by using {phoneNumber} number");
      this.Call();
      return true;
    }

    /// <summary>
    /// Позвонить абоненту.
    /// </summary>
    /// <param name="entity">Элемент адресной книги.</param>
    /// <returns>Удалось ли дозвониться.</returns>
    public bool Call(AddressBookEntity entity)
    {
      Console.WriteLine($"Call to '{entity.FirstName} {entity.Surname} {entity.LastName}'");
      this.Call();
      return true;
    }

    /// <summary>
    /// Установить соединение.
    /// </summary>
    protected virtual void EstablishConnection()
    {
      Console.WriteLine("GSM connection established");
    }

    /// <summary>
    /// Реализует общую функциональность звонка.
    /// </summary>
    private void Call()
    {
      Console.WriteLine("Call accepted");
    }

    #endregion

    #region Конструкторы.

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">IMEI</param>
    public MobilePhone(string imei)
    {
      this.Imei = imei;
      this.AddressBook = new List<AddressBookEntity>();
      this.SimNumber = String.Empty;
    }

    #endregion
  }
}