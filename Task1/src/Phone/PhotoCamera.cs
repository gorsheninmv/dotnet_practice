using System;

namespace Task1.Phone
{
  /// <summary>
  /// Модуль фотокамеры.
  /// </summary>
  internal sealed class PhotoCamera
  {
    /// <summary>
    /// Сделать фотографию.
    /// </summary>
    public void Shot()
    {
      this.OnPhotoTaken(new byte[0]);      
    }
    
    /// <summary>
    /// Событие, сигнализирующее о том, что сделана новая фотография.
    /// </summary>
    public EventHandler<PhotoTakenEventArgs>? PhotoTaken;

    private void OnPhotoTaken(byte[] rawPhoto)
    {
      this.PhotoTaken?.Invoke(this, new PhotoTakenEventArgs(rawPhoto));
    }
  }
}