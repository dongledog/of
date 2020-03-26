using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBot.Crawler
{
    public class InvestingChartData
    {
        /// <summary>
        /// unixtimestamp 형식 차트 시간
        /// </summary>
        public List<int> t { get; set; }

        /// <summary>
        /// close
        /// </summary>
        public List<double> c { get; set; }

        /// <summary>
        /// open
        /// </summary>
        public List<double> o { get; set; }

        /// <summary>
        /// high
        /// </summary>
        public List<double> h { get; set; }

        /// <summary>
        /// low
        /// </summary>
        public List<double> l { get; set; }

        /// <summary>
        /// status? ok여야 정상
        /// </summary>
        public string s { get; set; }
    }
}
