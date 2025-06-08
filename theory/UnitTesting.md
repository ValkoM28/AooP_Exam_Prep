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


## Other test examples (actually written by me :D rest of this document is ai)
tbh ai probably did the tests better than me
```csharp
    [Fact]
    public void Schedule_WithEmptyCollections_ReturnsEmptyProperties()
    {
        // Arrange
        var heatSchedules = new List<HeatProductionUnitSchedule>();
        var electricitySchedules = new List<ElectricityProductionUnitSchedule>();

        // Act
        var schedule = new Schedule(heatSchedules, electricitySchedules);

        // Assert
        Assert.Empty(schedule.HeatProductionUnitSchedules);
        Assert.Empty(schedule.ElectricityProductionUnitSchedules);
        Assert.Equal(0, schedule.Length);
        Assert.Equal(0, schedule.TotalCost);
        Assert.Equal(0, schedule.TotalEmissions);
        Assert.Equal(0, schedule.TotalHeatProduction);
        Assert.Empty(schedule.ElectricityPrice);
        Assert.Empty(schedule.ElectricityProduction);
        Assert.Empty(schedule.Costs);
        Assert.Empty(schedule.Emissions);
        Assert.Empty(schedule.HeatProduction);
        Assert.Empty(schedule.ResourceConsumption);
    }
```

```csharp
[Fact]
public void GetCostsByHour_ProperlyAggregatesCostsFromMultipleUnits()
{
    // Arrange
    var heatSchedule1 = CreateHeatSchedule("Unit1", _oil, new decimal[] { 100m, 200m }, new double[] { 25, 35 }, new double[] { 50, 75 });
    var heatSchedule2 = CreateHeatSchedule("Unit2", _oil, new decimal[] { 50m, 75m }, new double[] { 15, 20 }, new double[] { 30, 45 });

    var heatSchedules = new List<HeatProductionUnitSchedule> { heatSchedule1, heatSchedule2 };
    var electricitySchedules = new List<ElectricityProductionUnitSchedule>();

    // Act
    var schedule = new Schedule(heatSchedules, electricitySchedules);

    // Assert
    Assert.Equal(2, schedule.Costs.Length);
    Assert.Equal(150m, schedule.Costs[0]); // 100 + 50
    Assert.Equal(275m, schedule.Costs[1]); // 200 + 75
    Assert.Equal(425m, schedule.TotalCost); // 150 + 275
}
```

```csharp
    [Fact]
    public void Optimize_WithPriceOptimizationAndMultipleUnits_ProducesCorrectSchedule()
    {
        // Arrange
        var productionUnit1 = new HeatProductionUnit
        {
            Name = "Unit1",
            MaxHeatProduction = 50,
            Cost = 1,
            Emissions = 1,
            ResourceConsumption = 1,
            Resource = _oil
        };

        var productionUnit2 = new HeatProductionUnit
        {
            Name = "Unit2",
            MaxHeatProduction = 50,
            Cost = 2,
            Emissions = 1,
            ResourceConsumption = 1,
            Resource = _oil
        };

        var sourceDataPoint = new SourceDataPoint()
        {
            ElectricityPrice = 0,
            HeatDemand = 75,
            TimeFrom = DateTime.Now,
            TimeTo = DateTime.Now.AddHours(1)
        };

        var sourceDataCollection = new SourceDataCollection([sourceDataPoint]);

        _mockSourceDataProvider.Setup(p => p.SourceDataCollection).Returns(sourceDataCollection);
        _mockAssetManager.Setup(a => a.ProductionUnits).Returns(new ObservableCollection<ProductionUnitBase> { productionUnit1, productionUnit2 });
        _mockOptimizerSettings.Setup(s => s.GetActiveUnitsNames()).Returns(new List<string> { "Unit1", "Unit2" });
        _mockOptimizerStrategy.Setup(s => s.Optimization).Returns(OptimizationType.PriceOptimization);

        // Act
        var schedule = _optimizer.Optimize();

        // Assert
        Assert.NotNull(schedule);
        Assert.Equal(2, schedule.HeatProductionUnitSchedules.Count());
        
        var unit1Schedule = schedule.HeatProductionUnitSchedules.First(s => s.Name == "Unit1");
        var unit2Schedule = schedule.HeatProductionUnitSchedules.First(s => s.Name == "Unit2");
        
        // Unit1 should be fully utilized (50/50) because it's cheaper
        Assert.Single(unit1Schedule.DataPoints);
        Assert.Equal(1.0, unit1Schedule.DataPoints[0].Utilization);
        Assert.Equal(50, unit1Schedule.DataPoints[0].HeatProduction);
        
        // Unit2 should be partially utilized (25/50) as it's more expensive
        Assert.Single(unit2Schedule.DataPoints);
        Assert.Equal(0.5, unit2Schedule.DataPoints[0].Utilization);
        Assert.Equal(25, unit2Schedule.DataPoints[0].HeatProduction);
    }
```

```csharp
    [Fact]
    public void GetAvailableUnits_ReturnsOnlyActiveUnits()
    {
        // Arrange
        var activeUnits = new List<string> { "Unit1", "Unit2" };

        var allUnits = new ObservableCollection<ProductionUnitBase>
        {
            new HeatProductionUnit { Name = "Unit1", Resource = _oil },
            new HeatProductionUnit { Name = "Unit2", Resource = _oil },
            new HeatProductionUnit { Name = "Unit3", Resource = _oil }
        };

        _mockOptimizerSettings.Setup(s => s.GetActiveUnitsNames()).Returns(activeUnits);
        _mockAssetManager.Setup(a => a.ProductionUnits).Returns(allUnits);

        // Act
        var result = _optimizer.GetAvailableUnits(_mockAssetManager.Object, _mockOptimizerSettings.Object);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, u => u.Name == "Unit1");
        Assert.Contains(result, u => u.Name == "Unit2");
        Assert.DoesNotContain(result, u => u.Name == "Unit3");
```

