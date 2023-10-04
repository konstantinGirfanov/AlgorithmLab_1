namespace AlgorithLab_1;

public interface IExecutable
{
    public void Execute(int n);
    public Func<double, double> GetComplexityFunction();
}