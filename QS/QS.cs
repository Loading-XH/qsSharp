using System;
using System.Reflection;

namespace QueryString
{
    public class QS
    {
        public string Stringify<T>(T source)
        {
            Type type = Assembly.GetExecutingAssembly().GetType(nameof(source));
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            Console.WriteLine($"共有{fields.Length}个变量");
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine($"{fields[i].FieldType.Name} {fields[i].Name}");
            }
            return "";
        }

        public T Parse<T>(string query) where T : new()
        {
            return new T();
        }
    }
}
