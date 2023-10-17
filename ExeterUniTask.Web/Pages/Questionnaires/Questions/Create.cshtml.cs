using ExeterUniTask.Application.PsuedoRepositories;
using ExeterUniTask.Application.Services;
using ExeterUniTask.Model;
using ExeterUniTask.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExeterUniTask.Web.Pages.Questionnaires.Questions;

public class Create : PageModel
{
    private readonly IQuestionnaireService _questionnaireService;
    [BindProperty]
    public QuestionViewModel Question { get; set; }
    public int QuestionnaireId => Question.QuestionnaireId;

    public Create(IQuestionnaireService questionnaireService)
    {
        _questionnaireService = questionnaireService;
    }
    
    public void OnGet(int questionnaireId)
    {
        Question = new QuestionViewModel
        {
            QuestionnaireId = questionnaireId
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        /*
         * Current setup fails with empty text.  Would ideally tidy that up.
         */
        if (_questionnaireService.HasQuestionAlready(Question.QuestionnaireId, (Question) Question))
            ModelState.AddModelError("Question.Text", "The question is a duplicate.");
        if (!ModelState.IsValid)
            return Page();

        
        _questionnaireService.AddQuestion(Question.QuestionnaireId, (Question) Question);

        // Should be validation handling here.
        return RedirectToPage("/Questionnaires/Upsert", new {id = Question.QuestionnaireId});
    }
}