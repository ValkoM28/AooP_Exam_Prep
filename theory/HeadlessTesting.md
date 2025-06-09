## ➜ Headless UI Testing in Avalonia

Avalonia supports **headless testing**, allowing you to run unit/UI tests on UI components without launching a full application window — great for CI and automation.

---

### ➤ Step 1: Install Required Packages

In your **test project** (`.Tests`), add these NuGet packages:

```bash
dotnet add package Avalonia.Headless
dotnet add package Avalonia.Controls.UnitTests
dotnet add package xunit
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit.runner.visualstudio
```

---

### ➤ Step 2: Set Up Headless Test Base Class

Create a test base that sets up Avalonia in headless mode:

```csharp
using Avalonia.Headless;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Avalonia;

public class HeadlessTestBase : IDisposable
{
    public HeadlessTestBase()
    {
        AppBuilder.Configure<App>()
            .UseHeadless()
            .SetupWithoutStarting();
    }

    public void Dispose()
    {
        Dispatcher.UIThread.InvokeAsync(Dispatcher.UIThread.ExitAllFrames).Wait();
    }
}
```

> 🧠 Replace `App` with your own `App.xaml.cs` class or a lightweight version for testing.

---

### ➤ Step 3: Write a Simple Headless UI Test

```csharp
public class MainViewTests : HeadlessTestBase
{
    [Fact]
    public async Task TextBox_Updates_Text()
    {
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            var textBox = new TextBox { Text = "Hello" };
            textBox.Text = "Updated!";
            Assert.Equal("Updated!", textBox.Text);
        });
    }
}
```

---

### ➤ Step 4: Test a Custom Control or View

Suppose you have a `MainView.axaml` with a `TextBlock` bound to `Greeting`.

#### ViewModel:

```csharp
public class MainViewModel
{
    public string Greeting { get; set; } = "Hello, Avalonia!";
}
```

#### UI Test:

```csharp
public class MainViewUITests : HeadlessTestBase
{
    [Fact]
    public async Task GreetingTextBlock_HasCorrectText()
    {
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            var view = new MainView
            {
                DataContext = new MainViewModel()
            };
            view.ApplyTemplate(); // important for Avalonia headless rendering
            var textBlock = view.FindControl<TextBlock>("GreetingText");
            Assert.Equal("Hello, Avalonia!", textBlock.Text);
        });
    }
}
```

> ⚠️ Ensure your control in `MainView.axaml` has `x:Name="GreetingText"` for it to be discoverable in tests.

---

### ➤ Step 5: Run Tests

Use the standard `.NET test` command:

```bash
dotnet test
```

Or run them via Visual Studio / Rider test explorer.

---

### ➤ Tips for Headless UI Tests

- Use `Dispatcher.UIThread.InvokeAsync(...)` for all UI code.
- Use `.ApplyTemplate()` to ensure controls are initialized.
- Prefer naming controls (`x:Name`) for easy access in tests.
- For async or reactive controls, you may need to `await Task.Delay(...)` for bindings to settle.

---

### ➤ Optional: Integration with CI

Add the following to GitHub Actions or other CI to run UI tests:

```yaml
- name: Run tests
  run: dotnet test --no-restore --verbosity normal
```
