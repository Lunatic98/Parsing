using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class StartProgram
    {
        private ParsingDbContext _parsingDbContext;

        public StartProgram(ParsingDbContext parsingDbContext)
        {
            _parsingDbContext = parsingDbContext;
        }

        public void Start(string url)
        {
            Dictionary<string, List<string>> result = Pars(url);
        }

        public Dictionary<string, List<string>> Pars(string url)
        {
            try
            {
                Dictionary<string, List<string>> result =
                    new Dictionary<string, List<string>>();
                HttpClientHandler hd1 = new HttpClientHandler()
                {
                    AllowAutoRedirect = true,
                    AutomaticDecompression = System.Net.DecompressionMethods.Deflate |
                                                System.Net.DecompressionMethods.GZip |
                                                System.Net.DecompressionMethods.None
                };
                using (var client = new HttpClient(hd1))
                {
                   
                        
                    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                    var requestCount = new Request()
                    {
                        OperationName = "SearchReportWoodDealCount",
                        Query = "query SearchReportWoodDealCount($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) " +
                        "{\n  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) " +
                        "{\n    total\n    number\n    size\n    overallBuyerVolume\n    overallSellerVolume\n    __typename\n  }\n}\n",
                        Variables = new Variables()
                        {
                            Number = 1,
                            Size = 20
                        }
                    };

                    var requestCountJson = JsonConvert.SerializeObject(requestCount, new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    });
                    var contentCount = new StringContent(requestCountJson, Encoding.UTF8, MediaTypeNames.Application.Json);

                    var responseCount = client.PostAsync(url, contentCount).Result;
                    var responseCountString = responseCount.Content.ReadAsStringAsync().Result;

                    var countDeals = JsonConvert.DeserializeObject<ResponseCount>(responseCountString);
                    var countPage = countDeals.Data.SearchReportWoodDeal.Total / 5000;

                    for(int i = 1; i < countPage + 1; i++)
                    {
                        Console.WriteLine($"Обработка {i} страницы");
                        var request = new Request()
                        {
                            OperationName = "SearchReportWoodDeal",
                            Query = "query SearchReportWoodDeal($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) " +
                        "{\n  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) " +
                        "{\n    content {\n      sellerName\n      sellerInn\n      buyerName\n      buyerInn\n      woodVolumeBuyer\n      woodVolumeSeller\n      " +
                        "dealDate\n      dealNumber\n      __typename\n    }\n    __typename\n  }\n}\n",
                            Variables = new Variables()
                            {
                                Number = i,
                                Size = 5000
                            }
                        };
                        var requestJson = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                        {
                            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                        });
                        var content = new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json);

                        var response = client.PostAsync(url, content).Result;
                        var responseString = response.Content.ReadAsStringAsync().Result;

                        var deal = JsonConvert.DeserializeObject<Response>(responseString);
                        var counter = 1;
                        var ids = deal.Data.SearchReportWoodDeal.Content.Select(x => x.DealNumber).ToArray();
                        var dbIds = _parsingDbContext.Deals.Where(x => ids.Contains(x.DealNumber)).Select(x=>x.DealNumber).ToArray();
                       
                        foreach (var item in deal.Data.SearchReportWoodDeal.Content.DistinctBy(x=>x.DealNumber).Where(x => !dbIds.Contains(x.DealNumber)))
                        {
                            
                            Console.WriteLine($"Обработка {counter} элемента");
                            try
                            {
                                _parsingDbContext.Deals.Add(new Deal()
                                {
                                    BuyerInn = item.BuyerInn,
                                    BuyerName = item.BuyerName,
                                    WoodVolumeBuyer = item.WoodVolumeBuyer,
                                    DealDate = item.DealDate,
                                    DealNumber = item.DealNumber,
                                    SellerInn = item.SellerInn,
                                    SellerName = item.SellerName,
                                    WoodVolumeSeller = item.WoodVolumeSeller,
                                    Typename = item.Typename
                                });
                                counter++;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Ошибка {ex.Message}");
                            }
                        }
                        _parsingDbContext.SaveChanges();


                    }


                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
