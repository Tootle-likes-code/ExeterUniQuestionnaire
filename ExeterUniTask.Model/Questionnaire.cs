namespace ExeterUniTask.Model;

public class Questionnaire
{
    public int Id { get; set; }
    public string Title { get; set; }
    public QuestionCollection Questions { get; }

    public Questionnaire(QuestionCollection questions)
    {
        Title = string.Empty;
        Questions = questions;
    }
}