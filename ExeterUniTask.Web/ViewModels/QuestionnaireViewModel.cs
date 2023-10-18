using System.ComponentModel.DataAnnotations;
using ExeterUniTask.Application.Factories;
using ExeterUniTask.Model;

namespace ExeterUniTask.Web.ViewModels;

public class QuestionnaireViewModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public QuestionCollection Questions { get; set; }
    public bool Published { get; set; }

    public QuestionnaireViewModel()
    {
        Id = QuestionnaireIdFactory.GetId();
        Title = string.Empty;
        Questions = new QuestionCollection();
        Published = false;
    }

    public bool IsNew()
    {
        return !Published;
    }

    public static implicit operator QuestionnaireViewModel(Questionnaire questionnaire)
    {
        return new QuestionnaireViewModel
        {
            Id = questionnaire.Id,
            Title = questionnaire.Title,
            Questions = questionnaire.Questions,
            Published = questionnaire.Published
        };
    }

    public static explicit operator Questionnaire(QuestionnaireViewModel viewModel)
    {
        return new Questionnaire(viewModel.Questions, viewModel.Published)
        {
            Id = viewModel.Id,
            Title = viewModel.Title
        };
    }
}