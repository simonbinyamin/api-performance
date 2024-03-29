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


    public class BoxPlotSeriesImp
    {
        Metric? _core;
        Metric? _frame;

        public BoxPlotSeriesImp(Metric? core, Metric? frame)
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
                MajorStep = 1,
                MinorStep = 0.25,
                Title = "Response time (ms)",
                AxisTitleDistance = 16,
                TickStyle = TickStyle.Crossing,
                AbsoluteMaximum = 5.75,
                AbsoluteMinimum = -0.25,

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
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            }

            });

            var lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 5,
                LineStyle = LineStyle.Dash,
                StrokeThickness = 2,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);

            lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 1,
                LineStyle = LineStyle.Dash,
                StrokeThickness = 1.5,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);

            lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 4,
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1.5,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);

            lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 2,
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1.5,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);






            GetBar(0, _frame.ResponseTime10, "blue");
            GetBar(1, _core.ResponseTime10, "red");

            GetBar(2, _frame.ResponseTime100, "blue");
            GetBar(3, _core.ResponseTime100, "red");

            GetBar(4, _frame.ResponseTime1000, "blue");
            GetBar(5, _core.ResponseTime1000, "red");

            GetBar(6, _frame.ResponseTime2000, "blue");
            GetBar(7, _core.ResponseTime2000, "red");




            plot.Legends.Add(new Legend()
            {
                LegendMargin = -45,
                LegendPadding = 45,
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
                Console.WriteLine(t);

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

                s1.Fill = OxyColor.FromRgb(0, 98, 255);
                s1.Items.Add(new BoxPlotItem(place, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker) { Mean = mean, Outliers = outliers, Tag = "s" });

            }
            else if (color == "red")
            {

                s2.StrokeThickness = 1.1;
                s2.WhiskerWidth = 1;


                s2.Fill = OxyColor.FromRgb(255, 8, 0);

                s2.Items.Add(new BoxPlotItem(place, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker) { Mean = mean, Outliers = outliers, Tag = "s" });
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
}
