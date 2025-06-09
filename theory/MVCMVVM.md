## ➜ Model-View-Controller (MVC)

---

### ➤ What is MVC?

**Model-View-Controller (MVC)** is an **architectural design pattern** that separates an application into three interconnected components:

1. **Model** – manages the data and business logic.
2. **View** – displays the data (UI).
3. **Controller** – handles input and updates both the Model and View.

This separation improves modularity, testability, and clarity.

---

### ➤ Why MVC?

The idea is to **decouple** the user interface from business logic so that:
- The **UI can change** without rewriting business rules.
- The **logic can evolve** without disturbing the UI.
- **Testing** can target logic independently of GUI rendering.

---

### ➤ Responsibilities

| Component   | Role                                                                 |
|-------------|----------------------------------------------------------------------|
| **Model**   | Represents data, logic, and rules. Responds to commands from controller to update state. |
| **View**    | Visualizes model data. Passively observes or requests data updates.  |
| **Controller** | Handles user input (e.g., clicks), manipulates model, updates view. |

---

### ➤ Diagram

```text
          +-----------+        user input        +--------------+
          |           |  --------------------->  |              |
          | Controller|                         |     View     |
          |           |  <---------------------  |              |
          +-----------+       screen update     +--------------+
                |
                | modifies
                v
           +----------+
           |  Model   |
           +----------+
                |
                | notifies
                v
             (View)
```

---

### ➤ Communication Flow

1. **User interacts** with the View (e.g., clicks a button).
2. **Controller handles** the input and updates the Model.
3. **Model changes** (e.g., data is saved or modified).
4. **View is updated** (either manually by the Controller or via a change notification mechanism).

---

### ➤ Example (Simplified)

```csharp
// MODEL
public class CalculatorModel
{
    public int Add(int a, int b) => a + b;
}

// VIEW (XAML, UI Layer)
<Button x:Name="AddButton" Content="Add"/>
<TextBox x:Name="ResultBox"/>

// CONTROLLER
public class CalculatorController
{
    private readonly CalculatorModel _model;
    private readonly CalculatorView _view;

    public CalculatorController(CalculatorView view)
    {
        _view = view;
        _model = new CalculatorModel();

        _view.AddButton.Click += OnAddClicked;
    }

    private void OnAddClicked(object sender, RoutedEventArgs e)
    {
        int result = _model.Add(2, 3); // For example purposes
        _view.ResultBox.Text = result.ToString();
    }
}
```

---

### ➤ Advantages of MVC

✅ **Separation of Concerns** – Each layer is isolated  
✅ **Testable** – Models and Controllers can be tested independently  
✅ **Reusability** – One model can work with many views  
✅ **Flexibility** – Easier to replace UI or logic independently  

---

### ➤ Disadvantages

❌ **Verbosity** – Requires more boilerplate  
❌ **Tight coupling** between View and Controller in desktop apps  
❌ **Less natural for declarative UIs** like XAML in Avalonia  
❌ **Manual data sync** – Unlike MVVM, no binding engine

---

### ➤ MVC vs MVVM (Comparison Table)

| Feature               | MVC                         | MVVM                         |
|-----------------------|-----------------------------|------------------------------|
| Primary Pattern       | Input-Output driven         | Binding and reactive driven |
| Controller/VM Role    | Handles logic and updates   | Handles data and commands   |
| View updates          | Manual                      | Data binding (automatic)    |
| Ideal for             | Web apps, early UIs         | Modern desktop/XAML UIs     |
| Testability           | Controller, Model           | ViewModel, Model            |
| Avalonia Recommendation | Not ideal                 | ✔ Preferred pattern         |

### ➜ MVVM – Model-View-ViewModel (Preferred in Avalonia)

- **Model**: Your data and business rules.
- **View**: The XAML UI — pure declarative.
- **ViewModel**: Connects Model to View via data-binding and commands.

> ✅ Promotes testability, separation of concerns, and binding-friendly design.

---

### MVVM Example in Avalonia

**Model**
```csharp
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

**ViewModel**
```csharp
public class PersonViewModel : ReactiveObject
{
    private string _firstName;
    private string _lastName;

    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

    public PersonViewModel()
    {
        SubmitCommand = ReactiveCommand.Create(() =>
        {
            // Submit logic here
        });
    }
}
```

**View (XAML)** – `PersonView.axaml`
```xml
<StackPanel>
  <TextBox Text="{Binding FirstName, Mode=TwoWay}" />
  <TextBox Text="{Binding LastName, Mode=TwoWay}" />
  <Button Content="Submit" Command="{Binding SubmitCommand}" />
</StackPanel>
```

**Code-Behind (View)**
```csharp
public partial class PersonView : UserControl
{
    public PersonView()
    {
        InitializeComponent();
        DataContext = new PersonViewModel();
    }
}
```

---

### ➤ Why MVVM is Ideal in Avalonia

✅ Supports full binding (`{Binding}`) in XAML  
✅ Works great with ReactiveUI  
✅ Easy to unit test `ViewModel`  
✅ Clean separation of responsibilities
