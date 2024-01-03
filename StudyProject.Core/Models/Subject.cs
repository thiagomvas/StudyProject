using StudyProject.Core.Interfaces;

namespace StudyProject.Core.Models
{
    public class Subject : IClassifiable
    {
        public HexId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
