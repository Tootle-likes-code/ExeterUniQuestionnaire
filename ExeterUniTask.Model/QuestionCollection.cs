namespace ExeterUniTask.Model;

public class QuestionCollection
{
    private int _currentPosition;
    private readonly Dictionary<int, Question> _questions;

    public QuestionCollection()
    {
        _questions = new Dictionary<int, Question>();
    }
    
    public int Count => _questions.Count;
    
    public void Add(Question newQuestion)
    {
        if (IsDuplicate(newQuestion))
            return;
        
        _questions.Add(_currentPosition++, newQuestion);
    }

    private bool IsDuplicate(Question otherQuestion)
    {
        var result = _questions.Values.Any(question => question.Id == otherQuestion.Id);
        return result;
    }
}