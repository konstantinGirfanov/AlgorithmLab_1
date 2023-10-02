namespace AlgorithLab_1;

public class SieveEratosphenes
{
    static List<int> SieveEratosthenes(int n)
    {
        // Создание я думаю влияет на время работы, поэтому надо вынести из метода
        var numbers = Enumerable.Range(1, n - 1).ToList();

        for (var i = 0; i < numbers.Count; i++)
        {
            for (var j = 2; j < n; j++)
            {
                numbers.Remove(numbers[i] * j);
            }
        }

        return numbers;
    }
}