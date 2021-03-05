using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElasticSearch_Example_NETCORE.Models;
using Nest;
using Microsoft.Extensions.Logging;

namespace ElasticSearch_Example_NETCORE.Controllers
{
    public class HomeController : Controller
    {
        // Configuration ElasticSearch
        private readonly ILogger<HomeController> _logger;
        private readonly ElasticClient _client;

        public HomeController(ILogger<HomeController> logger, ElasticClient client)
        {
            _logger = logger;
            _client = client;
        }

        // It return searching values
        public IActionResult MainPage()
        {
            // Indexing();
            // Delete();
            var results = _client.Search<Gadget>(s => s
            .Query(q => q
            .MatchAll()));

            return View(results);
        }
        // It add data in ElasticSearch
        public void Indexing()
        {
            var gadgetObject = new[]
            {
                new Gadget()
                {
                id = "104",
                brand = "Xiomi",
                name = "Mi6",
                color = "blue",
                date ="2018"
                },
                new Gadget()
                {
                id = "105",
                brand = "Casper",
                name = "XYZ",
                color = "green",
                date = "2013"
                },
                new Gadget()
                {
                id = "106",
                brand = "Samsung",
                name = "Galaxy A7",
                color = "gold",
                date = "2019"
                },
        };
            var indexResponse = _client.IndexMany(gadgetObject);
        }
        // It delete data in ElasticSearch according to ID
        public void Delete()
        {
            var indexResponse = _client.Delete<Gadget>("105");
        }
    }
}
