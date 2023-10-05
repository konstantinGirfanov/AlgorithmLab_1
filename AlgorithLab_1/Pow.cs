using AlgorithLab_1;
using System.Diagnostics;

namespace AlgorithLab_1;
public class ObviousPow : IExecutable
{
    public void Execute(int n)
    {
        Pow(n);
    }

    public Func<double, double> GetComplexityFunction() => num => num;

    private static int num = 2;
    public static long Pow(int degree)
    {
        int count = 0;
        int result = 1;
        int k = 0;
        while (k < degree)
        {
            result *= num;
            k++;
            count++;
        }

        return count;
    }

    public static long Timer(int variableCount)
    {
        return TimeMaesures.Timer(variableCount, new ObviousPow());
    }
}

public class RecPow : IExecutable
{
    public void Execute(int n)
    {
        Pow(n);
    }

    public Func<double, double> GetComplexityFunction() => num => num;

    private static int count = 0;
    private static int num = 2;
    public static long Pow(int degree)
    {
        if (degree == 0)
        {
            count++;
            return 1;
        }
        else
        {
            count++;
            long result = Pow(degree / 2);
            count++;

            if (degree % 2 == 1)
            {
                result = result * result * num;
            }
            else
            {
                result *= result;
            }

            return count;
        }
    }

    public static long Timer(int variableCount)
    {
        return TimeMaesures.Timer(variableCount, new RecPow());
    }
}

public class QuickPow : IExecutable
{
    public void Execute(int n)
    {
        Pow(n);
    }

    public Func<double, double> GetComplexityFunction() => num => Math.Log2(num);

    private static int num = 2;
    public static long Pow(int degree)
    {
        int count = 0;
        int c = num;
        int k = degree;
        int result;
        count++;

        if (k % 2 == 1)
        {
            result = c;
        }
        else
        {
            result = 1;
        }

        do
        {
            count++;
            k /= 2;
            c *= c;

            if (k % 2 == 1)
            {
                result *= c;
            }

        }
        while (k != 0);

        return count;
    }

    public static long Timer(int variableCount)
    {
        return TimeMaesures.Timer(variableCount, new QuickPow());
    }
}

public class ClassicQuickPow : IExecutable
{
    public void Execute(int n)
    {
        Pow(n);
    }

    public Func<double, double> GetComplexityFunction() => num => Math.Log2(num);

    private static int num = 2;
    public static long Pow(int degree)
    {
        int count = 0;
        int c = num;
        int result = 1;
        int k = degree;
        count++;

        while (k != 0)
        {
            count++;
            if (k % 2 == 0)
            {
                c *= c;
                k /= 2;
            }
            else
            {
                result *= c;
                k--;
            }
        }

        return count;
    }

    public static long Timer(int variableCount)
    {
        return TimeMaesures.Timer(variableCount, new ClassicQuickPow());
    }
}