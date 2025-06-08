namespace ParseCsv;

class Program
{
    
    //yes, stupid way, I do not care
    private const string path = "comics.csv";
    private static List<Comic> _comics;

    public static void Main(string[] args)
    {
        List<Comic> Before2000(List<Comic> comics)
        {
            return comics.Where(x => x.ReleaseYear <= 2000).ToList();
        }


        List<AuthorCount> AuthorsDescendingByPublishes(List<Comic> comics)
        {
            return comics.GroupBy(x => x.Author).Select(a => new AuthorCount { Author = a.Key, Count = a.Count()}).OrderByDescending(a => a.Count).ToList();
        }
        

        List<MostActiveAuthorByYear> MostActiveAuthorsPerYear(List<Comic> comics)
        {
            
            //This is not my work, I needed to ask around others for this, so do not count it to the points ;)
            var result = comics
                .GroupBy(x => x.ReleaseYear)
                .Select(yearGroup =>
                {
                    var topAuthorGroup = yearGroup.GroupBy(x => x.Author).OrderByDescending(g => g.Count()).First();
                    return new MostActiveAuthorByYear
                        { Author = topAuthorGroup.Key, ReleaseYear = yearGroup.Key, Count = topAuthorGroup.Count() }; 
                }).OrderBy(x => x.ReleaseYear).ToList();
            
            return result;
        }
        
        _comics = CsvParser.LoadData(path); 
     

        
        var before2000 = Before2000(_comics);
        Console.WriteLine("\n=== Released before 2000 ===");
        foreach (var entry in before2000)
            Console.WriteLine($"{entry.ReleaseYear}: {entry.Title}");
        
        var byPublishes = AuthorsDescendingByPublishes(_comics);
        Console.WriteLine("\n=== Most active authors in total ===");
        foreach (var entry in byPublishes)
            Console.WriteLine($"{entry.Author}: {entry.Count}");
        
        var topAuthorsByYear = MostActiveAuthorsPerYear(_comics);
        Console.WriteLine("\n=== Most active author per year ===");
        foreach (var entry in topAuthorsByYear)
            Console.WriteLine($"{entry.ReleaseYear}: {entry.Author} ({entry.Count} comics)");



        
    }

    private class AuthorCount
    {
        public string Author { get; set; }
        public int Count { get; set; }
    }

    private class MostActiveAuthorByYear
    {
        public int ReleaseYear { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }
        
    }
}