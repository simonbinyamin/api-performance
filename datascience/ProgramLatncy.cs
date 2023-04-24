using datascience;
using datascience.ttest;
using System.Globalization;

public class ProgramLatncy
{
    public static void Mainjjj(string[] args)
    {

        //var frame = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\emptyf.jtl");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\emptyc.jtl");


        var frame99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\emptyf.jtl", 0.99);

        var core99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\emptyc.jtl", 0.99);


        //var frame = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\findf.jtl");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\findc2.jtl");




        //var frame99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\findf.jtl", 0.99);

        //var core99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\findc2.jtl", 0.99);




        //var frame = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\getstudnsf.jtl");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\getstudentsc.jtl");



        //var frame99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\getstudnsf.jtl", 0.99);

        //var core99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\getstudentsc.jtl", 0.99);



        //var frame = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\zipf2.jtl");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\zipc.jtl");







        //var frame99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\zipf2.jtl", 0.99);

        //var core99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\zipc.jtl", 0.99);



        //var frame = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\objrctf.jtl");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\objectc2.jtl");






        //var frame99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\objrctf.jtl", 0.99);

        //var core99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\objectc2.jtl", 0.99);





        //var frame = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\studentserlizerf3.jtl");

        //var core = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\studentserlizerc.jtl");

        //ttest.doCalc(core.Latency10.ToArray(), frame.Latency10.ToArray(), "Serializer 10VUs");
        //ttest.doCalc(core.Latency100.ToArray(), frame.Latency100.ToArray(), "Serializer 100VUs");
        //ttest.doCalc(core.Latency1000.ToArray(), frame.Latency1000.ToArray(), "Serializer 1000VUs");
        //ttest.doCalc(core.Latency2000.ToArray(), frame.Latency2000.ToArray(), "Serializer 2000VUs");



        //var frame99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\studentserlizerf3.jtl", 0.99);

        //var core99 = GetMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\studentserlizerc.jtl", 0.99);










        //var te = GenerateTable(core, frame, core99, frame99, 0.99);
        //var result = "";

        //foreach (var item in te)
        //{
        //    result += item + Environment.NewLine;
        //}


        //File.WriteAllText(@"C:\Users\Simon\Desktop\2022-12-22new\core\output\pf.csv", result);


        CreateBox(core99, frame99);




    }


