using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace FintechSecurityTool.WebApplicationScanner
{
    public class Scanner
    {
        private const string BASE_URL = "http://localhost:8080"; // OWASP ZAP API endpoint
        private const string API_KEY = "dpt3jfdl4d9p2nds2sutjd0b91"; // Replace with your ZAP API key

        public async Task<string> StartScan(string targetUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{BASE_URL}/JSON/ascan/action/scan/?url={targetUrl}&apikey={API_KEY}");
                var responseBody = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseBody);
                return jsonResponse["scan"].ToString();
            }
        }

        public async Task<string> GetScanStatus(string scanId)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{BASE_URL}/JSON/ascan/view/status/?scanId={scanId}&apikey={API_KEY}");
                var responseBody = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseBody);
                return jsonResponse["status"].ToString();
            }
        }

        public async Task<string> GetScanResults(string scanId)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{BASE_URL}/JSON/ascan/view/alerts/?baseurl={targetUrl}&scanId={scanId}&apikey={API_KEY}");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
