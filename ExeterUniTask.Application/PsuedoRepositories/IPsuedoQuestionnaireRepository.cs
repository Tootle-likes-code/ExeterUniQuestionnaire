using ExeterUniTask.Model;

namespace ExeterUniTask.Application.PsuedoRepositories;

public interface IPsuedoQuestionnaireRepository
{
    void Upsert(Questionnaire questionnaire);

    Questionnaire Get(int id);
    IEnumerable<Questionnaire> GetAll();
}