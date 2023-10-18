using System.Collections;

namespace ExeterUniTask.Model.Answers;

public class AnswerCollection: IEnumerable<Answer>
{
    public static AnswerCollection CreateAnswerCollection(QuestionCollection questions)
    {
        var answers = new AnswerCollection();

        var i = 0;
        foreach (var question in questions)
        {
            answers[i++] = new Answer
            {
                Question = question
            };
        }

        return answers;
    }
    
    
    private Dictionary<int, Answer> _answers;

    private AnswerCollection()
    {
        _answers = new Dictionary<int, Answer>();
    }

    public Answer this[int position]
    {
        get => _answers[position];
        set => _answers[position] = value;
    }
    
    public IEnumerator<Answer> GetEnumerator()
    {
        return _answers.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}