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
