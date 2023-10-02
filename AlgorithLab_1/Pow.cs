class Pow
{
    public static int ObviousPow(int num, int degree)
    {
        int result = 1;
        int k = 0;

        while (k < degree)
        {
            result *= num;
            k++;
        }

        return result;
    }

    public static int RecPow(int num, int degree)
    {
        if (degree == 0)
        {
            return 1;
        }
        else
        {
            int result = RecPow(num, degree / 2);

            if (degree % 2 == 1)
            {
                result = result * result * num;
            }
            else
            {
                result *= result;
            }

            return result;
        }
    }

    public static int QuickPow(int num, int degree)
    {
        int c = num;
        int k = degree;
        int result;

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
            k /= 2;
            c *= c;

            if (k % 2 == 1)
            {
                result *= c;
            }

        }
        while (k != 0);

        return result;
    }

    public static int ClassicQuickPow(int num, int degree)
    {
        int c = num;
        int result = 1;
        int k = degree;

        while (k != 0)
        {
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

        return result;
    }
}