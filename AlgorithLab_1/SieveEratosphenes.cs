namespace AlgorithLab_1;

public class SieveEratosphenes : IExecutable
{
    static void SieveEratosthenes(int n)
    {
        var numbers = Enumerable.Range(1, n - 1).ToList();

        for (var i = 0; i < numbers.Count; i++)
        {
            for (var j = 2; j < n ; j++)
            {
                numbers.Remove(numbers[i] * j);
            }
        }
    }
    
    public void Execute(int n)
    {
        SieveEratosthenes(n);
    }

    public Func<double, double> GetComplexityFunction() => num => num * Math.Log2(num);
    
    public static long Timer(int variableCount)
    {
        return TimeMaesures.Timer(variableCount, new SieveEratosphenes());
    }
}