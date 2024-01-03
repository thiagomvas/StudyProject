using StudyProject.Core.Models;

namespace StudyProject.Core.ArticleAggregate
{
    public class Article
    {
        public HexId Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }
        public Subject[] Subjects { get; set; } = new Subject[0];

        internal Article() { }

    }
}
