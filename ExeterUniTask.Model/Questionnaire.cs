namespace ExeterUniTask.Model;

public class Questionnaire
{
    public int Id { get; set; }
    public string Title { get; set; }
    public QuestionCollection Questions { get; }
    
    public bool Published { get; private set; }

    public Questionnaire(QuestionCollection questions)
    {
        Title = string.Empty;
        Questions = questions;
        Published = false;
    }

    public Questionnaire(QuestionCollection questions, bool published) : this(questions)
    {
        Published = published;
    }

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    public bool Contains(Question otherQuestion)
    {
        return Questions.Contains(otherQuestion);
    }

    public void Publish()
    {
        Published = true;
    }
}