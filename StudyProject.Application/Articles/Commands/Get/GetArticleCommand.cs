using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.Models;

namespace StudyProject.Application.Articles.Commands.Get
{
    public class GetArticleCommand : ICommand
    {
        public HexId Id;

        public GetArticleCommand(HexId id)
        {
            Id = id;
        }

        public GetArticleCommand(string id)
        {
            try
            {
                Id = new HexId(id);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error: Could not get article with ID {id}");
                throw;
            }
        }
    }
}
