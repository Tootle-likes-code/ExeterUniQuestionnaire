using ExeterUniTask.Application.PsuedoRepositories;
using ExeterUniTask.Model;
using ExeterUniTask.Model.Answers;

namespace ExeterUniTask.Application.Services;

public class QuestionnaireService : IQuestionnaireService
{
    public void Upsert(Questionnaire questionnaire)
    {
        QuestionnaireRepository.Upsert(questionnaire);
    }

    public Questionnaire Get(int id)
    {
        return QuestionnaireRepository.Get(id);
    }

    public IEnumerable<Questionnaire> GetAll()
    {
        return QuestionnaireRepository.GetAll();
    }

    public void AddQuestion(int questionnaireId, Question question)
    {
        var questionnaire = QuestionnaireRepository.Get(questionnaireId);
        questionnaire.AddQuestion(question);

    }

    public bool HasQuestionAlready(int questionnaireId, Question question)
    {
        var questionnaire = QuestionnaireRepository.Get(questionnaireId);
        return questionnaire.Contains(question);
    }

    public void Publish(Questionnaire questionnaire)
    {
        questionnaire.Publish();
        Upsert(questionnaire);
    }

    public AnsweredQuestionnaire Answer(int id)
    {
        var questionnaire = Get(id);
        var answeredQuestionnaire = AnsweredQuestionnaire.AnswerQuestionnaire(questionnaire);
        AnsweredQuestionnaireRepository.Upsert(answeredQuestionnaire);
        return answeredQuestionnaire;
    }

    public void UpsertAnswer(AnsweredQuestionnaire questionnaire)
    {
        AnsweredQuestionnaireRepository.Upsert(questionnaire);
    }

    public AnsweredQuestionnaire GetAnswer(Guid questionnaireId)
    {
        return AnsweredQuestionnaireRepository.Get(questionnaireId);
    }
}