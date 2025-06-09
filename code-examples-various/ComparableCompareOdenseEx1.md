 Assume, you are learning C#. You are introduced to the concepts of Comparable and Comparer interfaces. You need to practice these concepts 
 and compare objects using both interfaces. Considering yourself a student, who needs to master these concepts, you decided to implement a 
 student class such that you can compare student objects using both interfaces.



Task 1a: Student implements IComparable\<Student\>
A class called `Student.cs` is already created in the folder _Assignment1_.
Complete the implementation of the class. Remember to use correct access modifiers for variables and methods.
### Declare 5 variables for `name(string)`, `age(int)`, `department(string)`, `result(string)`, `marks(double)`.
### Create a Constructor to initialize 5 variables.
### Create 5 `get` properties for retrieving the values of all the 5 variables. A `get` property should return the value of the variable.
### Implement a `CompareTo()` method, i.e., compare the `marks` of two `Student` objects. 
### Use the corresponding `get` property for this implementation.
   - A `ToString() method is already provided to print the students' information. Uncomment it after completing the points above.
   - Implement the `Main()` method as such:
       - Create a Set `studentSet1` of type Student with reference to `SortedSet`
       - Create 5 student objects with the following data:
     
       | Name | Age | Department | Result | Marks |
       |------|-----|-----|------|------|
       | Tim  | 20  | me  | pass | 9,80 |
       | Bo   | 21  | me  | pass | 9,20 |
       | Ella | 19  | ece | fail | 3,20 |
       | Emma | 19  | ece | pass | 9,60 |
       | Paul | 20  | cse | pass | 8,60 |
   
       - Add student objects to the `studentSet1` using `Add()` method
       - Print all elements inside the object `studentSet1`, using the commented `Console.Writeline`
   - Run and test your implementation.
   
   **Example** of correct output
   
   Sorting based on marks
   ```
   [Ella            19              ece             fail            3,20
   , Paul           20              cse             pass            8,60
   , Bo             21              me              pass            9,20
   , Emma           19              ece             pass            9,60
   , Tim            20              me              pass            9,80
   ]
   ```
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        MainWithLinq();
        Console.WriteLine("=============");
        MainWithLambda();
        Console.WriteLine("=============");
        
        // Task 1a
        Console.WriteLine("Sorting based on Marks");
        var studentSet1 = new SortedSet<Student>();
        
        studentSet1.Add(new Student("Tim", 20, "me","pass", 9.80));
        studentSet1.Add(new Student("Bo", 21, "me", "pass", 9.20));
        studentSet1.Add(new Student("Ella", 19, "ece", "fail", 3.20));
        studentSet1.Add(new Student("Emma", 19, "ece", "pass", 9.60));
        studentSet1.Add(new Student("Paul", 20, "cse", "pass", 8.60));
        
        
        
        Console.WriteLine("[" + string.Join(", ", studentSet1) + "]");

        // Task 1b
        Console.WriteLine("Sorting based on Age");
        
        var studentSet2 = new SortedSet<Student>(new AgeComparer());
        studentSet2.UnionWith(studentSet1);
        Console.WriteLine("[" + string.Join(", ", studentSet2) + "]");
    }

    //just for the completeness, was not required by the exercise
    public static void MainWithLinq()
    {
        Console.WriteLine("Sorting based on Marks");
        var studentSet1 = new HashSet<Student>();
        
        studentSet1.Add(new Student("Tim", 20, "me","pass", 9.80));
        studentSet1.Add(new Student("Bo", 21, "me", "pass", 9.20));
        studentSet1.Add(new Student("Ella", 19, "ece", "fail", 3.20));
        studentSet1.Add(new Student("Emma", 19, "ece", "pass", 9.60));
        studentSet1.Add(new Student("Paul", 20, "cse", "pass", 8.60));

        var sortedStudentSet1 = from s in studentSet1 orderby s select s;
        foreach (var x in sortedStudentSet1) {
            Console.WriteLine(x);
        }
        Console.WriteLine("Sorting based on Age");

        var sortedStudentSet2 = from s in studentSet1 orderby s.Age, s.Marks select s; 
        foreach (var x in sortedStudentSet2) {
            Console.WriteLine(x);
        }
    }
    
    public static void MainWithLambda()
    {
        Console.WriteLine("Sorting based on Marks");
        var studentSet1 = new HashSet<Student>();
        
        studentSet1.Add(new Student("Tim", 20, "me","pass", 9.80));
        studentSet1.Add(new Student("Bo", 21, "me", "pass", 9.20));
        studentSet1.Add(new Student("Ella", 19, "ece", "fail", 3.20));
        studentSet1.Add(new Student("Emma", 19, "ece", "pass", 9.60));
        studentSet1.Add(new Student("Paul", 20, "cse", "pass", 8.60));

        var sortedStudentSet1 = studentSet1.OrderBy(s => s);
        foreach (var x in sortedStudentSet1) {
            Console.WriteLine(x);
        }
        Console.WriteLine("Sorting based on Age");

        var sortedStudentSet2 = studentSet1.OrderBy(s => s.Age).ThenByDescending(s => s.Marks); 
        foreach (var x in sortedStudentSet2) {
            Console.WriteLine(x);
        }
    }
}
```


```csharp
public class Student : IComparable<Student>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Department { get; private set; }
    public string Result { get; private set; }
    public double Marks { get; private set; }

    public Student(string name, int age, string department, string results, double marks)
    {
        Name = name;
        Age = age;
        Department = department;
        Result = results;
        Marks = marks;
    }
    
    // Uncomment this once done. Make sure you use the right names of 'get' properties in the ToString()
    public override String ToString() {
        return $"{Name} \t \t {Age} \t \t {Department} \t \t {Result} \t \t {Marks:.00}\n";
    }

    public int CompareTo(Student? s)
    {
        //ensure we have a student: 
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }; 
        
        //compare the marks of the students, if they are the same, sort alphabetically (was not specified in the assignment though)
        if (s.Marks < this.Marks) return -1;
        if (s.Marks > this.Marks) return 1;
        
        return string.Compare(Name, s.Name, StringComparison.Ordinal);
    }
}
```
## Task 1b: Sorting with Comparator

Create a class `AgeComparer.cs` with the signature `public class AgeComparer : IComparer<Student>`.

Implement the `Compare()` method to compare two `Student` objects by their `age` values and if two objects
   have the same `age`, they should be compared by their `marks` values.
   (**Hint** : Remember to use the corresponding `get` properties in the `Student` object.

   - In the `Main()` method of the `Student` class,
       - Creating another set `studentSet2` of type `Student` with reference to `SortedSet<Student>(new AgeComparer())`
       - Add `studentSet1` to `studentSet2` using `UnionWith()` method.
       - Print all elements inside the object `studentSet2`, using the commented `Console.Writeline`

   - Run and test your implementation.

   **Example** of correct output

   Sorting based on age
   ```
   [Ella            19              ece             fail            3,20
   , Emma           19              ece             pass            9,60
   , Paul           20              cse             pass            8,60
   , Tim            20              me              pass            9,80
   , Bo             21              me q             pass            9,20
   ]
   ```
 */

```csharp
public class AgeComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x is null || y is null) throw new ArgumentNullException(nameof(x) + Environment.NewLine + nameof(y));
        int temp = x.Age.CompareTo(y.Age);
        if (temp != 0) return temp; 
        else return x.Marks.CompareTo(y.Marks);
    }
}

```
