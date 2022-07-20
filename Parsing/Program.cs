using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
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
            var services = new ServiceCollection();

            StartProgram sp = new StartProgram(new ParsingDbContext());
            sp.Start("https://www.lesegais.ru/open-area/graphql");
            
        }
    }
}
