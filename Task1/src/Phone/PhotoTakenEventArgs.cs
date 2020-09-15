﻿using System;

namespace Task1.Phone
{
  /// <summary>
  /// Аргумент события о том, что сделана фотография.
  /// </summary>
  internal sealed class PhotoTakenEventArgs : EventArgs
  {
    /// <summary>
    /// Сырые данные с фотокамеры.
    /// </summary>
    public byte[] RawPhoto { get; }

    /// <summary>
    /// Конструктор аргумента события.
    /// </summary>
    /// <param name="rawPhoto">Сырые данные с фотокамеры.</param>
    public PhotoTakenEventArgs(byte[] rawPhoto)
    {
      this.RawPhoto = rawPhoto;
    }
  }
}