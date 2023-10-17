using ExeterUniTask.Model;

namespace ExeterUniTask.Application.PsuedoRepositories;

/*
 * Normally I'd use repository and Unit of Work Pattern here, but I don't have the time to set up DB Repo so I'm
 * using Abstract Factory pattern to create an in memory DB that's quick and dirty.
 *
 * Also, in Abstract Factory Pattern, I would either use a Special Case class or check more rigorously for
 * nulls.
 */
public class QuestionnaireRepository
{
    private static IPsuedoQuestionnaireRepository _current = null!;

    public static void SetInstance(PsuedoQuestionnaireRepository repository)
    {
        _current = repository;
    }

    public static void Upsert(Questionnaire questionnaire)
    {
        _current.Upsert(questionnaire);
    }

    public static Questionnaire Get(int id)
    {
        return _current.Get(id);
    }

    public static IEnumerable<Questionnaire> GetAll()
    {
        return _current.GetAll();
    }
}