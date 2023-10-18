using ExeterUniTask.Application.Services;
using ExeterUniTask.Model.Answers;
using ExeterUniTask.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExeterUniTask.Web.Pages.Questionnaires;

public class Answer : PageModel
{
    private readonly IQuestionnaireService _questionnaireService;
    [BindProperty]
    public AnsweredQuestionnaireViewModel Questionnaire { get; set; }

    public Answer(IQuestionnaireService questionnaireService)
    {
        _questionnaireService = questionnaireService;
    }
    
    public void OnGet(int id)
    {
        Questionnaire = _questionnaireService.Answer(id);
    }

    public async Task<IActionResult> OnPost()
    {
        var answeredQuestionnaire = _questionnaireService.GetAnswer(Questionnaire.Id);
        answeredQuestionnaire.Text = Questionnaire.Text;
        _questionnaireService.UpsertAnswer(answeredQuestionnaire);

        return RedirectToPage("/Questionnaires/Questions/Answer",
            new { questionnaireId = Questionnaire.Id, questionPosition = 0 });
    }
}