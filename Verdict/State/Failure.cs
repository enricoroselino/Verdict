namespace Verdict.State;

public class Failure : Reason
{
    public Failure() : base()
    {
    }

    public Failure(string message) : base(message)
    {
    }
}