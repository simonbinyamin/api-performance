using datascience;
using System.Globalization;

public class LatencyProgramOBSELETE
{
    public static void Mainsss(string[] args)
    {




        //CreateXY(@"C:\Users\Simon\Desktop\hej\emptyf_LatenciesOverTime.csv");
        //CreateXY(@"C:\Users\Simon\Desktop\hej\emptyc_LatenciesOverTime.csv");

        //CreateXY(@"C:\Users\Simon\Desktop\hej\getstudnsf_LatenciesOverTime.csv");
        //CreateXY(@"C:\Users\Simon\Desktop\hej\getstudentsc_LatenciesOverTime.csv");


        //CreateXY(@"C:\Users\Simon\Desktop\hej\findf_LatenciesOverTime.csv");
       // CreateXY(@"C:\Users\Simon\Desktop\hej\findc2_LatenciesOverTime.csv");


        //CreateXY(@"C:\Users\Simon\Desktop\hej\zipf2_LatenciesOverTime.csv");

        //CreateXY(@"C:\Users\Simon\Desktop\hej\zipc_LatenciesOverTime.csv");


        //CreateXY(@"C:\Users\Simon\Desktop\hej\objrctf_LatenciesOverTime.csv");
        //CreateXY(@"C:\Users\Simon\Desktop\hej\objectc2_LatenciesOverTime.csv");

        // CreateXY(@"C:\Users\Simon\Desktop\hej\serlizerf3_LatenciesOverTime.csv");
        CreateXY(@"C:\Users\Simon\Desktop\hej\studentserlizerc_LatenciesOverTime.csv");


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
                    int index = values[0].LastIndexOf(",");

                    var input = values[0].Substring(0, index);
                    metric.Elpesedtimes.Add(input);
            
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













