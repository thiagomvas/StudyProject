namespace StudyProject.Core.Models
{
    public class Exercise
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Solution { get; set; }
        public string Hint { get; set; }
        public bool EnableFillInAnswer { get; set; }
        public double AnswerValue { get; set; }

        public static Exercise NotFound => new Exercise
        {
            Question = "Exercise not found",
            Solution = "Exercise not found",
            Hint = "Exercise not found",
            EnableFillInAnswer = false,
            AnswerValue = 0
        };
    }


}
