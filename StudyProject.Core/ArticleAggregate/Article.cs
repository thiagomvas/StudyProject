using StudyProject.Core.Models;

namespace StudyProject.Core.ArticleAggregate
{
    /// <summary>
    /// Represents an article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets the ID of the article.
        /// </summary>
        public HexId Id { get; internal set; }

        /// <summary>
        /// Gets or sets the title of the article.
        /// </summary>
        public string Title { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the content of the article.
        /// </summary>
        public string Content { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the disciplines associated with the article.
        /// </summary>
        public Discipline[] Disciplines { get; internal set; } = new Discipline[0];

        /// <summary>
        /// Gets or sets the subjects associated with the article.
        /// </summary>
        public Subject[] Subjects { get; internal set; } = new Subject[0];

        /// <summary>
        /// Gets or sets the topics associated with the article.
        /// </summary>
        public Topic[] Topics { get; internal set; } = new Topic[0];

        public Article() 
        { 
            Id = HexId.NewHexId();
        }
    }
}
