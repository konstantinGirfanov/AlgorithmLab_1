using AlgorithLab_1;
using System.Diagnostics;

namespace AlgorithLab_1;
class Li : IExecutable
{
    public class Node
    {
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
        public string[,] path;
        public int minDist;
        public Path(string[,] path, int minDist)
        {
            this.path = path;
            this.minDist = minDist;
        }
    }

    private static int[,] GenerateField(int n)
    {

        var matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = 1;
            }
        }

        return matrix;
    }

    static readonly int[] Row = { -1, 0, 0, 1 };
    static readonly int[] Col = { 0, -1, 1, 0 };


    private static bool IsValid(int[,] mat, bool[,] visited, int row, int col)
    {
        return ((row >= 0 && row < mat.GetLength(0)) && (col >= 0 && col < mat.GetLength(1)))
                && mat[row, col] >= 1 && !visited[row, col];
    }

    private static Path? FindShortestPath(int[,] mat, int startX, int startY, int finishX, int finishY)
    {
        if (mat == null || mat.Length == 0 || mat[startX, startY] == 0 || mat[finishX, finishY] == 0)
        {
            return null;
        }

        bool[,] visited = new bool[mat.GetLength(0), mat.GetLength(1)];

        Queue<Node> q = new();

        visited[startX, startY] = true;
        q.Enqueue(new Node(startX, startY, 0));

        int minDist = int.MaxValue;

        while (q.Count != 0)
        {
            Node node = q.Dequeue();

            int currentX = node.x;
            int currentY = node.y;
            int dist = node.dist;

            if (currentX == finishX && currentY == finishY)
            {
                minDist = dist;
                break;
            }

            for (int k = 0; k < 4; k++)
            {

                if (IsValid(mat, visited, currentX + Row[k], currentY + Col[k]))
                {
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
                if (IsValid(mat, visited, currentX + Row[k], currentY + Col[k])
                && (dist - mat[currentX + Row[k], currentY + Col[k]] == 1))
                {
                    q.Enqueue(new Node(currentX + Row[k], currentY + Col[k], dist - 1));
                    break;
                }
            }
        }

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

    
    
    public void Execute(int n)
    {
        int[,] field = GenerateField(n);
        Random num = new();
        int startX = num.Next(0, field.GetLength(1));
        int startY = num.Next(0, field.GetLength(0));
        int finishX = num.Next(0, field.GetLength(1));
        int finishY = num.Next(0, field.GetLength(0));
        FindShortestPath(field, startX, startY, finishX, finishY);
    }
}

    public Func<double, double> GetComplexityFunction() => num => num * num;
    
    public static long Timer(int variableCount)
    {
        return TimeMesures.Timer(variableCount, new Li());
    }
}