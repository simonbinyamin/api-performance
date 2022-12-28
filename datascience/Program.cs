using datascience;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {

        var core = GetMetric(@"C:\");
        var frame = GetMetric(@"C:\");

        var te = GenerateTable(core, frame);
        CreateBox(core, frame);
    }


    public static List<string> GenerateTable(Metric core, Metric frame)
    {
        List<string> table = new List<string>();

        table.Add(",Response time,stdev,95,Throughput,Received KB/sec");
        table.Add(".NET6,,,,");
        table.Add("10VUs," 
            + core.ResponseTime10.Average().ToString("0.00") +","
            + Math.Sqrt(core.ResponseTime10.Average(v => Math.Pow(v - core.ResponseTime10.Average(), 2))).ToString("0.00") + ","
            + Percentile(core.ResponseTime10, 0.95).ToString("0.00") + ","
            + core.Throughput10.Average().ToString("0.00") + ","
            + core.ReceviedKB10.Average().ToString("0.00")

            );

        return table;
    }

    public static void CreateBox(Metric? core, Metric? frame)
    {

        BoxPlotSeriesImp boxPlotSeries = new(core, frame);
        boxPlotSeries.createBoxPlot();

    }
    

    public static Metric GetMetric(string path)
    {
        using (var reader = new StreamReader(@path))
        {

            Metric metric = new();
            metric.ResponseTime10 = new();
            metric.ResponseTime100 = new();
            metric.ResponseTime1000 = new();
            metric.ResponseTime2000 = new();

            metric.Throughput10 = new();
            metric.Throughput100 = new();
            metric.Throughput1000 = new();
            metric.Throughput2000 = new();


            metric.ReceviedKB10 = new();
            metric.ReceviedKB100 = new();
            metric.ReceviedKB1000 = new();
            metric.ReceviedKB2000 = new();





            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');



                if (values[1] == "10")
                {
                    metric.ResponseTime10.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));
                    metric.Throughput10.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    metric.ReceviedKB10.Add(Double.Parse(values[11], CultureInfo.InvariantCulture));

                }
                if (values[1] == "100")
                {
                    metric.ResponseTime100.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));
                    metric.Throughput100.Add(Double.Parse(values[10], CultureInfo.InvariantCulture  ));
                    metric.ReceviedKB100.Add(Double.Parse(values[11], CultureInfo.InvariantCulture));
                }
                if (values[1] == "1000")
                {
                    metric.ResponseTime1000.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));
                    metric.Throughput1000.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    metric.ReceviedKB1000.Add(Double.Parse(values[11] , CultureInfo.InvariantCulture));
                }
                if (values[1] == "2000")
                {
                    metric.ResponseTime2000.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));
                    metric.Throughput2000.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    metric.ReceviedKB2000.Add(Double.Parse(values[11], CultureInfo.InvariantCulture));

                }
            }

            return metric;
        }
    }


    public static double Percentile(List<double> sequence, double excelPercentile)
    {
        sequence.Sort();
        int N = sequence.Count;
        double n = (N - 1) * excelPercentile + 1;


        if (n == 1d) return sequence[0];
        else if (n == N) return sequence[N - 1];
        else
        {
            int k = (int)n;
            double d = n - k;
            return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
        }
    }
}
