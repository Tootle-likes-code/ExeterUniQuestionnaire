using System.ComponentModel.DataAnnotations;
using ExeterUniTask.Model;

namespace ExeterUniTask.Web.ViewModels;

public class QuestionViewModel
{
    [Required]
    public int QuestionnaireId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Text { get; set; }

    public QuestionViewModel()
    {
        Title = string.Empty;
        Text = string.Empty;
    }

    public static explicit operator Question(QuestionViewModel viewModel)
    {
        return new Question
        {
            Title = viewModel.Title,
            Text = viewModel.Text
        };
    }

    public static explicit operator QuestionViewModel(Question question)
    {
        return new QuestionViewModel
        {
            Title = question.Title,
            Text = question.Text
        };
    }
}