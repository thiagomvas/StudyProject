using StudyProject.Application.Articles.Commands.Create;
using StudyProject.Application.Articles.Commands.Get;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application.Articles.Commands
{
    public class ArticleCommandInvoker
    {
        private readonly IApplicationDbContext _context;

        public ArticleCommandInvoker(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateArticleAsync(CreateArticleCommand command)
        {
            var article = command.article;
            await _context.AddArticleAsync(article);
        }

        public async Task<Article> GetArticleAsync(GetArticleCommand command)
        {
            var article = await _context.GetArticleByIdAsync(command.Id);
            Console.WriteLine(article.Title);
            return article;
        }

    }
}
