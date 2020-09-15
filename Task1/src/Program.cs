﻿using System;
using System.Collections.Generic;
using Task1.Phone;

namespace Task1
{
  /// <summary>
  /// Класс точки входа в программу.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// Добавить людей в контакты.
    /// </summary>
    /// <param name="addressBook">Адресная книга.</param>
    private static void AddPeopleToAddressBook(List<AddressBookEntity> addressBook)
    {
      var entity = new AddressBookEntity
      {
        FirstName = "Ivan",
        Surname = "Ivanovich",
        LastName = "Petrov",
        PhoneNumber = "1223456",
      };
      addressBook.Add(entity);

      entity = new AddressBookEntity
      {
          FirstName = "Petr",
          Surname = "Petrovich",
          LastName = "Ivanov",
          PhoneNumber = "1223456",
      };
      addressBook.Add(entity);
    }

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    static void Main(string[] args)
    {
      var phones = new MobilePhone[]
      {
        new MobilePhone("E112C60B-5177-4FE3-A04E-899A20DE006E") {SimNumber = "1234567"},
        new Mobile3GPhone("AA6DFD33-6FE8-4290-B3F3-D29D5C81ABA7") {SimNumber = "423454365"},
        new CameraPhone("04954D21-5AAE-46D0-AB65-6B0225963BCC") {SimNumber = "856954654"},
      };

      foreach (var phone in phones)
      {
        AddPeopleToAddressBook(phone.AddressBook);
      }

      foreach (var phone in phones)
      {
        phone.Connect();
        phone.Call(phone.AddressBook[0]);
        phone.Call("42395454359");

        Console.WriteLine(new String('=', 10));
      }

      var cameraPhone = phones[0] as CameraPhone;
      cameraPhone?.TakePhoto();
    }
  }
}