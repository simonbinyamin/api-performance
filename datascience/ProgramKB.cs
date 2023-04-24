using datascience;
using datascience.ttest;
using System.Globalization;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
public class ProgramKB
{
    public static void Mainsss(string[] args)
    {




        //var frame = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\Empty_BytesThroughputOverTime.csv");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\EmptyCore_BytesThroughputOverTime.csv");



        //var frame = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\getstudnsf1frame_BytesThroughputOverTime - Sheet1.csv");
        //var core = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\getstudns1Core_BytesThroughputOverTime - Sheet1.csv");


        //var frame = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\find1frame_BytesThroughputOverTime - Sheet1.csv");
        //var core = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\find1core_BytesThroughputOverTime - Sheet1.csv");


        //var frame = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\zip1Frame_BytesThroughputOverTime - Sheet1.csv");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\zip1Core_BytesThroughputOverTime - Sheet1.csv");


        var frame = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\Object1Frame_BytesThroughputOverTime - Sheet1.csv");
        var core = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\Object1Core_BytesThroughputOverTime - Sheet1.csv");


        //var frame = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\serlizer1Frame_BytesThroughputOverTime - Sheet1.csv");
        //var core = GetMetric(@"C:\Users\Simon\Desktop\hej\bytes\serlizer1core_BytesThroughputOverTime - Sheet1.csv");








        CreateBox(core, frame);




    }



    public static void CreateBox(Metric? core, Metric? frame)
    {

        BoxPlotSeriesImp2 boxPlotSeries = new(core, frame);
        boxPlotSeries.createBoxPlot();

    }





    public static Metric GetMetric(string path)
    {
        using (var reader = new StreamReader(@path))
        {

            Metric metric = new();
            metric.Latency10 = new();
            metric.Latency100 = new();
            metric.Latency1000 = new();
            metric.Latency2000 = new();

            metric.Throughput10 = new();
            metric.Throughput100 = new();
            metric.Throughput1000 = new();
            metric.Throughput2000 = new();


            metric.ReceviedKB10 = new();
            metric.ReceviedKB100 = new();
            metric.ReceviedKB1000 = new();
            metric.ReceviedKB2000 = new();

            metric.ResponseTime10 = new();
            metric.ResponseTime100 = new();
            metric.ResponseTime1000 = new();
            metric.ResponseTime2000 = new();



            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

  

                if (values[1] == "10VUs")
                {
                    continue;
                }

                if (!String.IsNullOrEmpty(values[1]))
                {
                    metric.ReceviedKB10.Add(Double.Parse(values[1], CultureInfo.InvariantCulture));

                }

                if (!String.IsNullOrEmpty(values[2]))
                {
                    metric.ReceviedKB100.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));

                }

                if (!String.IsNullOrEmpty(values[3]))
                {
                    metric.ReceviedKB1000.Add(Double.Parse(values[3], CultureInfo.InvariantCulture));

                }

                if (!String.IsNullOrEmpty(values[4]))
                {
                    metric.ReceviedKB2000.Add(Double.Parse(values[4], CultureInfo.InvariantCulture));

                }

            }



            return metric;
        }
    }

   



   
}





internal class BoxPlotSeriesImp2
{
    Metric? _core;
    Metric? _frame;

    public BoxPlotSeriesImp2(Metric? core, Metric? frame)
    {
        _core = core;
        _frame = frame;
    }



