namespace StudyProject.Core.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Subject[] Subjects { get; set; } = new Subject[0];
    }
}
