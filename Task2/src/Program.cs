using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Task2
{
  /// <summary>
  /// Класс точки входа в программу.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    private static void Main(string[] args)
    {
      var assemblyName = "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
      Assembly winFormsAssembly = Assembly.Load(assemblyName);

      var typeName = "System.Windows.Forms.MessageBox";
      Type? messageBox = winFormsAssembly.GetType(typeName);

      string? baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

      if (baseDirectory == null)
        throw new Exception("Base diretory not specified.");

      string fullPathToFile = Path.Combine(baseDirectory, "MethodsInfo.txt");

      if (messageBox != null)
      {
        IEnumerable<MethodInfo> messageBoxMethodsToWrite = messageBox.GetMethods(BindingFlags.Public |
          BindingFlags.Instance);

        WriteMethodsMetadataToFile(fullPathToFile, messageBoxMethodsToWrite);

        MethodInfo? messageBoxShowMethod = messageBox.GetMethod("Show", BindingFlags.Static | BindingFlags.Public,
          Type.DefaultBinder, new[] { typeof(string) }, new ParameterModifier[0]);

        messageBoxShowMethod?.Invoke(null, new[] { "Some Info" });
      }
      else
      {
        throw new Exception($"Type '{typeName}' not found.");
      }
    }

    /// <summary>
    /// Записывает в файл метаданные методов.
    /// </summary>
    /// <param name="fullPath">Полное имя файла.</param>
    /// <param name="methodsInfo">Последовательность метаданных методов.</param>
    private static void WriteMethodsMetadataToFile(string fullPath, IEnumerable<MethodInfo> methodsInfo)
    {
      using (var writer = new StreamWriter(fullPath, append: false))
      {
        foreach (var methodInfo in methodsInfo)
          writer.WriteLine($"{methodInfo.DeclaringType?.FullName}: {methodInfo.Name}");
      }
    }
  }
}
