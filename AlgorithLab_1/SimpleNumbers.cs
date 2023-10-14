namespace AlgorithLab_1;

public class SimpleNumbers : IExecutable
{
    static void SimpleNums(int n)
    {
        List<int> numbers = new();

        for (var i = 0; i < n; i++)
        {
            bool isSimple = true;
            for (var j = 2; j < i; j++)
            {
                if(i % j != 0)
                {
                    isSimple = false;
                    break;
                }
            }
            if (isSimple)
            {
                numbers.Add(i);
            }
        }
    }

    public void Execute(int n)
    {
        SimpleNums(n);
    }

    public Func<double, double> GetComplexityFunction() => num => num;

    public static long Timer(int variableCount)
    {
        return TimeMaesures.Timer(variableCount, new SimpleNumbers());
    }
}