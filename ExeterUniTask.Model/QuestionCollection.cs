using System.Collections;

namespace ExeterUniTask.Model;

public class QuestionCollection : IEnumerable<Question>
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

    public bool Contains(Question otherQuestion)
    {
        return _questions.Values.Any(question => question.Equals(otherQuestion));
    }

    public IEnumerator<Question> GetEnumerator()
    {
        return _questions.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}