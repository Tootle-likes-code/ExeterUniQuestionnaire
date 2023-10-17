using ExeterUniTask.Application.Services;
using ExeterUniTask.Model;
using ExeterUniTask.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExeterUniTask.Web.Pages.Questionnaires;

public class Upsert : PageModel
{
    private readonly IQuestionnaireService _questionnaireService;
    [BindProperty]
    public QuestionnaireViewModel Questionnaire { get; set; }

    public Upsert(IQuestionnaireService questionnaireService)
    {
        _questionnaireService = questionnaireService;
    }
    
    public bool IsNew()
    {
        return Questionnaire.IsNew();
    }
    
    public void OnGet(int? id)
    {
        if (!id.HasValue)
        {
            Questionnaire = new QuestionnaireViewModel();
            _questionnaireService.Upsert((Questionnaire) Questionnaire);
            return;
        }
        
        // Get Existing
        Questionnaire = _questionnaireService.Get(id.Value);
    }

    public async Task<IActionResult> OnPostAdd()
    {
        _questionnaireService.Upsert((Questionnaire) Questionnaire);

        return RedirectToPage("/Questionnaires/Questions/Create", new {questionnaireId = Questionnaire.Id});
    }

    public async Task<IActionResult> OnPostCreate()
    {
        _questionnaireService.Publish((Questionnaire) Questionnaire);

        return RedirectToPage("/Questionnaires/Index");
    }
}