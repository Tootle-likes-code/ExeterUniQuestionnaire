namespace ExeterUniTask.Application.Factories;


/**
 * I wouldn't normally do this, but it's here in interest of time.
 */
public class QuestionnaireIdFactory
{
    public static QuestionnaireIdFactory _current;

    public static int GetId()
    {
        if (_current == null)
        {
            _current = new QuestionnaireIdFactory();
        }

        return _current.NextId();
    }

    private int _nextId;
    public QuestionnaireIdFactory()
    {
        _nextId = 0;
    }

    public int NextId()
    {
        return ++_nextId;
    }
}