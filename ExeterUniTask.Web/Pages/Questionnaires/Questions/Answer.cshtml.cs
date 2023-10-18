using ExeterUniTask.Application.Services;
using ExeterUniTask.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExeterUniTask.Web.Pages.Questionnaires.Questions;

public class Answer : PageModel
{
    private readonly IQuestionnaireService _questionnaireService;
    [BindProperty]
    public AnsweredQuestionViewModel Question { get; set; }
    public string Title => Question.Title;

    public Answer(IQuestionnaireService questionnaireService)
    {
        _questionnaireService = questionnaireService;
    }
    
    public void OnGet(Guid questionnaireId, int questionPosition)
    {
        var questionnaire = _questionnaireService.GetAnswer(questionnaireId);
        Question = AnsweredQuestionViewModel.Create(questionnaireId, questionPosition, questionnaire.Answers[questionPosition]);
    }

    public bool IsFirstQuestion()
    {
        return _questionnaireService.GetAnswer(Question.QuestionnaireId).IsFirstQuestion(Question.QuestionPosition);
    }

    public bool IsLastQuestion()
    {
        return _questionnaireService.GetAnswer(Question.QuestionnaireId).IsLastQuestion(Question.QuestionPosition);
    }

    public async Task<IActionResult> OnPostBack()
    {
        if (!ModelState.IsValid)
            return Page();
        UpdateQuestionnaire();

        var nextPagePosition = Question.QuestionPosition - 1;
        return RedirectToPage("/Questionnaires/Questions/Answer",
            new { questionnaireId = Question.QuestionnaireId, questionPosition = nextPagePosition });
    }

    private void UpdateQuestionnaire()
    {
        var questionnaire = _questionnaireService.GetAnswer(Question.QuestionnaireId);
        var question = questionnaire.Answers[Question.QuestionPosition];
        question.Text = Question.Text;
        _questionnaireService.UpsertAnswer(questionnaire);
    }
    
    public async Task<IActionResult> OnPostNext()
    {
        if (!ModelState.IsValid)
            return Page();
        UpdateQuestionnaire();
        
        var nextPagePosition = Question.QuestionPosition + 1;
        return RedirectToPage("/Questionnaires/Questions/Answer",
            new { questionnaireId = Question.QuestionnaireId, questionPosition = nextPagePosition });
    }
    public async Task<IActionResult> OnPostFinish()
    {
        if (!ModelState.IsValid)
            return Page();
        UpdateQuestionnaire();

        return RedirectToPage("/Questionnaires/Index");
    }
    
}