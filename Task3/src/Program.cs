﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3
{
  /// <summary>
  /// Класс точки входа в программу.
  /// </summary>
  internal static class Program
  {
    #region Константы.

    /// <summary>
    /// Код ошибки при выходе программы.
    /// </summary>
    private const int ErrorExitCode = 1;

    #endregion

    #region Поля и свойства.

    /// <summary>
    /// Полное имя файла с входными данными.
    /// </summary>
    private static readonly string inFileFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "in.xlsx");

    /// <summary>
    /// Полное имя файла с выходными данными.
    /// </summary>
    private static readonly string outFileFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out.txt");

    #endregion

    #region Методы.

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns></returns>
    static int Main(string[] args)
    {
      using var excelProvider = new ExcelProvider(inFileFullPath);

      IEnumerable<Product> pickedProducts = excelProvider.Read()
        .Select(row =>
          {
            bool isOk = ExcelStringToProductConverter.Convert(row, out Product product);
            return new {isOk, product};
          })
        .Where(exProduct => exProduct.isOk && exProduct.product.Price > 2000m)
        .Select(tuple => tuple.product)
        .OrderBy(product => product.Name);

      try
      {
        WriteToFile(pickedProducts, outFileFullPath);
      }
      catch (Exception e)
      {
        Console.WriteLine("IO Error.");
        Console.WriteLine(e);
        return ErrorExitCode;
      }

      return 0;
    }

    /// <summary>
    /// Записывает в выходной файл.
    /// </summary>
    /// <param name="products">Товары.</param>
    /// <param name="fullPath">Полное имя файла для записи.</param>
    private static void WriteToFile(IEnumerable<Product> products, string fullPath)
    {
      using var writer = new StreamWriter(new FileStream(fullPath, FileMode.Create));

      foreach (var product in products)
      {
        var line = $"{product.Name};\t{product.Price:F}";
        writer.WriteLine(line);
      }
    }

    #endregion
  }
}