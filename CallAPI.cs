using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ConsoleApp2
{
    public class CallAPI
    {
        public async Task GetData()
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("https://api.publicapis.org/entries").Result;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var all = JsonConvert.DeserializeObject<values>(EmpResponse);
                    all.entries.ToList().ForEach(entry =>

                    Console.WriteLine(entry.Link));
                }
            }
        }
    }
    class values
    {
        public string count { get; set; }
        public Info[] entries { get; set; }
    }
    class Info
    {
        public string? API { get; set; }
        public string? Description { get; set; }
        public string? Auth { get; set; }
        public bool? HTTPS { get; set; }
        public string? Cors { get; set; }
        public string? Link { get; set; }
        public string? Category { get; set; }
    }
}
