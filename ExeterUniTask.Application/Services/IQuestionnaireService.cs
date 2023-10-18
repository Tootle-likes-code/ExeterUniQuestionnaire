using ExeterUniTask.Model;
using ExeterUniTask.Model.Answers;

namespace ExeterUniTask.Application.Services;

public interface IQuestionnaireService
{
    void Upsert(Questionnaire questionnaire);
    Questionnaire Get(int id);
    IEnumerable<Questionnaire> GetAll();
    void AddQuestion(int questionnaireId, Question question);
    bool HasQuestionAlready(int questionnaireId, Question question);
    void Publish(Questionnaire questionnaire);
    AnsweredQuestionnaire Answer(int id);
    void UpsertAnswer(AnsweredQuestionnaire questionnaire);
    AnsweredQuestionnaire GetAnswer(Guid questionnaireId);
}