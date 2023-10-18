using ExeterUniTask.Model.Answers;

namespace ExeterUniTask.Application.PsuedoRepositories;

public class AnsweredQuestionnaireRepository
{
    private static Dictionary<Guid, AnsweredQuestionnaire> _answers = new Dictionary<Guid, AnsweredQuestionnaire>();
    public static void Upsert(AnsweredQuestionnaire questionnaire)
    {
        _answers[questionnaire.Id] = questionnaire;
    }

    public static AnsweredQuestionnaire Get(Guid id)
    {
        return _answers[id];
    }
}