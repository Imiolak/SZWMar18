namespace SZWMar2018.Core.Models
{
    public class QuestionObjectiveStep : ObjectiveStepBase
    {
        public QuestionObjectiveStep()
        {
            Type = typeof(QuestionObjectiveStep).FullName;
        }

        public string Question { get; set; }

        public string AnswersString { get; set; }
    }
}