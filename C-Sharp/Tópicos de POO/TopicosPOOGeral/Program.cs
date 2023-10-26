using TopicosPooGeral.ContentContext;
namespace TopicosPooGeral;
class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Hello World");

        var course = new Course();
        course.Level = ContentContext.Enums.EContentLevel.Beginner;
    }
}