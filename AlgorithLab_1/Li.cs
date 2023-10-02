static class Li
{
    public class Node
    {
        // (x, y) представляет собой координаты ячейки матрицы, а
        // `dist` представляет их минимальное расстояние от источника
        public int x, y, dist;

        public Node(int x, int y, int dist)
        {
            this.x = x;
            this.y = y;
            this.dist = dist;
        }

        public static bool Contain(Node[] nodes, Node node)
        {
            foreach (Node element in nodes)
            {
                if (element.x == node.x && element.y == node.y)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Path
    {
        // класс хранит массив с помеченными элементами пути и длину этого пути
        public string[,] path;
        public int minDist;
        public Path(string[,] path, int minDist)
        {
            this.path = path;
            this.minDist = minDist;
        }
    }

    // Ниже массивы детализируют все четыре возможных перемещения из ячейки
    static readonly int[] Row = { -1, 0, 0, 1 };
    static readonly int[] Col = { 0, -1, 1, 0 };

    // Функция проверки возможности перехода на позицию (строка, столбец)
    // от текущей позиции. Функция возвращает false, если (строка, столбец)
    // недопустимая позиция или имеет значение 0 или уже посещено.
    private static bool IsValid(int[,] mat, bool[,] visited, int row, int col)
    {
        return ((row >= 0 && row < mat.GetLength(0)) && (col >= 0 && col < mat.GetLength(1)))
                && mat[row, col] >= 1 && !visited[row, col];
    }

    // Находим кратчайший маршрут в матрице `mat` из источника
    // ячейка (i, j) в ячейку назначения (x, y)
    private static Path? FindShortestPath(int[,] mat, int startX, int startY, int finishX, int finishY)
    {
        // базовый случай: неверный ввод
        if (mat == null || mat.Length == 0 || mat[startX, startY] == 0 || mat[finishX, finishY] == 0)
        {
            return null;
        }

        // создаем матрицу для отслеживания посещенных ячеек
        bool[,] visited = new bool[mat.GetLength(0), mat.GetLength(1)];

        // создаем пустую queue
        Queue<Node> q = new();

        // помечаем исходную ячейку как посещенную и ставим исходный узел в очередь
        visited[startX, startY] = true;
        q.Enqueue(new Node(startX, startY, 0));

        // сохраняет длину самого длинного пути от источника к месту назначения
        int minDist = int.MaxValue;

        // цикл до тех пор, пока queue не станет пустой
        while (q.Count != 0)
        {
            // удалить передний узел из очереди и обработать его
            Node node = q.Dequeue();

            // (i, j) представляет текущую ячейку, а `dist` хранит ее
            // минимальное расстояние от источника
            int currentX = node.x;
            int currentY = node.y;
            int dist = node.dist;

            // если пункт назначения найден, обновляем `min_dist` и останавливаемся
            if (currentX == finishX && currentY == finishY)
            {
                minDist = dist;
                break;
            }

            // проверяем все четыре возможных перемещения из текущей ячейки
            // и ставим в queue каждое допустимое движение
            for (int k = 0; k < 4; k++)
            {
                // проверяем, можно ли выйти на позицию
                // (i + row[k], j + col[k]) от текущей позиции
                if (IsValid(mat, visited, currentX + Row[k], currentY + Col[k]))
                {
                    // отметить следующую ячейку как посещенную и поставить ее в очередь
                    visited[currentX + Row[k], currentY + Col[k]] = true;
                    mat[currentX + Row[k], currentY + Col[k]] = dist + 1;
                    q.Enqueue(new Node(currentX + Row[k], currentY + Col[k], dist + 1));
                }
            }
        }

        if (minDist != int.MaxValue)
        {
            return new Path(RecoverPath(mat, finishX, finishY, startX, startY), minDist);
        }

        return null;
    }

    private static string[,] RecoverPath(int[,] mat, int currentX, int currentY, int finishX, int finishY)
    {
        bool[,] visited = new bool[mat.GetLength(0), mat.GetLength(1)];
        visited[currentX, currentY] = true;

        Queue<Node> q = new();
        q.Enqueue(new Node(currentX, currentY, mat[currentX, currentY]));

        List<Node> path = new();
        while (q.Count != 0)
        {
            Node node = q.Dequeue();

            // помещаем клетку в список всех клеток пути
            path.Add(node);

            currentX = node.x;
            currentY = node.y;
            int dist = node.dist;

            if (currentX == finishX && currentY == finishY)
            {
                break;
            }

            for (int k = 0; k < 4; k++)
            {
                //переходим в клетку, которая на 1 ближе к стартовой, и помещаем е` в очередь
                if (IsValid(mat, visited, currentX + Row[k], currentY + Col[k])
                && (dist - mat[currentX + Row[k], currentY + Col[k]] == 1))
                {
                    q.Enqueue(new Node(currentX + Row[k], currentY + Col[k], dist - 1));
                    break;
                }
            }
        }

        // Копируем исходную матрицу, заменяя клетки, являющиеся частью пути, на звёздочки
        string[,] resultMat = new string[mat.GetLength(0), mat.GetLength(1)];
        for (int i = 0; i < resultMat.GetLength(0); i++)
        {
            for (int j = 0; j < resultMat.GetLength(1); j++)
            {
                if (Node.Contain(path.ToArray(), new Node(i, j, 0)))
                {
                    resultMat[i, j] = "*";
                }
                else
                {
                    resultMat[i, j] = mat[i, j].ToString();
                }
            }
        }
        return resultMat;
    }

    // Вывод матрицы с отмеченным путём в консоль
    public static void PrintArr(string[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == "*")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(arr[i, j] + new string(' ', 5 - arr[i, j].ToCharArray().Length));
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    /*public static void Main()
    {
        int[,] mat =
        {
            { 1, 1, 1, 1, 1, 0, 0, 1, 1 },
            { 0, 1, 1, 1, 1, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1, 1, 1, 0, 0 },
            { 1, 0, 1, 1, 1, 0, 1, 1, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 1, 0 },
            { 1, 0, 1, 1, 0, 0, 0, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1, 0, 0, 1, 1 },
            { 0, 0, 1, 0, 0, 1, 1, 0, 0 },
        };

        Path? path = FindShortestPath(mat, 3, 4, 0, 0);

        if (path != null)
        {
            Console.WriteLine("The shortest path from source to destination " +
                    "has length " + path.minDist);
            PrintArr(path.path);
        }
        else
        {
            Console.WriteLine("Destination cannot be reached from source");
        }
    }*/
}