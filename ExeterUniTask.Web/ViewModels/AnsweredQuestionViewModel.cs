using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ExeterUniTask.Application.PsuedoRepositories;
using ExeterUniTask.Model;
using ExeterUniTask.Model.Answers;

namespace ExeterUniTask.Web.ViewModels;

public class AnsweredQuestionViewModel
{
    public static AnsweredQuestionViewModel Create(Guid questionnaireId, int questionPosition, Answer answer)
    {
        return new AnsweredQuestionViewModel(answer.Question)
        {
            QuestionnaireId = questionnaireId,
            QuestionPosition = questionPosition
        };
    }
    
    private Question _question;

    public int QuestionPosition { get; set; }
    public Guid QuestionnaireId { get; set; }
    public string Title { get; set; }
    [Required]
    public string Question {get; set; }

    [Required]
    [DisplayName("Answer")]
    public string Text { get; set; }

    public AnsweredQuestionViewModel()
    {
        Title = string.Empty;
        Question = string.Empty;
    }
    
    public AnsweredQuestionViewModel(Question question)
    {
        _question = question;
        Title = _question.Title;
        Question = _question.Text;
    }
}