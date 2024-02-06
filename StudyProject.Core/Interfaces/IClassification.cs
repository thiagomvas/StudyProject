using StudyProject.Core.Models;

namespace StudyProject.Core.Interfaces
{
    internal interface IClassification
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
