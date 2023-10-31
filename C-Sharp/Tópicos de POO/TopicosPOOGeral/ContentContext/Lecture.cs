using TopicosPooGeral.ContentContext.Enums;

namespace TopicosPooGeral.ContentContext
{
    public class Lecture : Base
    {
        public int Order { get; set; }
        public string? Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}