namespace StudyProject.Core.Models
{
    public class Article
    {
        public HexId Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<string> Content { get; set; } = new();
        public Subject[] Subjects { get; set; } = new Subject[0];
    }
}
