using System;
using System.Collections.Generic;
using Elasticsearch;

namespace ElasticSearch_Example_NETCORE.Models
{
    public class Gadget
    {
        // Created model for ElasticSearch DB
        public string id { get; set; }
        public string brand { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string date { get; set; }
    }
}
