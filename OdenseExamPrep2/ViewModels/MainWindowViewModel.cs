using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OdenseExamPrep2.facade;

namespace OdenseExamPrep2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private string _array1 = string.Empty;    
    
    [ObservableProperty] 
    private string _array2 = string.Empty;
    
    [ObservableProperty]
    private int _number1;
    
    [ObservableProperty]
    private int _number2; 
    
    
    public Facade Facade { get; init; }
    public MainWindowViewModel()
    {
        Facade = new Facade(); 
    }

    [RelayCommand]
    public void ClickHandler()
    {
        int[] temp = Facade.FillArray(Number1, Number2);
        Array1 = string.Join(", ", temp);
        int[] temp2 = Facade.FillUniqueArray(Number1, Number2);
        Array2 = string.Join(", ", temp2); 
    }   
    
    [RelayCommand]
    public void FillArray()
    {
        int[] temp = Facade.FillArray(Number1, Number2);
        Array1 = string.Join(", ", temp);
    }      
    
    [RelayCommand]
    public void FillUniqueArray()
    {
        int[] temp = Facade.FillUniqueArray(Number1, Number2);
        Array2 = string.Join(", ", temp); 
    }   
    
    
    
}