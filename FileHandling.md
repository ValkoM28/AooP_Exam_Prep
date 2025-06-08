## ➜ File Handling in C# (Async in Avalonia)

### ➜ Reading Text Files (Async)
- Use `File.ReadAllTextAsync` or `File.ReadAllLinesAsync` to avoid UI blocking.

```csharp
string content = await File.ReadAllTextAsync("data.txt");
string[] lines = await File.ReadAllLinesAsync("data.txt");
```

---

### ➜ Writing Text Files (Async)
- Use `File.WriteAllTextAsync` or `File.WriteAllLinesAsync` for non-blocking saves.

```csharp
await File.WriteAllTextAsync("output.txt", "Hello, Avalonia!");
await File.WriteAllLinesAsync("list.txt", new[] { "Item 1", "Item 2" });
```

---

### ➜ Appending to Files (Async)
- Use `File.AppendAllTextAsync` to asynchronously append content.

```csharp
await File.AppendAllTextAsync("log.txt", $"Log entry at {DateTime.Now}\n");
```

---

### ➜ File Dialogs (Avalonia – Async)

#### ➤ Open File Dialog
```csharp
var dialog = new OpenFileDialog {
    Title = "Open a File",
    AllowMultiple = false
};

string[]? result = await dialog.ShowAsync(ownerWindow);
if (result?.Length > 0)
{
    string fileContent = await File.ReadAllTextAsync(result[0]);
}
```

#### ➤ Save File Dialog
```csharp
var dialog = new SaveFileDialog {
    Title = "Save Your File"
};

string? filePath = await dialog.ShowAsync(ownerWindow);
if (!string.IsNullOrWhiteSpace(filePath))
{
    await File.WriteAllTextAsync(filePath, "This is the saved content.");
}
```

---

### ➜ File and Directory Utilities (Sync, but safe in background tasks)
- While some methods (like `File.Exists`) are sync, use them carefully in background tasks if needed.

```csharp
if (File.Exists("config.json"))
{
    string json = await File.ReadAllTextAsync("config.json");
}

string[] files = Directory.GetFiles("Documents", "*.txt"); // sync method
```

> ✅ **Tip**: For long-running or IO-bound tasks, consider using `Task.Run()` to avoid freezing the UI.

---

### ➜ Common Pattern for File Handling in ViewModel
```csharp
public async Task LoadFileAsync(Window owner)
{
    var dialog = new OpenFileDialog {
        Title = "Load File",
        AllowMultiple = false
    };

    var files = await dialog.ShowAsync(owner);
    if (files?.Any() == true)
    {
        string content = await File.ReadAllTextAsync(files[0]);
        // Update bound property
        FileContent = content;
    }
}
```

```xml
<Button Content="Load File" Command="{Binding LoadFileCommand}" />
```
