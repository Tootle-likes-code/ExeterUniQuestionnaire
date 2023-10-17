
[TestFixture]
public class QuestionCollectionTests
{
    private Question _questionOne;
    private Question _questionTwo;
    private QuestionCollection _testQuestionnaire;

    [SetUp]
    public void SetUp()
    {
        _questionOne = new Question
        {
            Id = new Guid("E4C2CF3B-B7A6-4BA1-B875-5E21B6AAA7AE"),
            Title = "Question 1",
            Text = "What is your favourite colour?"
        };

        _questionTwo = new Question
        {
            Id = new Guid("1C5A4187-D580-4428-A3DA-354B60400736"),
            Title = "Question 2",
            Text = "What is your quest?"
        };
        _testQuestionnaire = new QuestionCollection();
        _testQuestionnaire.Add(_questionOne);
        _testQuestionnaire.Add(_questionTwo);
    }

    [Test]
    public void AddQuestion_QuestionNotAlreadyAdded_AddsQuestion()
    {
        // Arrange
        var newQuestion = new Question
        {
            Id = new Guid("BBF2E91C-1A1F-42C8-BBF9-A1808D87A43D"),
            Title = "Question 3",
            Text = "What is the flight speed of an unladen swallow?"
        };

        // Act
        _testQuestionnaire.Add(newQuestion);

        // Assert
        Assert.That(_testQuestionnaire.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void AddQuestion_QuestionAlreadyExists_SizeIsNotModified()
    {
        // Arrange
        var duplicateQuestion = _questionOne;

        // Act
        _testQuestionnaire.Add(duplicateQuestion);

        // Assert
        Assert.That(_testQuestionnaire.Count, Is.EqualTo(2));
    }

    [Test]
    public void Contains_DuplicateId_ReturnsTrue()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = _questionOne.Id,
            Title = "",
            Text = ""
        };

        // Act
        var result = _testQuestionnaire.Contains(otherQuestion);

        // Assert
        Assert.That(result, Is.True);
    }
}