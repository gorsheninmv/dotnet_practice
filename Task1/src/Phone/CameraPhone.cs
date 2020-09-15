using System;

namespace Task1.Phone
{
  /// <summary>
  /// 3G телефон с фотокамерой.
  /// </summary>
  internal class CameraPhone : Mobile3GPhone
  {
    /// <summary>
    /// Модуль камеры.
    /// </summary>
    private PhotoCamera camera;

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
    
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">IMEI.</param>
    public CameraPhone(string imei) : base(imei)
    {
      this.camera = new PhotoCamera();
      this.camera.PhotoTaken += this.PhotoTakenHandler;
    }
  }
}