    public static List<string> GenerateTable(Metric core, Metric frame, Metric core95, Metric frame95, double pntile)
    {
        List<string> table = new List<string>();

        table.Add(", Latency,stdev,95% percentile,95% latency, 95% stdev");
        table.Add(".NET6,,,,");
        table.Add("10VUs," 
            + core.Latency10.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +","
            + Math.Sqrt(core.Latency10.Average(v => Math.Pow(v - core.Latency10.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
            + Percentile(core.Latency10, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","

            + core95.Latency10.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
            + Math.Sqrt(core95.Latency10.Average(v => Math.Pow(v - core95.Latency10.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)


            );


        table.Add("100VUs,"
        + core.Latency100.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(core.Latency100.Average(v => Math.Pow(v - core.Latency100.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Percentile(core.Latency100, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","

                + core95.Latency100.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(core95.Latency100.Average(v => Math.Pow(v - core95.Latency100.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)


        );


        table.Add("1000VUs,"
        + core.Latency1000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(core.Latency1000.Average(v => Math.Pow(v - core.Latency1000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        
        + Percentile(core.Latency1000, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
                + (core95.Latency1000.Count ==0?"N/A": core95.Latency1000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)) + ","
        + (core95.Latency1000.Count == 0? "N/A": Math.Sqrt(core95.Latency1000.Average(v => Math.Pow(v - core95.Latency1000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))



        );

        table.Add("2000VUs,"
        + core.Latency2000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(core.Latency2000.Average(v => Math.Pow(v - core.Latency2000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        
        + Percentile(core.Latency2000, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
               + (core95.Latency2000.Count==0?"N/A": core95.Latency2000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)) + ","
        + (core95.Latency2000.Count==0?"N/A": Math.Sqrt(core95.Latency2000.Average(v => Math.Pow(v - core95.Latency2000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))




        );

        table.Add(".NET Framework 4.8,,,,");

        table.Add("10VUs,"
        + frame.Latency10.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame.Latency10.Average(v => Math.Pow(v - frame.Latency10.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        
        + Percentile(frame.Latency10, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
              + frame95.Latency10.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame95.Latency10.Average(v => Math.Pow(v - frame95.Latency10.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)


        );


        table.Add("100VUs,"
        + frame.Latency100.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame.Latency100.Average(v => Math.Pow(v - frame.Latency100.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        
        + Percentile(frame.Latency100, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
                + (frame95.Latency100.Count==0?"N/A": frame95.Latency100.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)) + ","
        + (frame95.Latency100.Count==0?"N/A": Math.Sqrt(frame95.Latency100.Average(v => Math.Pow(v - frame95.Latency100.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))



        );


        table.Add("1000VUs,"
        + frame.Latency1000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame.Latency1000.Average(v => Math.Pow(v - frame.Latency1000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
       
        + Percentile(frame.Latency1000, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
               + frame95.Latency1000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame95.Latency1000.Average(v => Math.Pow(v - frame95.Latency1000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)

 

        );

        table.Add("2000VUs,"
        + frame.Latency2000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame.Latency2000.Average(v => Math.Pow(v - frame.Latency2000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
       
        + Percentile(frame.Latency2000, pntile).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","

                + frame95.Latency2000.Average().ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ","
        + Math.Sqrt(frame95.Latency2000.Average(v => Math.Pow(v - frame95.Latency2000.Average(), 2))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)



        );
        return table;


    }

    public static void CreateBox(Metric? core, Metric? frame)
    {

        BoxPlotSeriesImp boxPlotSeries = new(core, frame);
        boxPlotSeries.createBoxPlot();

    }



    //public static void CreateXY(Metric? core, Metric? frame)
    //{

    //    XYSeriesImp XYPlotSeries = new(core, frame);
    //    XYPlotSeries.createBoxPlot();

    //}


    public static Metric GetMetric(string path, double? nthPercent = null)
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

                int n;
                bool isNumeric = int.TryParse(values[2], out n);

                if (isNumeric == false)
                {
                    continue;
                }

                if (Convert.ToInt32(values[2]) <= 30)
                {
                    metric.Latency10.Add(Double.Parse(values[14], CultureInfo.InvariantCulture));
                    //metric.Throughput10.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    //metric.ReceviedKB10.Add(Double.Parse(values[11], CultureInfo.InvariantCulture));

                }
                if (Convert.ToInt32(values[2]) > 30 && Convert.ToInt32(values[2]) <= 60)
                {
                    metric.Latency100.Add(Double.Parse(values[14], CultureInfo.InvariantCulture));
                    //metric.Throughput100.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    //metric.ReceviedKB100.Add(Double.Parse(values[11], CultureInfo.InvariantCulture));
                }
                if (Convert.ToInt32(values[2]) > 60 && Convert.ToInt32(values[2]) <= 90)
                {
                    metric.Latency1000.Add(Double.Parse(values[14], CultureInfo.InvariantCulture));
                    //metric.Throughput1000.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    //metric.ReceviedKB1000.Add(Double.Parse(values[11] , CultureInfo.InvariantCulture));
                }
                if (Convert.ToInt32(values[2]) > 90 && Convert.ToInt32(values[2]) <= 120)
                {
                    metric.Latency2000.Add(Double.Parse(values[14], CultureInfo.InvariantCulture));
                    //metric.Throughput2000.Add(Double.Parse(values[10], CultureInfo.InvariantCulture));
                    //metric.ReceviedKB2000.Add(Double.Parse(values[11], CultureInfo.InvariantCulture));

                }
            }


            if (nthPercent != null)
            {
                var getResp10temValue = Percentile(metric.Latency10, nthPercent.Value);
                var getListBelowNthPercent = NthPercentList(metric.Latency10, getResp10temValue);
                metric.Latency10 = getListBelowNthPercent;

                var getResp100temValue = Percentile(metric.Latency100, nthPercent.Value);
                var getListBelowNthPercent100 = NthPercentList(metric.Latency100, getResp100temValue);
                metric.Latency100 = getListBelowNthPercent100;

                var getResp1000temValue = Percentile(metric.Latency1000, nthPercent.Value);
                var getListBelowNthPercent1000 = NthPercentList(metric.Latency1000, getResp1000temValue);
                metric.Latency1000 = getListBelowNthPercent1000;

                var getResp2000temValue = Percentile(metric.Latency2000, nthPercent.Value);
                var getListBelowNthPercent2000 = NthPercentList(metric.Latency2000, getResp2000temValue);
                metric.Latency2000 = getListBelowNthPercent2000;

            }
            return metric;
        }
    }

    public static List<double> NthPercentList(List<double> sequence, double nthItemValue)
    {
        List<double> output = new List<double>();

        foreach (var item in sequence)
        {
            if (item < nthItemValue)
            {
                output.Add(item);
            }
        }


        return output;


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
            var tt = sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            return tt;
        }
    }


    public static List<string> ReplaceRequests(string path)
    {
        List<string> strings = new List<string>();
        using (var reader = new StreamReader(@path))
        {


            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                int n;
                bool isNumeric = int.TryParse(values[2], out n);

                if (isNumeric == false)
                {
                    continue;
                }

                if (Convert.ToInt32(values[2]) <= 30)
                {
                    line = line.Replace("," + values[2] + ",200", "," + "10VUs" + ",200");
                    strings.Add(line);


                }
                if (Convert.ToInt32(values[2]) > 30 && Convert.ToInt32(values[2]) <= 60)
                {
                    line = line.Replace("," + values[2] + ",200", "," + "100VUs" + ",200");
                    strings.Add(line);


                }
                if (Convert.ToInt32(values[2]) > 60 && Convert.ToInt32(values[2]) <= 90)
                {
                    line = line.Replace("," + values[2] + ",200", "," + "1000VUs" + ",200");
                    strings.Add(line);
                }
                if (Convert.ToInt32(values[2]) > 90 && Convert.ToInt32(values[2]) <= 120)
                {
                    line = line.Replace("," + values[2] + ",200", "," + "2000VUs" + ",200");
                    strings.Add(line);


                }
            }

            return strings;


 
        }
    }


    public static Metric GetThroughputMetric(string path)
    {

        Metric throughPut = new Metric();
        throughPut.Throughput10 = new List<double>();
        throughPut.Throughput100 = new List<double>();
        throughPut.Throughput1000 = new List<double>();
        throughPut.Throughput2000 = new List<double>();


        throughPut.Throughput10Time = new List<long>();
        throughPut.Throughput100Time = new List<long>();
        throughPut.Throughput1000Time = new List<long>();
        throughPut.Throughput2000Time = new List<long>();


        using (var reader = new StreamReader(@path))
        {

            string sameVal = "1";
            string sameVal100 = "31";
            string sameVal1000 = "61";
            string sameVal2000 = "91";


            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');




                if (values[0] != "timeStamp")
                {

                    int n;
                    bool isNumeric = int.TryParse(values[2], out n);

                    if (isNumeric == false)
                    {
                        continue;
                    }

                    if (Convert.ToInt32(values[2]) <= 30)
                    {
                        if (sameVal != values[2])
                        {

                            var diff = (double)(throughPut.Throughput10Time[throughPut.Throughput10Time.Count - 1] - throughPut.Throughput10Time[0]) / 1000;
                            var r = (double)(throughPut.Throughput10Time.Count / diff);
                            throughPut.Throughput10.Add(r);
                            throughPut.Throughput10Time = new();
                            sameVal = values[2];
                        }
                        else
                        {
                            throughPut.Throughput10Time.Add(Convert.ToInt64(values[0]));




                        }

    







                    }
                    if (Convert.ToInt32(values[2]) > 30 && Convert.ToInt32(values[2]) <= 60)
                    {

                        if (sameVal100 != values[2])
                        {

                            var diff100 = (double)(throughPut.Throughput100Time[throughPut.Throughput100Time.Count - 1] - throughPut.Throughput100Time[0]) / 1000;
                            var r100 = (double)(throughPut.Throughput100Time.Count / diff100);

                            throughPut.Throughput100.Add(r100);
                            throughPut.Throughput100Time = new();


                            sameVal100 = values[2];
                        }
                        else
                        {
                            throughPut.Throughput100Time.Add(Convert.ToInt64(values[0]));




                        }




                        



                    }
                    if (Convert.ToInt32(values[2]) > 60 && Convert.ToInt32(values[2]) <= 90)
                    {
                        if (sameVal1000 != values[2])
                        {

                            var diff1000 = (double)(throughPut.Throughput1000Time[throughPut.Throughput1000Time.Count - 1] - throughPut.Throughput1000Time[0]) / 1000;
                            var r1000 = (double)(throughPut.Throughput1000Time.Count / diff1000);

                            throughPut.Throughput1000.Add(r1000);
                            throughPut.Throughput1000Time = new();


                            sameVal1000 = values[2];
                        }
                        else
                        {
                            throughPut.Throughput1000Time.Add(Convert.ToInt64(values[0]));




                        }

                        

                    }
                    if (Convert.ToInt32(values[2]) > 90 && Convert.ToInt32(values[2]) <= 120)
                    {
                        if (sameVal2000 != values[2])
                        {

                            var diff2000 = (double)(throughPut.Throughput2000Time[throughPut.Throughput2000Time.Count - 1] - throughPut.Throughput2000Time[0]) / 1000;
                            var r2000 = (double)(throughPut.Throughput2000Time.Count / diff2000);

                            throughPut.Throughput2000.Add(r2000);
                            throughPut.Throughput2000Time = new();


                            sameVal2000 = values[2];
                        }
                        else
                        {
                            throughPut.Throughput2000Time.Add(Convert.ToInt64(values[0]));




                        }

                        



                    }

                }

            }

      

  


           

           


            return throughPut;
        }
    }
}














//Convert to VUS
//var withVUS = ReplaceRequests(@"C:\Users\Simon\Desktop\2022-12-22new\core\emptyc.jtl");
//var result = "";

//foreach (var item in withVUS)
//{
//    result += item + Environment.NewLine;
//}


//File.WriteAllText(@"C:\Users\Simon\Desktop\2022-12-22new\WithVUs\emptyc.csv", result);


//var core = GetThroughputMetric(@"C:\Users\Simon\Desktop\2022-12-22new\core\objectc2.jtl");

//var frame = GetThroughputMetric(@"C:\Users\Simon\Desktop\2022-12-22new\frame\objrctf.jtl");

//CreateBox(core, frame);