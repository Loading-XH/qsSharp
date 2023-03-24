using System;
using System.Reflection;
using System.Text;

namespace QueryString
{
    public class QS
    {
        public string Stringify<T>(T source)
        {
            Type type =source.GetType();
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb=new StringBuilder();
            Console.WriteLine($"共有{props.Length}个变量");
            for (int i = 0; i < props.Length; i++)
            {
                sb.Append($"{props[i].Name} = {props[i].GetValue(source)}&");
                Console.WriteLine($"{props[i].PropertyType.Name} {props[i].Name}");
            }
            return sb.ToString();
        }

        public T Parse<T>(string query) where T : new()
        {
            return new T();
        }
    }
}
