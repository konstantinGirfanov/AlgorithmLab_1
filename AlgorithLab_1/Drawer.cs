using MathNet.Numerics;
using ScottPlot;
using ScottPlot.DataSources;
using ScottPlot.Plottables;
using ScottPlot.TickGenerators.TimeUnits;
using System.Reflection;
using System.Reflection.Emit;

namespace AlgorithLab_1;

public class Drawer
{
    public static void Draw(string name, string pathPNG, List<Data> data)
    {
        Plot plot = new Plot();
        plot.Title(name.Replace(".Timer", "").Replace(".Pow", ""));

        foreach(Data e in data)
        {
            plot.XLabel("Размерность вектора");
            if (name == "ObviousPow.Pow" || name == "RecPow.Pow"
                || name == "QuickPow.Pow" || name == "ClassicQuickPow.Pow")
                plot.YLabel("количество операций, ед.");
            else
                plot.YLabel("время, мс");
            
            MethodInfo methodInfo = e.Type.GetMethod("GetComplexityFunction", Type.EmptyTypes);
            object instance = Activator.CreateInstance(e.Type);
            Func<double, double> f = Fit.LinearCombinationFunc(
                e.XValues.GetRange(0, e.XValues.Count - 1).ToArray(),
            e.YValues.GetRange(0, e.YValues.Count - 1).ToArray(),
                (Func<double, double>)methodInfo.Invoke(instance, null));

            plot.Add.Scatter(e.XValues, e.YValues, GetRandomColor());
            plot.Add.Scatter(e.XValues, e.YValues, GetRandomColor()).Label = e.Name.Replace(".Timer", "");
            plot.Add.Scatter(e.XValues, e.XValues.Select(x => f(x)).ToArray(), Colors.Red);
            plot.Legend();
        }

        plot.SavePng(pathPNG + "\\" + name + "Measures.png", 1000, 1000);
    }

    private static Color GetRandomColor()
    {
        Random rnd = new();
        return new Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
    }
}