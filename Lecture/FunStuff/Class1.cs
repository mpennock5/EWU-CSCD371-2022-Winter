namespace FunStuff;
public class Thing1
{
    public string Name { get; set; } = "Princess Buttercup";
    public string GetName() => Name;
    public string ConcatName(string firstName, string lastName) =>
        $"{firstName} {lastName} known as {Name}";
    public int Age { get; set; } = 0;
}

public record class Thing2(string Name, decimal Size)
{
    public void Method()
    {
        //this.Deconstruct(Name)
        //(string name, decimal size) = this;
        (string name, decimal size, string name2) = this;
        Console.WriteLine($"Name: {name} is {size}");

        string text = this switch
        {
            ("Inigo Montoya", <41 or 43) => "Fred Flintstone",
            ("Inigo Montoya", 42) => "Jackpot!",
            (string myName, decimal mySize) => myName,
            (string myName, decimal mySize, string myName2) => myName2,
            _ => string.Empty
        };

        Console.WriteLine(text);
    }

    public void Deconstruct(out string name, out decimal size, out string name2)
    {
        (name, size, name2) = (Name, Size, Name+"!");
    }


}

// Wasting time
public static class CsvLoader
{
    // "first", "last", age
    public static IEnumerable<T> Load<T>(string csvContent) where T : new()
    {
        var result = new List<T>();
        var lines = csvContent.Split(Environment.NewLine);
        var header = lines.First().Split(",");

        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(',');
            T item = new T();
            result.Add(item);
            for (int i = 0; i < parts.Length; i++)
            {
                var propertyInfo = typeof(T).GetProperty(header[i]);
                if (propertyInfo is not null)
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        propertyInfo.SetValue(item, parts[i], null);
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        propertyInfo.SetValue(item, int.Parse(parts[i]), null);
                    }
                }
            }
        }
        return result;
    }
}
