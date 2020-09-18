using System;

namespace Task1.Phone
{
  /// <summary>
  /// 3G телефон с фотокамерой.
  /// </summary>
  internal class MobilePhoneWithCamera : Mobile3GPhone
  {
    #region Поля и свойства

    /// <summary>
    /// Модуль камеры.
    /// </summary>
    private readonly PhotoCamera camera;

    #endregion

    #region Методы

    /// <summary>
    /// Сделать фотографию.
    /// </summary>
    public void TakePhoto()
    {
      this.camera.Shot();
    }

    private void PhotoTakenHandler(object? sender, PhotoTakenEventArgs e)
    {
      Console.WriteLine("Photo received from camera");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">IMEI.</param>
    public MobilePhoneWithCamera(string imei) : base(imei)
    {
      this.camera = new PhotoCamera();
      this.camera.PhotoTaken += this.PhotoTakenHandler;
    }

    #endregion
  }
}
