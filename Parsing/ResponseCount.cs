using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class DataCount
    {
        [JsonProperty("searchReportWoodDeal")]
        public SearchReportWoodDealCount SearchReportWoodDeal { get; set; }
    }

    public class ResponseCount
    {
        [JsonProperty("data")]
        public DataCount Data { get; set; }
    }

    public class SearchReportWoodDealCount
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("overallBuyerVolume")]
        public double OverallBuyerVolume { get; set; }

        [JsonProperty("overallSellerVolume")]
        public double OverallSellerVolume { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

}
