using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace Task3
{
  /// <summary>
  /// Инкапсулирует и абстрагирует работу с Excel-файлами.
  /// </summary>
  internal sealed class ExcelProvider<T> : IDisposable
  {
    #region Поля и свойства

    /// <summary>
    /// Полное имя excel-файла.
    /// </summary>
    private readonly string fullPath;

    /// <summary>
    /// Приложение Excel.
    /// </summary>
    private readonly Excel.Application excelApp;

    /// <summary>
    /// Книга Excel.
    /// </summary>
    private readonly Excel.Workbook workbook;

    /// <summary>
    /// Страница Excel.
    /// </summary>
    private readonly Excel.Worksheet worksheet;

    /// <summary>
    /// Диапазон ячеек с данными.
    /// </summary>
    private readonly Excel.Range range;

    /// <summary>
    /// Парсер.
    /// </summary>
    private readonly IParserStrategy<T> parser;

    /// <summary>
    /// Был ли вызван метод Dispose на объекте.
    /// </summary>
    private bool disposed;

    #endregion

    #region Методы

    /// <summary>
    /// Читает данные из excel-файла.
    /// </summary>
    /// <returns>Итератор по строкам.</returns>
    /// <remarks>Ячейка excel-файла отделяется точкой запятой в выходной строке.</remarks>>
    public IEnumerable<T> Read()
    {
      this.ThrowIfDisposed();

      if (!File.Exists(this.fullPath))
      {
        throw new FileNotFoundException("File not found.", this.fullPath);
      }

      int rowCount = range.Rows.Count;
      int colCount = range.Columns.Count;
      var contents = new string[colCount];

      for (var row = 1; row <= rowCount; ++row)
      {
        for (var col = 1; col <= colCount; ++col)
        {
          if (range.Cells[row, col] is Excel.Range cell)
          {
            contents[col - 1] = cell.Value2.ToString();
          }
        }

        bool parsed = this.parser.TryParse(contents, out T result);

        if (parsed)
          yield return result;
      }
    }

    /// <summary>
    /// Если объект уже освобожен, то бросить ObjectDisposedException.
    /// </summary>
    private void ThrowIfDisposed()
    {
      if (this.disposed)
        throw new ObjectDisposedException(nameof(ExcelProvider<T>));
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
      this.ThrowIfDisposed();
      this.disposed = true;

      if (this.range != null)
      {
        Marshal.ReleaseComObject(this.range);
      }

      if (this.worksheet != null)
      {
        Marshal.ReleaseComObject(this.worksheet);
      }

      if (this.workbook != null)
      {
        this.workbook.Close(0);
        Marshal.ReleaseComObject(this.workbook);
      }

      if (this.excelApp != null)
      {
        this.excelApp.Quit();
        Marshal.ReleaseComObject(this.excelApp);
      }

      GC.SuppressFinalize(this);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="fullPath">Полное имя excel-файла.</param>
    public ExcelProvider(string fullPath, IParserStrategy<T> parser)
    {
      this.fullPath = fullPath;
      this.parser = parser;

      this.excelApp = new Excel.Application();
      this.workbook = excelApp.Workbooks.Open(this.fullPath);
      this.worksheet = (Excel.Worksheet)workbook.Sheets[1];
      this.range = worksheet.UsedRange;
    }

    /// <summary>
    /// Деструктор.
    /// </summary>
    ~ExcelProvider()
    {
      this.Dispose();
    }

    #endregion
  }
}
