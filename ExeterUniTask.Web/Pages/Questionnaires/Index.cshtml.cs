using ExeterUniTask.Application.Services;
using ExeterUniTask.Model;
using ExeterUniTask.Web.Converters;
using ExeterUniTask.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExeterUniTask.Web.Pages.Questionnaires;

public class Index : PageModel
{
    private readonly IQuestionnaireService _questionnaireService;
    public IEnumerable<QuestionnaireViewModel> Questionnaires { get; set; }

    public Index(IQuestionnaireService questionnaireService)
    {
        _questionnaireService = questionnaireService;
    }
    
    public void OnGet()
    {
        Questionnaires = QuestionnaireConverter.ConvertAll(_questionnaireService.GetAll());
    }
}