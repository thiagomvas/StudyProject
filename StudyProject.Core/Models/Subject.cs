using StudyProject.Core.Interfaces;

namespace StudyProject.Core.Models
{
    public class Subject : IClassification
    {
        public HexId Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
    }
}
