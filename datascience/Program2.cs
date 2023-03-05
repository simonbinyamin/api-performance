using datascience;
using System.Globalization;

public class Program2
{
    public static void Main(string[] args)
    {



     
        CreateXY(@"C:\Users\Simon\Desktop\hej\emptyf_LatenciesOverTime.csv");




    }


   



    public static void CreateXY(string path)
    {
        XYMetric metric = new XYMetric();
        metric.Elpesedtimes = new List<string>();
        metric.VUs10 = new List<double>();
        metric.VUs100 = new List<double>();
        metric.VUs1000 = new List<double>();
        metric.VUs2000 = new List<double>();


        using (var reader = new StreamReader(@path))
        {

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');


                if (values[0] == "Elapsed time")
                {
                    continue;
                }

                if (!String.IsNullOrEmpty(values[0]))
                {

                    metric.Elpesedtimes.Add(values[0]);
            
                }
                if (!String.IsNullOrEmpty(values[1]))
                {

                    metric.VUs1000.Add(Double.Parse(values[1], CultureInfo.InvariantCulture));

                }
                if (!String.IsNullOrEmpty(values[2]))
                {

                    metric.VUs100.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));

                }
                if (!String.IsNullOrEmpty(values[3]))
                {

                    metric.VUs10.Add(Double.Parse(values[3], CultureInfo.InvariantCulture));

                }

                if (!String.IsNullOrEmpty(values[4]))
                {

                    metric.VUs2000.Add(Double.Parse(values[4], CultureInfo.InvariantCulture));

                }

            }

        }


        XYSeriesImp XYPlotSeries = new(metric);
        XYPlotSeries.createBoxPlot();

    }

}













