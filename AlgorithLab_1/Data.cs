namespace AlgorithLab_1
{
    public class Data
    {
        public List<double> XValues;
        public List<double> YValues;
        public string Name;
        public Type Type;
        public Data(List<double> xValues, List<double> yValues, string name, Type type)
        {
            XValues = xValues;
            YValues = yValues;
            Name = name;
            Type = type;
        }
    }
}