    public static BoxPlotSeries s1 = new BoxPlotSeries();
    public static BoxPlotSeries s2 = new BoxPlotSeries();
    public PlotModel createBoxPlot()
    {

        var plot = new PlotModel();


        plot.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Left,
            // MajorStep = 25,
            //MajorStep = 1000000,
            //MinorStep = 500000,


            MajorStep = 100000,
            MinorStep = 50000,
            // MinorStep = 4,
            Title = "Bytes/second",
            AxisTitleDistance = 32,
            TickStyle = TickStyle.Crossing,

            ////empty
            //Maximum = 7500,
            //AbsoluteMaximum = 6500,
            //AbsoluteMinimum = 0,


            ////zip
            //AbsoluteMaximum = 56,
            //AbsoluteMinimum = 0,
            //Minimum = 0,

            //////find
            //Maximum = 9000,

            //AbsoluteMaximum = 9.5,
            //AbsoluteMinimum = 0,



            ////getstudent
            //Maximum = 14000,
            //AbsoluteMaximum = 13000,
            //AbsoluteMinimum = 0,
            //Minimum = 0,

            //obj
            Maximum = 500000,
            AbsoluteMaximum = 400000,



            //serlizer

            //Maximum = 3000000,
            //AbsoluteMaximum = 2800000,

            Minimum = 0,

        });

        plot.Axes.Add(new CategoryAxis
        {
            //Position = AxisPosition.Bottom,
            Title = "VUs",
            IsTickCentered = true,
            TickStyle = TickStyle.None,
            AbsoluteMinimum = -1,
            AbsoluteMaximum = 17,
            IsZoomEnabled = false,
            AxisTitleDistance = 16,

            LabelField = "LabelChannels",
            Labels =
            {   "",
                "10",
                "",
                "100",
                "",
                "1000",
                "",
                "2000",
            }

        });

        var lineAnnotation = new LineAnnotation
        {
            Type = LineAnnotationType.Horizontal,
            Y = 5,
            LineStyle = LineStyle.None,
            StrokeThickness = 2,
            Color = OxyColor.FromArgb(50, 0, 0, 0)
        };
        plot.Annotations.Add(lineAnnotation);

        lineAnnotation = new LineAnnotation
        {
            Type = LineAnnotationType.Horizontal,
            Y = 1,
            LineStyle = LineStyle.None,
            StrokeThickness = 1.5,
            Color = OxyColor.FromArgb(50, 0, 0, 0)
        };
        plot.Annotations.Add(lineAnnotation);

        lineAnnotation = new LineAnnotation
        {
            Type = LineAnnotationType.Horizontal,
            Y = 4,
            LineStyle = LineStyle.None,
            StrokeThickness = 1.5,
            Color = OxyColor.FromArgb(50, 0, 0, 0)
        };
        plot.Annotations.Add(lineAnnotation);

        lineAnnotation = new LineAnnotation
        {
            Type = LineAnnotationType.Horizontal,
            Y = 2,
            LineStyle = LineStyle.None,
            StrokeThickness = 1.5,
            Color = OxyColor.FromArgb(50, 0, 0, 0)
        };
        plot.Annotations.Add(lineAnnotation);



        GetBar(0, _frame.ReceviedKB10, "blue");
        GetBar(1, _core.ReceviedKB10, "red");

        GetBar(2, _frame.ReceviedKB100, "blue");
        GetBar(3, _core.ReceviedKB100, "red");

        GetBar(4, _frame.ReceviedKB1000, "blue");
        GetBar(5, _core.ReceviedKB1000, "red");

        GetBar(6, _frame.ReceviedKB2000, "blue");
        GetBar(7, _core.ReceviedKB2000, "red");







        plot.Legends.Add(new Legend()
        {
            LegendMargin = -45,
            LegendPadding = 45,
            LegendLineSpacing = 6,
            LegendPosition = LegendPosition.TopCenter,
        });


        plot.Series.Add(new LineSeries
        {


            Color = OxyColors.Blue,
            Title = ".NET Framework 4.8"
        });

        plot.Series.Add(new LineSeries
        {

            Color = OxyColors.Red,
            Title = ".NET 6"
        });

        plot.Series.Add(new LineSeries
        {
            StrokeThickness = 1.1,
            LineStyle = LineStyle.Dash,
            Title = "Mean"
        });

        plot.Series.Add(s1);
        plot.Series.Add(s2);






        string svgString;
        using (var stremPieChart = new MemoryStream())
        {
            var exporter = new OxyPlot.SvgExporter
            {

                Width = 400,
                Height = 300,
                UseVerticalTextAlignmentWorkaround = true
            };
            // CHANGE HERE!
            svgString = exporter.ExportToString(plot);

            //test

            var t = svgString.Replace(@"\", "");
            //Console.WriteLine(t);

            File.WriteAllText(@"C:\Users\Simon\Desktop\2022-12-22new\graph\find.svg", t);

        }


        return plot;
    }



    private static void GetBar(int place, List<double> values, string color)
    {





        values.Sort();
        var median = getMedian(values);
        var mean = values.Average();
        int r = values.Count % 2;
        double firstQuartil = getMedian(values.Take((values.Count + r) / 2)); // 25%-Quartil
        double thirdQuartil = getMedian(values.Skip((values.Count - r) / 2)); // 75%-Quartil

        var iqr = thirdQuartil - firstQuartil; // Quartilabstand
        var step = 1.5 * iqr;
        var upperWhisker = thirdQuartil + step;
        upperWhisker = values.Where(v => v <= upperWhisker).Max();
        var lowerWhisker = firstQuartil - step;
        lowerWhisker = values.Where(v => v >= lowerWhisker).Min();
        var outliers = values.Where(v => v > upperWhisker || v < lowerWhisker).ToList();


        if (color == "blue")
        {
            s1.StrokeThickness = 1.1;
            s1.WhiskerWidth = 1;

           // s1.Fill = OxyColor.FromRgb(0, 98, 255).ChangeIntensity(0.7);

            s1.Stroke = OxyColor.FromRgb(0, 98, 255);




            s1.OutlierType = MarkerType.Plus;
            s1.OutlierSize = 2;


            s1.Items.Add(new BoxPlotItem(place, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker) { Mean = mean, Outliers = outliers });

        }
        else if (color == "red")
        {

            s2.StrokeThickness = 1.1;
            s2.WhiskerWidth = 1;


            //s2.Fill = OxyColor.FromRgb(255, 8, 0).ChangeIntensity(0.9);

            s2.Stroke = OxyColor.FromRgb(255, 8, 0);


            s2.OutlierType = MarkerType.Plus;


            s2.OutlierSize = 2;

            s2.Items.Add(new BoxPlotItem(place, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker) { Mean = mean, Outliers = outliers });
        }






    }
    private static double getMedian(IEnumerable<double> values)
    {
        var sortedInterval = new List<double>(values);
        sortedInterval.Sort();
        var count = sortedInterval.Count;
        if (count % 2 == 1)
        {
            return sortedInterval[(count - 1) / 2];
        }

        return 0.5 * sortedInterval[count / 2] + 0.5 * sortedInterval[(count / 2) - 1];
    }


}






