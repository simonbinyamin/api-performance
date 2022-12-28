using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datascience
{
    public class Metric
    {
        public List<double> ResponseTime10 { get; set; }
        public List<double> ResponseTime100 { get; set; }
        public List<double> ResponseTime1000 { get; set; }
        public List<double> ResponseTime2000 { get; set; }

        public List<double> Throughput10 { get; set; }
        public List<double> Throughput100 { get; set; }
        public List<double> Throughput1000 { get; set; }
        public List<double> Throughput2000 { get; set; }

        public List<double> ReceviedKB10 { get; set; }
        public List<double> ReceviedKB100 { get; set; }
        public List<double> ReceviedKB1000 { get; set; }
        public List<double> ReceviedKB2000 { get; set; }

    }
}

