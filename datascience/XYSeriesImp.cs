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





            var barSeries = new BarSeries() {
            
            IsStacked = true,
                StrokeThickness = 1,
                
            };

            //barSeries.ItemsSource = new List<BarItem>(new[]
            //        {
            //            new BarItem{ Value = 1,Color= OxyColor.FromArgb(50, 0, 0, 0)},
            //            new BarItem{ Value = 2,Color= OxyColor.FromArgb(50, 0, 0, 0) },
            //            new BarItem{ Value = 1,Color= OxyColor.FromArgb(50, 0, 0, 0) },

            //            new BarItem{ Value = 2,Color= OxyColor.FromArgb(100, 2, 0, 0)},
            //            new BarItem{ Value = 3,Color= OxyColor.FromArgb(100, 2, 0, 0) },
            //            new BarItem{ Value = 2,Color= OxyColor.FromArgb(100, 2, 0, 0) },

            //        });


            List<BarItem> barItems = new List<BarItem>();
            foreach (var item in _metric.VUs10)
            {
                barItems.Add(new BarItem { Value = item, Color = OxyColor.FromArgb(50, 0, 0, 0) });
            }

            foreach (var item in _metric.VUs100)
            {
                barItems.Add(new BarItem { Value = item, Color = OxyColor.FromArgb(50, 0, 0, 0) });
            }

            foreach (var item in _metric.VUs1000)
            {
                barItems.Add(new BarItem { Value = item, Color = OxyColor.FromArgb(50, 0, 0, 0) });
            }

            foreach (var item in _metric.VUs2000)
            {
                barItems.Add(new BarItem { Value = item, Color = OxyColor.FromArgb(50, 0, 0, 0) });
            }



            barSeries.ItemsSource = new List<BarItem>(barItems);



           // barSeries.LabelPlacement = LabelPlacement.Inside;

 





            model.Series.Add(barSeries);



            model.Axes.Add(new CategoryAxis
            {
                MajorStep = 1000,
             
              

                 //MinorStep = 100,
                Title = "Response time (ms)",
                AxisTitleDistance = 16,
                TickStyle = TickStyle.Crossing,
                Position = AxisPosition.Left,
                Key = "CakeAxis",
                 ItemsSource = _metric.Elpesedtimes.ToArray()

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
