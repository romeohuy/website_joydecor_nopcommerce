using System;
using System.Collections.Generic;

namespace Nop.Services.AccessTrades.AccessTradeEntities
{
    public class CampainDataResponse
    {
        public CampainDataResponse()
        {
            data = new List<CampainData>();
        }
        public int total { get; set; }
        public List<CampainData> data { get; set; }
    }
    public class CampainData
    {
        public string approval { get; set; }
        public string category { get; set; }
        public int cookie_duration { get; set; }
        public string cookie_policy { get; set; }
        public string description { get; set; }
        public object end_time { get; set; }
        public string id { get; set; }
        public string merchant { get; set; }
        public string name { get; set; }
        public string scope { get; set; }
        public DateTime start_time { get; set; }
        public int status { get; set; }
        public string sub_category { get; set; }
        public int type { get; set; }
        public string url { get; set; }
    }
}
