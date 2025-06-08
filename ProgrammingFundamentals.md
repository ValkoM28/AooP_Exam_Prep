
# 💻 Programming Fundamentals in C#

## 🧾 Classes, Constructors & Object Initializers

### Classes
- Blueprint for creating objects.
- Contain fields, properties, methods, and events.

### Constructors
- Special methods invoked when an object is created.
- Can be overloaded.

```csharp
class Person {
    public string Name;
    public Person(string name) {
        Name = name;
    }
}
```

### Object Initializers
- Provide a shortcut for initializing objects.

```csharp
var person = new Person { Name = "Alice" };
```

## 🏠 Properties
- Encapsulate fields and provide get/set accessors.

```csharp
public string Name { get; set; }
```

## 🔌 Interfaces
- Define a contract that implementing classes must fulfill.
- Cannot contain implementation.

```csharp
interface IAnimal {
    void Speak();
}
```

## 📚 Collections
- Used to store groups of related objects.

### Common Types:
- `List<T>`
- `Dictionary<TKey, TValue>`
- `Queue<T>`, `Stack<T>`

```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
```

## 🔍 LINQ + Lambda Expressions

### LINQ (Language Integrated Query)
- Provides query capabilities directly in C#.

```csharp
var result = numbers.Where(n => n > 1).ToList();
```

### Lambda Expressions
- Anonymous functions for inline use.

```csharp
Func<int, int> square = x => x * x;
```

## 🧱 Object, ToString, IComparable

### `Object`
- Base class for all types.

### `ToString()`
- Converts an object to its string representation.

```csharp
public override string ToString() => $"Person: {Name}";
```

### `IComparable`
- Allows custom comparison logic for sorting.

```csharp
public int CompareTo(object obj) {
    return this.Age.CompareTo(((Person)obj).Age);
}
```

## 📂 File Handling (Read & Write)

### Reading a File
```csharp
string content = File.ReadAllText("file.txt");
```

### Writing to a File
```csharp
File.WriteAllText("file.txt", "Hello World");
```

## 🔄 Parsing JSON and CSV

### JSON (using `System.Text.Json`)
```csharp
var person = JsonSerializer.Deserialize<Person>(jsonString);
```

### CSV (using CSVHelper)
```csharp
using (var reader = new StreamReader("file.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
    var records = csv.GetRecords<Person>().ToList();
}
```

## 🚨 Exception Handling

### Try-Catch Block
```csharp
try {
    // risky code
} catch (Exception ex) {
    Console.WriteLine(ex.Message);
}
```

### Finally Block
- Executes whether or not an exception is thrown.

```csharp
finally {
    // cleanup code
}
```
