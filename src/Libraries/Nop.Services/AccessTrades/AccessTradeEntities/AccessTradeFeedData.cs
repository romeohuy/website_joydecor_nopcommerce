using System.Collections.Generic;

namespace Nop.Services.AccessTrades.AccessTradeEntities
{
    public class AccessTradeFeedDataResponse
    {
        public AccessTradeFeedDataResponse()
        {
            data = new List<AccessTradeFeedData>();
        }
        public int total { get; set; }
        public List<AccessTradeFeedData> data { get; set; }
    }
    public class AccessTradeFeedData
    {
        public string aff_link { get; set; }
        public string campaign { get; set; }
        public string cate { get; set; }
        public string desc { get; set; }
        public decimal discount { get; set; }
        public decimal discount_amount { get; set; }
        public decimal discount_rate { get; set; }
        public string domain { get; set; }
        public string image { get; set; }
        public string merchant { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string product_id { get; set; }
        public object promotion { get; set; }
        public string sku { get; set; }
        public int status_discount { get; set; }
        public string update_time { get; set; }
        public string url { get; set; }
    }
}
