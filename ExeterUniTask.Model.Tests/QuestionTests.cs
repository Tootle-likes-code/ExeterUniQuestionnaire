using NUnit.Framework;

namespace ExeterUniTask.Model.Tests;

[TestFixture]
public class QuestionTests
{
    private readonly Question _testQuestion;

    public QuestionTests()
    {
        _testQuestion = new Question
        {
            Id = new Guid("0546E9DF-A998-4A94-B397-5695033F7B4C"),
            Title = "Test Question Title",
            Text = "Test Question"
        };
    }
    
    [Test]
    public void Equals_IdMatches_ReturnsTrue()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = new Guid("0546E9DF-A998-4A94-B397-5695033F7B4C"),
            Title = "",
            Text = "Other Text"
        };

        // Act
        var result = _testQuestion.Equals(otherQuestion);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Equals_TextMatches_ReturnsTrue()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = Guid.NewGuid(),
            Title = "",
            Text = "Test Question"
        };

        // Act
        var result = _testQuestion.Equals(otherQuestion);

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Equals_TextMatchesUpperCase_ReturnsTrue()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = Guid.NewGuid(),
            Title = "",
            Text = "Test Question".ToUpper()
        };

        // Act
        var result = _testQuestion.Equals(otherQuestion);

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Equals_TextMatchesLowerCase_ReturnsTrue()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = Guid.NewGuid(),
            Title = "",
            Text = "Test Question".ToLower()
        };

        // Act
        var result = _testQuestion.Equals(otherQuestion);

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Equals_TextMatchesChangedCase_ReturnsTrue()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = Guid.NewGuid(),
            Title = "",
            Text = "TeSt QuEsTiOn"
        };

        // Act
        var result = _testQuestion.Equals(otherQuestion);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Equals_TitlesMatch_ReturnsFalse()
    {
        // Arrange
        var otherQuestion = new Question
        {
            Id = Guid.NewGuid(),
            Title = "Test Question Title",
            Text = ""
        };

        // Act
        var result = _testQuestion.Equals(otherQuestion);

        // Assert
        Assert.That(result, Is.False);
    }
}