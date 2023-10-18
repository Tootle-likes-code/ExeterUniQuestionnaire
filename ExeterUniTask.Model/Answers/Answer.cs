namespace ExeterUniTask.Model.Answers;

public class Answer
{
    public Question Question { get; set; }
    public string Text { get; set; }

    public Answer()
    {
        Text = string.Empty;
    }

    public Answer(Question question) : this()
    {
        Question = question;
    }
}