namespace AlgorithLab_1
{
    using System;
    using System.Diagnostics;

    class TSort : IExecutable
    {
        public const int RUN = 32;

        public void Execute(int n)
        {
            int[] randomArray = Program.RandomArray(n);
            TimSort(randomArray, n);
        }

        public Func<double, double> GetComplexityFunction() => num => num * Math.Log2(num);
       
        public static void InsertionSort(int[] arr, int left,
                                         int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

       
        public static void Merge(int[] arr, int l, int m, int r)
        {
           
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

           
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        
        public static void TimSort(int[] arr, int n)
        {

           
            for (int i = 0; i < n; i += RUN)
                InsertionSort(arr, i,
                              Math.Min((i + RUN - 1), (n - 1)));

           
            for (int size = RUN; size < n; size = 2 * size)
            {

               
                for (int left = 0; left < n; left += 2 * size)
                {

                    
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1),
                                         (n - 1));

                   
                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
        }

       

        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new TSort());
        }

       
    }
}
