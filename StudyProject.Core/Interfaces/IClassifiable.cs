using StudyProject.Core.Models;

namespace StudyProject.Core.Interfaces
{
    internal interface IClassifiable
    {
        HexId Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
