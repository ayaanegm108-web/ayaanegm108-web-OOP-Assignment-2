namespace SrpLab;

/// <summary>
/// Reason to change: the set of results derived for a student (average, letter, honor roll) changes.
/// It only combines the policy classes.
/// </summary>
public sealed class StudentResultCalculator
{
    private readonly GradeAverageCalculator _average;
    private readonly LetterGradePolicy _letters;
    private readonly HonorRollPolicy _honorRoll;

    public StudentResultCalculator(GradeAverageCalculator average, LetterGradePolicy letters, HonorRollPolicy honorRoll)
    {
        _average = average;
        _letters = letters;
        _honorRoll = honorRoll;
    }

    public StudentResult Calculate(GradeBook book, string studentId)
    {
        var average = _average.Average(book.ScoresFor(studentId));
        var letter = _letters.Letter(average);
        return new StudentResult(studentId, average, letter, _honorRoll.Qualifies(average, letter));
    }
}
