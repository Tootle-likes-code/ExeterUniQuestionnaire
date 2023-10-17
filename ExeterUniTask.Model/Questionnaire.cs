namespace ExeterUniTask.Model;

public class Questionnaire
{
    private int _currentPosition;
    private readonly Dictionary<int, Question> _questions;
    public int Id { get; set; }
    public IEnumerable<Question> Questions => _questions.Values.ToList();
    public int Count => _questions.Count;

    public Questionnaire()
    {
        _questions = new Dictionary<int, Question>();
        _currentPosition = 0;
    }

    public void AddQuestion(Question newQuestion)
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