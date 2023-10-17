using ExeterUniTask.Model;

namespace ExeterUniTask.Application.PsuedoRepositories;

public class PsuedoQuestionnaireRepository: IPsuedoQuestionnaireRepository
{
    private Dictionary<int, Questionnaire> _questionnaires;

    public PsuedoQuestionnaireRepository()
    {
        _questionnaires = new Dictionary<int, Questionnaire>();
    }

    public void Upsert(Questionnaire questionnaire)
    {
        _questionnaires[questionnaire.Id] = questionnaire;
    }

    public Questionnaire Get(int id)
    {
        if (_questionnaires.Keys.Contains(id))
            return _questionnaires[id];

        // Probably a candidate for Special Case Class.
        throw new ArgumentException($"No Questionnaire with id '{id}'");
    }

    public IEnumerable<Questionnaire> GetAll()
    {
        return _questionnaires.Values.ToList();
    }
}