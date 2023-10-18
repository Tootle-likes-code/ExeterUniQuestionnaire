namespace ExeterUniTask.Model;

public class Question
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public Question()
    {
        Id = Guid.NewGuid();
    }

    protected bool Equals(Question other)
    {
        return Id.Equals(other.Id) || Text.ToLowerInvariant() == other.Text.ToLowerInvariant();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Question)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Title, Text);
    }
}