namespace Verdict.AspNetCore.Extensions;

public static class VerdictExtensions
{
    public static Verdict AsFailure<T>(this Verdict<T> verdict) => (Verdict)verdict;
}