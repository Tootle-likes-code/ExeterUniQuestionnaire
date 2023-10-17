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
        
        Questions.Add(new Question
        {
            Id = new Guid("E4C2CF3B-B7A6-4BA1-B875-5E21B6AAA7AE"),
            Title = "Question 1",
            Text = "What is your favourite colour?"
        });
        Questions.Add(new Question
        {
            Id = new Guid("1C5A4187-D580-4428-A3DA-354B60400736"),
            Title = "Question 2",
            Text = "What is your quest?"
        });
        Questions.Add(new Question
        {
            Id = new Guid("BBF2E91C-1A1F-42C8-BBF9-A1808D87A43D"),
            Title = "Question 3",
            Text = "What is the flight speed of an unladen swallow?"
        });
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