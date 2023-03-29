## Implementation of converting an object to a QueryString in C#

Reference to  `<a href="https://github.com/ljharb/qs">`qs.js `</a>`

### Example：

```C#
var o = new
{
    IDCardNumber = "idcard",
    Name = "name",
    Array = new[] { 0, 1 },
    Dict = new Dictionary<string, object>
    {
        {"k","v"}
    }
};

var result = QS.Stringify(o);

//idcardNumber=idcard&name=name&array[0]=0&array[1]=1&dict[k]=v
```
