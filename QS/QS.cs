using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueryString;
public class QS
{
    private static readonly Regex _regex = new Regex(@"(^[A-Z]*)", RegexOptions.Compiled);

    public static string Stringify(object o)
    {
        var enumerable = BuildQueryStringParams(o, null);

        return string.Join('&', enumerable);
    }

    private static IEnumerable<string> BuildQueryStringParams(object? o, string? prefix)
    {
        if (o is null)
            yield break;

        switch (o)
        {
            case IFormattable:
            case string:
                yield return $"{prefix}={o}";
                break;


            case IDictionary d:
                foreach (DictionaryEntry item in d)
                {
                    var key = item.Key?.ToString() ?? string.Empty;
                    var value = item.Value;
                    var p = prefix is null ? key : $"{prefix}[{key}]";

                    foreach (var i in BuildQueryStringParams(value, p))
                    {
                        yield return i;
                    }
                }
                break;

            case IEnumerable e:
                var index = 0;
                foreach (var item in e)
                {
                    var p = $"{prefix}[{index}]";
                    foreach (var i in BuildQueryStringParams(item, p))
                    {
                        yield return i;
                    }
                    index++;
                }
                break;

            default:
                var dic = o.GetType()
                .GetProperties()
                .ToDictionary(prop => lowerCamelCase(prop.Name), prop => prop.GetValue(o, null));

                foreach (var item in dic)
                {
                    var p = prefix is null ? item.Key : $"{prefix}[{item.Key}]";

                    foreach (var i in BuildQueryStringParams(item.Value, p))
                    {
                        yield return i;
                    }
                }

                break;
        }
    }


    private static string lowerCamelCase(string input)
    {
        return _regex.Replace(input, m => m.Groups[1].Value.ToLower());
    }


}
