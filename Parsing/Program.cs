using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> result = Pars(url : "https://www.lesegais.ru/open-area/deal");
            if (result != null)
            {
                foreach (var item in result)
                {

                }
            }
            
        }
        private static Dictionary<string, List<string>> Pars(string url) 
        {
            try
            {
                Dictionary<string, List<string>> result =
                    new Dictionary<string, List<string>>();
                using (HttpClientHandler hd1 = new HttpClientHandler
                {
                    AllowAutoRedirect = false,
                    AutomaticDecompression = System.Net.DecompressionMethods.Deflate |
                System.Net.DecompressionMethods.GZip |
                System.Net.DecompressionMethods.None
                })
                {
                    using (var client = new HttpClient(hd1))
                    {
                        using (HttpResponseMessage resp = client.GetAsync(url).Result)
                        {
                            if (resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result;
                                if (string.IsNullOrEmpty(html))
                                {
                                    HtmlDocument doc = new HtmlDocument();
                                    doc.LoadHtml(html);

                                    var table = doc.DocumentNode.SelectSingleNode(".//div[@class='ag-body-container']");
                                    if (table != null)
                                    {
                                        var rows = table.SelectNodes(".//div");
                                        if (rows != null && rows.Count > 0)
                                        {
                                            var res = new List<List<string>>();
                                            foreach (var row in rows)
                                            {
                                                var cells = row.SelectNodes(".//div");
                                                if (cells != null && cells.Count > 0)
                                                {
                                                    res.Add(new List<string>(cells.Select(c => c.InnerText)));
                                                }
                                            }
                                            return result;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine($"{nameof(table)} not found");
                                    }
                                }
                            }
                        }
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
