using MathNet.Numerics;
using ScottPlot;

namespace AlgorithLab_1;

public class Drawer
{
    public static void Draw(List<double> dataX, List<double> dataY, string name, string pathPNG, IExecutable executable)
    {
        Plot plot = new Plot();
        plot.Title(name);
        Func<double, double> f = Fit.LinearCombinationFunc(
            dataX.GetRange(0, dataX.Count - 1).ToArray(),
            dataY.GetRange(0, dataY.Count - 1).ToArray(),
            executable.GetComplexityFunction());

        plot.Add.Scatter(dataX, dataY, Colors.Aqua);
        plot.Add.Scatter(dataX, dataX.Select(x => f(x)).ToArray(), Colors.Red);
        plot.SavePng(pathPNG, 1000, 1000);
    }
}