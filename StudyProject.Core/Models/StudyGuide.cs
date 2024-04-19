namespace StudyProject.Core.Models
{   public class StudyGuide
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StudyGuideNode[] Nodes { get; set; }
    }

    public class StudyGuideNode
    {
        public string Name { get; set; }
        public int LineIndex { get; set; }
        public string Description { get; set; }
        public string ArticleId { get; set; }
    }
}
