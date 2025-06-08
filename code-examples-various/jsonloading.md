```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

        static void Main(string[] args)
        {
            string filePath = "people.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file not found.");
                return;
            }

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonContent);

                foreach (var person in people)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

