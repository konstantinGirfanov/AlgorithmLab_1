using AlgorithLab_1;
using System.Diagnostics;

class Pow
{
    private static int count = 0;

    public static int ObviousPow(int num, int degree)
    {
        count = 0;
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

    public static int RecPow(int num, int degree)
    {
        count = 0;
        if (degree == 0)
        {
            count++;
            return 1;
        }
        else
        {
            int result = RecPow(num, degree / 2);

            if (degree % 2 == 1)
            {
                count++;
                result = result * result * num;
            }
            else
            {
                count++;
                result *= result;
            }

            return count;
        }
    }

    public static int QuickPow(int num, int degree)
    {
        count = 0;
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

    public static int ClassicQuickPow(int num, int degree)
    {
        count = 0;
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
}