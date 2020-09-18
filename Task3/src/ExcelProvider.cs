using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace Task3
{
  /// <summary>
  /// Инкапсулирует и абстрагирует работу с Excel-файлами.
  /// </summary>
  internal sealed class ExcelProvider<T>
  {
    #region Поля и свойства

    /// <summary>
    /// Полное имя excel-файла.
    /// </summary>
    private readonly string fullPath;

    /// <summary>
    /// Парсер.
    /// </summary>
    private readonly IParser<T> parser;

    #endregion

    #region Методы

    /// <summary>
    /// Читает данные из excel-файла.
    /// </summary>
    /// <returns>Последовательность объектов типа T.</returns>
    public IEnumerable<T> Read()
    {
      Excel.Application? app = null;

      try
      {
        app = new Excel.Application();
        Excel.Workbook book = app.Workbooks.Open(this.fullPath);
        var worksheet = (Excel.Worksheet)book.Sheets[1];
        Excel.Range range = worksheet.UsedRange;

        IEnumerable<T> ret = this.Read(range);

        foreach (var item in ret)
          yield return item;
      }
      finally
      {
        app?.Quit();
      }
    }

    /// <summary>
    /// Читает данные из excel-файла.
    /// </summary>
    /// <param name="range">Диапазон, заполненный данными.</param>
    /// <returns>Последовательность объектов типа T.</returns>
    private IEnumerable<T> Read(Excel.Range range)
    {
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

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="fullPath">Полное имя excel-файла.</param>
    /// <param name="parser">Конвертер в объект типа T.</param>
    public ExcelProvider(string fullPath, IParser<T> parser)
    {
      this.fullPath = fullPath;
      this.parser = parser;
    }

    #endregion
  }
}
