using ScottPlot;

namespace AlgorithLab_1;

public class Drawer
{
    public static void Draw(List<double> dataX, List<double> dataY, string name, string pathPNG)
    {
        Plot plot = new Plot();
        plot.Title(name);

        plot.Add.Scatter(dataX, dataY, Colors.Aqua);
        plot.SavePng(pathPNG, 1000, 1000);
    }
}