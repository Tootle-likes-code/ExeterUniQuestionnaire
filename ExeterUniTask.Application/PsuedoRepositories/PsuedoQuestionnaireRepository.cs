using ExeterUniTask.Application.Factories;
using ExeterUniTask.Model;

namespace ExeterUniTask.Application.PsuedoRepositories;

public class PsuedoQuestionnaireRepository: IPsuedoQuestionnaireRepository
{
    private Dictionary<int, Questionnaire> _questionnaires;

    public PsuedoQuestionnaireRepository()
    {
        _questionnaires = new Dictionary<int, Questionnaire>();

        var questions = new QuestionCollection();
        
        questions.Add(new Question
        {
            Id = new Guid("E4C2CF3B-B7A6-4BA1-B875-5E21B6AAA7AE"),
            Title = "Question 1",
            Text = "What is your favourite colour?"
        });
        questions.Add(new Question
        {
            Id = new Guid("1C5A4187-D580-4428-A3DA-354B60400736"),
            Title = "Question 2",
            Text = "What is your quest?"
        });
        questions.Add(new Question
        {
            Id = new Guid("BBF2E91C-1A1F-42C8-BBF9-A1808D87A43D"),
            Title = "Question 3",
            Text = "What is the flight speed of an unladen swallow?"
        });

        var questionnaire = new Questionnaire(questions, true)
        {
            Id = QuestionnaireIdFactory.GetId(),
            Title = "Monty Python's Holy Grail Questions"
        };
        
        Upsert(questionnaire);
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