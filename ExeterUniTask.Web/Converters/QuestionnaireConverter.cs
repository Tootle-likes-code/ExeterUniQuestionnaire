using ExeterUniTask.Model;
using ExeterUniTask.Web.ViewModels;

namespace ExeterUniTask.Web.Converters;

public static class QuestionnaireConverter
{
    public static IEnumerable<QuestionnaireViewModel> ConvertAll(IEnumerable<Questionnaire> questionnaires)
    {
        return questionnaires.Select(questionnaire => (QuestionnaireViewModel)questionnaire).ToList();
    }
}