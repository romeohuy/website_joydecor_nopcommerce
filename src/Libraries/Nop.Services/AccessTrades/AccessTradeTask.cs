using Newtonsoft.Json;
using Nop.Core.Domain.Catalog;
using Nop.Services.AccessTrades.AccessTradeEntities;
using Nop.Services.Configuration;
using Nop.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Nop.Services.AccessTrades
{
    /// <summary>
    /// Clear cache scheduled task implementation
    /// </summary>
    public partial class AccessTradeTask : IScheduleTask
    {
        #region Fields

        private readonly ISettingService _settingService;
        #endregion

        #region Ctor

        public AccessTradeTask(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            var client = InitHttpClient();
            var dataFeeds = GetAvailableDataFeeds(client);
            foreach (var dataFeed in dataFeeds)
            {

            }
        }

        private Product ConvertDataFeedToProduct(AccessTradeFeedData dataFeed)
        {
            return new Product
            {
                Sku = dataFeed.sku,
                Name = dataFeed.name,
                Price = dataFeed.discount,
                OldPrice = dataFeed.price,
                StockQuantity = 1,
                CreatedOnUtc = DateTime.Now
            };
        }

        private HttpClient InitHttpClient()
        {
            var accessTradeApiUrl = _settingService.GetSettingByKey<string>("AccessTradeApiUrl", "https://api.accesstrade.vn");
            var accessTradeKey = _settingService.GetSettingByKey<string>("AccessTradeKey", "https://api.accesstrade.vn");
            var client = new HttpClient();
            client.BaseAddress = new Uri(accessTradeApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Token {accessTradeKey}");
            return client;
        }

        private List<CampainData> GetAvailableCampains(HttpClient client)
        {
            var httpResponse = client.GetAsync("/v1/campaigns").Result;
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<CampainData>>(httpResponse.Content.ToString());
            }

            return null;
        }


        private List<AccessTradeFeedData> GetAvailableDataFeeds(HttpClient client)
        {
            var httpResponse = client.GetAsync("/v1/datafeeds").Result;
            var accessTradeFeedDataResponse = new AccessTradeFeedDataResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                accessTradeFeedDataResponse = JsonConvert.DeserializeObject<AccessTradeFeedDataResponse>(httpResponse.Content.ToString());
            }
            return accessTradeFeedDataResponse?.data;
        }
        #endregion
    }
}