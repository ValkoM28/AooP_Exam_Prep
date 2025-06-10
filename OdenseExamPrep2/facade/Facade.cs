using System;
using System.Collections.Generic;
using System.Linq;

namespace OdenseExamPrep2.facade;

public class Facade
{
    private int[] _intArray;
    
    public int[] IntArray => _intArray;

    private Random _randomVariable;

    public Facade()
    {   
        _randomVariable = new Random(); 
    }

    public int[] FillArray(int size, int max)
    {
        var array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = _randomVariable.Next(max + 1); 
        }

        return array;
    }

    public int[] FillUniqueArray(int size, int max)
    {
        if (size > max + 1) throw new ArgumentException("size cannot be greater than maximum value"); 
        HashSet<int> array = new HashSet<int>();

        do
        {
            array.Add(_randomVariable.Next(max + 1));
        } while (array.Count < size);

        int[] result = array.ToArray();
        Array.Sort(result);
        return result;
        //this approach forces the use of the Random class, cleaner in my opinion would be to make an array of all integers from 0 to max
        //shuffle the list and then return the first n members (n being the size parameter)
    }

    public static void TestFacadeOutput()
    {
        Facade facade = new Facade();
        Console.WriteLine(string.Join(", ", facade.FillArray(20, 10)));
        Console.WriteLine(string.Join(", ", facade.FillUniqueArray(10, 20)));
    }
    
    

}