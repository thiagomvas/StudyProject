using StudyProject.Core.Models;

namespace StudyProject.Core.Interfaces
{
    internal interface IClassification
    {
        HexId Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
