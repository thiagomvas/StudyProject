using StudyProject.Application.Common.Interfaces;

namespace StudyProject.Application.Articles.Commands.Create
{
    public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateArticleCommandHandler(IApplicationDbContext context)
        {
			_context = context;
		}

        public void Handle(CreateArticleCommand command)
        {
            _context.AddArticleAsync(command.article);
        }
    }
}
