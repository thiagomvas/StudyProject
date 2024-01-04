using StudyProject.Core.Interfaces;

namespace StudyProject.Core.Models
{
    public class Topic : IClassification
    {
        public HexId Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
