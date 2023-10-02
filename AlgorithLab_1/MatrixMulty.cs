class MultiplyMatrix
{
    public static int[,] GenerateMatrix(int n)
    {
        Random randomNum = new();

        var matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = randomNum.Next();
            }
        }

        return matrix;
    }

    public static void Multiply(int[,] first, int[,] second, int n)
    {
        int[,] result = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for(int k = 0; k < n; k++)
                {
                    result[i, j] = first[i, k] * second[k, j];
                }
            }
        }
    }
}