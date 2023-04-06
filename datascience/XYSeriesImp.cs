﻿using System;
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

            var model = new PlotModel { };









            var barSeries10 = new BarSeries(){IsStacked = true,StrokeThickness = 1,StrokeColor = OxyColors.DarkRed};
            var barSeries100 = new BarSeries() { IsStacked = true, StrokeThickness = 1, StrokeColor = OxyColors.SkyBlue };
            var barSeries1000 = new BarSeries() { IsStacked = true, StrokeThickness = 1, StrokeColor = OxyColors.Red };
            var barSeries2000 = new BarSeries() { IsStacked = true, StrokeThickness = 1, StrokeColor = OxyColors.Blue };






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
                //empty
                MajorStep = _metric.Elpesedtimes.Count/16,
                //MinorStep = 250,
                
                //AbsoluteMaximum = _metric.Elpesedtimes.Count+500,
               // Maximum = _metric.Elpesedtimes.Count+500,
                //Minimum = 1-10,

                Title = "Elapsed time",
               AxisTitleDistance = 70,
                FontSize = 30,
                TickStyle = TickStyle.None,
                Position = AxisPosition.Left,
                Key = "CakeAxis",
                ItemsSource = _metric.Elpesedtimes.ToArray(),
                
                //MaximumDataMargin = _metric.Elpesedtimes.Count - (_metric.Elpesedtimes.Count-550),
                //  Maximum = _metric.Elpesedtimes.Count - 550,
                //MaximumRange = _metric.Elpesedtimes.Count-100
               // Maximum = 2000

            }) ;
            model.Axes.Add(new LinearAxis
            {

                Position = AxisPosition.Bottom,

              
                Title = "Latency (ms)",
                TickStyle = TickStyle.None,
                FontSize = 30,
                AxisTitleDistance = 40,
                //empty
                //AbsoluteMaximum = 500,
                //Maximum = 450,
                //MajorStep = 60,

                //getst
                //MajorStep = 120,
                //AbsoluteMaximum = 1000,
                //Maximum = 900,
                //find
                //MajorStep = 80,
                //AbsoluteMaximum = 700,
                //Maximum = 600,
                //zip
                //MajorStep = 140,
                //AbsoluteMaximum = 1200,
                //Maximum = 1100,
                //object
                //MajorStep = 112,
                //AbsoluteMaximum = 950,
                //Maximum = 850,

                //ser
                MajorStep = 154,
                AbsoluteMaximum = 1300,
                Maximum = 1200,
                AbsoluteMinimum = 0,




            });


            model.Legends.Add(new Legend()
            {
             

               

                LegendFontSize = 30,
                //LegendMargin = -65,
                //LegendPadding = 65,
                LegendLineSpacing = 4,
                LegendPosition = LegendPosition.BottomRight,
                //LegendBackground = OxyColors.Black
                //LegendPlacement = LegendPlacement.Outside,
                
            });


            model.Series.Add(new LineSeries
            {


                Color = OxyColors.DarkRed,
                Title = "10VU  ",
    
            });

            model.Series.Add(new LineSeries
            {

                Color = OxyColors.SkyBlue,
                Title = "100VU  ",

            });


            model.Series.Add(new LineSeries
            {


                Color = OxyColors.Red,
                Title = "1000VU s  ",
      
            });

            model.Series.Add(new LineSeries
            {

                Color = OxyColors.Blue,
                Title = "2000VU s  ",

            });





            string svgString;
            using (var stremPieChart = new MemoryStream())
            {
                var exporter = new OxyPlot.SvgExporter
                {
                    Width = 800,
                    Height = 800,
                    UseVerticalTextAlignmentWorkaround = true
                };
                // CHANGE HERE!
                svgString = exporter.ExportToString(model);

                //test

                var t = svgString.Replace(@"\", "");
                //Console.WriteLine(t);


                 File.WriteAllText(@"C:\Users\Simon\Desktop\hej\serlizerc.svg", t);

            }


            return model;
        }



    


    }
}
