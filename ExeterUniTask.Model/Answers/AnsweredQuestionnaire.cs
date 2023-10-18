using System.ComponentModel;

namespace ExeterUniTask.Model.Answers;

public class AnsweredQuestionnaire
{
    public static AnsweredQuestionnaire AnswerQuestionnaire(Questionnaire questionnaire)
    {
        return new AnsweredQuestionnaire(questionnaire);
    }
    
    private Questionnaire _questionnaire;
    public Guid Id { get; set; }
    public int QuestionnaireId => _questionnaire.Id;
    public string Title => _questionnaire.Title;
    public string Text { get; set; }
    public Dictionary<int, Answer> Answers { get; set; }

    private AnsweredQuestionnaire(Questionnaire questionnaire)
    {
        Id = Guid.NewGuid();
        _questionnaire = questionnaire;
        InitialiseAnswers();
    }
    
    // This needs tidying up.
    private void InitialiseAnswers()
    {
        Answers = new Dictionary<int, Answer>();

        if (_questionnaire == null)
            return;
        
        var currentCount = 0;
        foreach (var question in _questionnaire.Questions)
        {
            Answers[currentCount++] = new Answer(question);
        }
    }

    public bool IsFirstQuestion(int questionQuestionPosition)
    {
        return questionQuestionPosition == 0;
    }

    public bool IsLastQuestion(int questionQuestionPosition)
    {
        return Answers.Keys.Order().Last() == questionQuestionPosition;
    }
}