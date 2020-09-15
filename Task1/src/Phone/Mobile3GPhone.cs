using System;

namespace Task1.Phone
{
  /// <summary>
  /// Мобильный телефон, который поддерживает 3G.
  /// </summary>
  internal class Mobile3GPhone : MobilePhone
  {
    protected override void EstablishConnection()
    {
      Console.WriteLine("3G connection established");
    }
    
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">IMEI.</param>
    public Mobile3GPhone(string imei) : base (imei) { }
  }
}