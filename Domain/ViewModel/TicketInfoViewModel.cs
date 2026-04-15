

using Newtonsoft.Json;

namespace Domain.ViewModel
{
    public class TicketInfoViewModel
    {
        public int totalcount { get; set; }
        public int count { get; set; }
        public List<int> sort { get; set; }
        public List<string> order { get; set; }
        public List<Datum> data { get; set; }

        [JsonProperty("content-range")]
        public string contentrange { get; set; }
    }

    public class Datum
    {
        [JsonProperty("2")]
        public int _2 { get; set; }

        [JsonProperty("1")]
        public string _1 { get; set; }

        [JsonProperty("12")]
        public int _12 { get; set; }
    }
}