using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Circle.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    [ObservableProperty]
    public string color="Green";

    [ObservableProperty]
    public float diameter=100;

    [ObservableProperty]
    public List<string> colors=new(){"Green", "Red", "Blue", "Purple", "Black"};

    [RelayCommand]
    public void Reset()
    {
        Color = "Green";
        Diameter = 100;
    }
}
