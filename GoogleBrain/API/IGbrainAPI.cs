namespace GoogleBrain
{
    public interface IGbrainAPI
    {
        long GetNumerOfResults(params string[] keywords);
        int GetNumberOfOccourrences(string question, string answer);
    }
}