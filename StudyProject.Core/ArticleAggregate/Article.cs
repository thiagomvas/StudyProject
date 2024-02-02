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
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the article.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the content of the article.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the disciplines associated with the article.
        /// </summary>
        public Discipline[] Disciplines { get; set; } = new Discipline[0];

        /// <summary>
        /// Gets or sets the subjects associated with the article.
        /// </summary>
        public Subject[] Subjects { get; set; } = new Subject[0];

        /// <summary>
        /// Gets or sets the topics associated with the article.
        /// </summary>
        public Topic[] Topics { get; set; } = new Topic[0];

        public static readonly Article NotFound = new Article
        {
            Id = "0",
            Title = "Oops! Article Not Found",
            Content = "The article you are looking for could not be found. Please try again later.",
        };

    }
}
