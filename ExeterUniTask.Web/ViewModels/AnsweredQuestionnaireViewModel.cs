using System.ComponentModel;
using ExeterUniTask.Model.Answers;

namespace ExeterUniTask.Web.ViewModels;

public class AnsweredQuestionnaireViewModel
{
    public string Title { get; set; }
    public Guid Id { get; set; }
    [DisplayName("Identifier")]
    public string Text { get; set; }
    public Dictionary<int, Answer> Answers { get; set; }

    public static implicit operator AnsweredQuestionnaireViewModel(AnsweredQuestionnaire questionnaire)
    {
        return new AnsweredQuestionnaireViewModel
        {
            Title = questionnaire.Title,
            Text = string.Empty,
            Id = questionnaire.Id,
            Answers = questionnaire.Answers
        };
    }
}