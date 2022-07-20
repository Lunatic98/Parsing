using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Content
    {
        [JsonProperty("sellerName")]
        public string? SellerName { get; set; }

        [JsonProperty("sellerInn")]
        public string? SellerInn { get; set; }

        [JsonProperty("buyerName")]
        public string? BuyerName { get; set; }

        [JsonProperty("buyerInn")]
        public string? BuyerInn { get; set; }

        [JsonProperty("woodVolumeBuyer")]
        public double? WoodVolumeBuyer { get; set; }

        [JsonProperty("woodVolumeSeller")]
        public double? WoodVolumeSeller { get; set; }

        [JsonProperty("dealDate")]
        public string? DealDate { get; set; }

        [JsonProperty("dealNumber")]
        public string? DealNumber { get; set; }

        [JsonProperty("__typename")]
        public string? Typename { get; set; }
    }

    public class Data
    {
        [JsonProperty("searchReportWoodDeal")]
        public SearchReportWoodDeal SearchReportWoodDeal { get; set; }
    }

    public class Root
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class SearchReportWoodDeal
    {
        [JsonProperty("content")]
        public List<Content> Content { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }
    public class Response
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
