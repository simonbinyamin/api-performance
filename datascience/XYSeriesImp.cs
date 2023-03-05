using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace datascience
{


    public class XYSeriesImp
    {
        XYMetric _metric;



        public XYSeriesImp(XYMetric metric)
        {
            _metric = metric;


        }


        public PlotModel createBoxPlot()
        {

            var model = new PlotModel { Title = "Cake Type Popularity" };









            var barSeries10 = new BarSeries(){IsStacked = true,StrokeThickness = 1,StrokeColor = OxyColors.Blue};
            var barSeries100 = new BarSeries() { IsStacked = true, StrokeThickness = 1, StrokeColor = OxyColors.Red };
            var barSeries1000 = new BarSeries() { IsStacked = true, StrokeThickness = 1, StrokeColor = OxyColors.Purple };
            var barSeries2000 = new BarSeries() { IsStacked = true, StrokeThickness = 1, StrokeColor = OxyColors.DarkRed };






            List<BarItem> barItems10 = new List<BarItem>();
            List<BarItem> barItems100 = new List<BarItem>();
            List<BarItem> barItems1000 = new List<BarItem>();
            List<BarItem> barItems2000 = new List<BarItem>();

            int cin = 0;
            foreach (var item in _metric.VUs10)
            {
                barItems10.Add(new BarItem { Value = item, CategoryIndex = cin});
                cin++;
            }

            foreach (var item in _metric.VUs100)
            {
                barItems100.Add(new BarItem { Value = item, CategoryIndex = cin });
                cin++;
            }


            foreach (var item in _metric.VUs1000)
            {
                barItems1000.Add(new BarItem { Value = item, CategoryIndex = cin });
                cin++;
            }



            foreach (var item in _metric.VUs2000)
            {
                barItems2000.Add(new BarItem { Value = item, CategoryIndex = cin });
                cin++;
            }



            barSeries10.ItemsSource = new List<BarItem>(barItems10);
            barSeries100.ItemsSource = new List<BarItem>(barItems100);
            barSeries1000.ItemsSource = new List<BarItem>(barItems1000);
            barSeries2000.ItemsSource = new List<BarItem>(barItems2000);


            
            model.Series.Add(barSeries10);
            model.Series.Add(barSeries100);
            model.Series.Add(barSeries1000);
            model.Series.Add(barSeries2000);

            model.Axes.Add(new CategoryAxis
            {
                MajorStep = 1000,
             
              

                 //MinorStep = 100,
                Title = "Elapsed time",
                AxisTitleDistance = 16,
                FontSize = 20,
                TickStyle = TickStyle.Crossing,
                Position = AxisPosition.Left,
                Key = "CakeAxis",
                 ItemsSource = _metric.Elpesedtimes.ToArray()

            });
            model.Axes.Add(new LinearAxis
            {

                Position = AxisPosition.Bottom,
                Title = "Request handling capability",
                TickStyle = TickStyle.None,
                FontSize = 20,
                AxisTitleDistance = 16,
                AbsoluteMaximum = 400,
                AbsoluteMinimum = 0,




            });


            model.Legends.Add(new Legend()
            {
                LegendMargin = -45,
                LegendPadding = 45,
                LegendLineSpacing = 6,
                LegendPosition = LegendPosition.TopCenter,
            });


            model.Series.Add(new LineSeries
            {


                Color = OxyColors.Blue,
                Title = ".NET Framework 4.8"
            });

            model.Series.Add(new LineSeries
            {

                Color = OxyColors.Red,
                Title = ".NET 6"
            });







            string svgString;
            using (var stremPieChart = new MemoryStream())
            {
                var exporter = new OxyPlot.SvgExporter
                {
                    //Width = 800,
                    //Height = 800,
                    UseVerticalTextAlignmentWorkaround = true
                };
                // CHANGE HERE!
                svgString = exporter.ExportToString(model);

                //test

                var t = svgString.Replace(@"\", "");
                //Console.WriteLine(t);


                 File.WriteAllText(@"C:\Users\Simon\Desktop\hej\emptyf.svg", t);

            }


            return model;
        }



    


    }
}
