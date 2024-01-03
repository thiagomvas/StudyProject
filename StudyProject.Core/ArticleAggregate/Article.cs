using StudyProject.Core.Models;

namespace StudyProject.Core.ArticleAggregate
{
    public class Article
    {
        public HexId Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }
        public Discipline[] Disciplines { get; set; } = new Discipline[0];
        public Subject[] Subjects { get; set; } = new Subject[0];
        public Topic[] Topics { get; set; } = new Topic[0];

        internal Article() { }

    }
}
