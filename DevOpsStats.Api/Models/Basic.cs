﻿using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Basic
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
