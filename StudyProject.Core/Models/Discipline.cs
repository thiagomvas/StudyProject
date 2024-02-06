﻿using StudyProject.Core.Interfaces;

namespace StudyProject.Core.Models
{
    public class Discipline : IClassification
    {
        public string Id { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
