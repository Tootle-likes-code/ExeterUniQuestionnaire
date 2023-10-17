using NUnit.Framework;

namespace ExeterUniTask.Model.Tests;

[TestFixture]
public class QuestionnaireTests
{
    private Question _questionOne;
    private Question _questionTwo;
    private Questionnaire _testQuestionnaire;

    [SetUp]
    public void SetUp()
    {
        _questionOne = new Question
        {
            Id = 1,
            Title = "Question 1",
            Text = "What is your favourite colour?"
        };

        _questionTwo = new Question
        {
            Id = 2,
            Title = "Question 2",
            Text = "What is your quest?"
        };
        _testQuestionnaire = new Questionnaire();
        _testQuestionnaire.AddQuestion(_questionOne);
        _testQuestionnaire.AddQuestion(_questionTwo);
    }

    [Test]
    public void AddQuestion_QuestionNotAlreadyAdded_AddsQuestion()
    {
        // Arrange
        var newQuestion = new Question
        {
            Id = 3,
            Title = "Question 3",
            Text = "What is the flight speed of an unladen swallow?"
        };

        // Act
        _testQuestionnaire.AddQuestion(newQuestion);

        // Assert
        Assert.That(_testQuestionnaire.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void AddQuestion_QuestionAlreadyExists_SizeIsNotModified()
    {
        // Arrange
        var duplicateQuestion = _questionOne;

        // Act
        _testQuestionnaire.AddQuestion(duplicateQuestion);

        // Assert
        Assert.That(_testQuestionnaire.Count, Is.EqualTo(2));
    }
}