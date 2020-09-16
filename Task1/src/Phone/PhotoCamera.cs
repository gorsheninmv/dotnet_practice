using System;

namespace Task1.Phone
{
  /// <summary>
  /// Модуль фотокамеры.
  /// </summary>
  internal sealed class PhotoCamera
  {
    #region Методы

    /// <summary>
    /// Сделать фотографию.
    /// </summary>
    public void Shot()
    {
      this.OnPhotoTaken(new byte[0]);
    }

    #endregion

    #region Cобытия

    /// <summary>
    /// Событие, сигнализирующее о том, что сделана новая фотография.
    /// </summary>
    public event EventHandler<PhotoTakenEventArgs>? PhotoTaken;

    private void OnPhotoTaken(byte[] rawPhoto)
    {
      this.PhotoTaken?.Invoke(this, new PhotoTakenEventArgs(rawPhoto));
    }

    #endregion
  }
}