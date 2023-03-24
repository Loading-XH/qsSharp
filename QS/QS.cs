using System;
using System.Reflection;
using System.Text;

namespace QueryString
{
    public class QS
    {
        public string Stringify<T>(T source)
        {
            Type type = source.GetType();
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < props.Length; i++)
            {
                sb.Append($"{props[i].Name}={props[i].GetValue(source)}");
                if (i != props.Length - 1)
                    sb.Append("&");
            }
            return sb.ToString();
        }

        public T Parse<T>(string query) where T : new()
        {
            return new T();
        }
    }
}
