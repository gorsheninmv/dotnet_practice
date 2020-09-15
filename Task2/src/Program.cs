using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    static void Main(string[] args)
    {
      var dllName = "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
      Assembly winFormsAssembly = Assembly.Load(dllName);
      Type[] winFormsTypes = winFormsAssembly.GetTypes();

      IEnumerable<MethodInfo> methodsMetadataToWrite = winFormsTypes.GetMethodsMetadata(BindingFlags.Public |
       BindingFlags.Instance | BindingFlags.DeclaredOnly);

      string fullPathToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, "MethodInfos.txt");
      WriteMethodsMetadataToFile(fullPathToFile, methodsMetadataToWrite);

      MethodInfo? showMethodMetaData = winFormsTypes.GetMethodsMetadata(BindingFlags.Public | BindingFlags.Static)
        .TryFindShowMessageBoxMethod();

      showMethodMetaData?.Invoke(null, new []{"Some Info"});
    }

    /// <summary>
    /// Возвращает метаданные методов.
    /// </summary>
    /// <param name="source">Типы, в которых производится поиск.</param>
    /// <param name="flags">Флаги, которым должен соответствовать искомый метод.</param>
    /// <returns>Метаданные методов, удовлетворяющих <param name="flags"/>.</returns>
    private static IEnumerable<MethodInfo> GetMethodsMetadata(this IEnumerable<Type> source, BindingFlags flags)
    {
      return source.SelectMany(type => type.GetMethods(flags));
    }

    /// <summary>
    /// Выполняет поиск метаданных метода в типе MessageBox с именем Show с одним аргументом.
    /// </summary>
    /// <param name="methodInfos">Метаданные методов, в которых производится поиск.</param>
    /// <returns>Метаданные найденного метода. Если метод не найден - то null.</returns>
    private static MethodInfo? TryFindShowMessageBoxMethod(this IEnumerable<MethodInfo> methodInfos)
    {
      return methodInfos.FirstOrDefault(methodInfo => methodInfo.DeclaringType?.Name == "MessageBox" &&
       methodInfo.Name == "Show" && methodInfo.GetParameters().Length == 1);
    }

    /// <summary>
    /// Записывает в файл метаданные методов.
    /// </summary>
    /// <param name="fullPath">Полное имя файла.</param>
    /// <param name="methodInfos">Последовательность метаданных методов.</param>
    private static void WriteMethodsMetadataToFile(string fullPath, IEnumerable<MethodInfo> methodInfos)
    {
      using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
      using var writer = new StreamWriter(stream);

      foreach (var methodInfo in methodInfos)
      {
        writer.WriteLine($"{methodInfo.DeclaringType?.FullName}: {methodInfo.Name}");
      }
    }
  }
}