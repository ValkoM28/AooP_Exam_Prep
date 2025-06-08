## ➜ Unit Testing in C#

### ➜ Why Unit Testing?
- Validates the smallest units of code (e.g., methods).
- Helps detect regressions early.
- Promotes maintainable, modular design.

---

### ➜ Installing xUnit

You can install **xUnit** via NuGet:

```bash
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package Microsoft.NET.Test.Sdk
```

To create a test project:

```bash
dotnet new xunit -n MyApp.Tests
```

Add a reference to the project under test:

```bash
dotnet add MyApp.Tests reference ../MyApp/MyApp.csproj
```

---

### ➜ Basic xUnit Test Example

```csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;
}
```

```csharp
public class CalculatorTests
{
    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        var calc = new Calculator();
        int result = calc.Add(2, 3);
        Assert.Equal(5, result);
    }
}
```

---

### ➜ Test Structure Guidelines

Use the **AAA pattern**:  
**Arrange** → **Act** → **Assert**

```csharp
// Arrange
var service = new AuthService();

// Act
bool result = service.Login("admin", "password");

// Assert
Assert.True(result);
```

---

### ➜ Common States to Test

| Category           | Example                                             |
|--------------------|-----------------------------------------------------|
| **Happy Path**      | Valid inputs return correct results                 |
| **Edge Cases**      | Empty strings, zero, max/min values, nulls          |
| **Invalid Input**   | Exceptions or error messages when inputs are wrong |
| **State Changes**   | Internal state updates as expected                  |
| **Side Effects**    | File write, log entry, DB call is made              |
| **Boundary Values** | Just inside/outside input limits                   |

---

### ➜ Parameterized Tests (`[Theory]`)

Use `[Theory]` + `[InlineData]` to run tests with multiple inputs.

```csharp
public class MathTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    public void Add_WorksForMultipleInputs(int a, int b, int expected)
    {
        var calc = new Calculator();
        int result = calc.Add(a, b);
        Assert.Equal(expected, result);
    }
}
```

---

### ➜ Testing ViewModels (MVVM Example)

You can test Avalonia ViewModels like any other class:

```csharp
public class MainViewModel
{
    public string Name { get; set; }

    public string Greet() => $"Hello, {Name}!";
}
```

```csharp
public class MainViewModelTests
{
    [Fact]
    public void Greet_ReturnsCorrectGreeting()
    {
        var vm = new MainViewModel { Name = "Alice" };
        var greeting = vm.Greet();
        Assert.Equal("Hello, Alice!", greeting);
    }
}
```

---

### ➜ Mocking Dependencies (with Moq)

Install **Moq** for mocking services:

```bash
dotnet add package Moq
```

Example with dependency injection:

```csharp
public interface IDataService {
    Task<string> LoadDataAsync();
}

public class MyViewModel {
    private readonly IDataService _dataService;
    public MyViewModel(IDataService dataService) => _dataService = dataService;

    public async Task<string> Load() => await _dataService.LoadDataAsync();
}
```

```csharp
public class MyViewModelTests
{
    [Fact]
    public async Task Load_ReturnsMockedData()
    {
        var mock = new Mock<IDataService>();
        mock.Setup(s => s.LoadDataAsync()).ReturnsAsync("Mocked");

        var vm = new MyViewModel(mock.Object);
        var result = await vm.Load();

        Assert.Equal("Mocked", result);
    }
}
```

---

### ➜ Tips for Effective Unit Testing
- Keep tests **fast**, **isolated**, and **repeatable**.
- Avoid testing external systems (use mocks/fakes).
- Prefer testing **public API**, not private methods.
- Use **code coverage** tools (like `coverlet`) to identify untested paths.

---

Let me know if you want to include:
- Integration testing with `WebApplicationFactory`
- Code coverage with `coverlet`
- Running tests in CI (GitHub Actions or Azure DevOps)
