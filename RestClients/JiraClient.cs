using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JiraBoardNg.RestClients.Models;
using Microsoft.Extensions.Configuration;

namespace JiraBoardNg.RestClients
{
    public class JiraClient : IJiraClient
    {
        private const string ApiBasePath = "/rest/api/2/search";

        private readonly string _jiraUrl;
        private readonly string _username;
        private readonly string _password;

        private readonly HttpClient _client;

        public JiraClient(IConfiguration config)
        {
            _jiraUrl = config["JiraClient:BaseUrl"] ?? throw new Exception("JIRA Base URL not found in configuration");
            _username = config["JiraClient:Username"] ?? throw new Exception("JIRA Username not found in configuration");
            _password = config["JiraClient:Password"] ?? throw new Exception("JIRA Password not found in configuration");
            
            _client = new HttpClient();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", BuildBasicAuth());
        }

        public async Task<JiraResponse> GetIssuesForFilter(int filterId)
        {
            var response = await _client.GetStringAsync($"{_jiraUrl}{ApiBasePath}?jql=filter={filterId}");

            var responseObj = JsonSerializer.Deserialize<JiraResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            
            return responseObj;
        }

        private string BuildBasicAuth()
        {
            var bytes = Encoding.ASCII.GetBytes($"{_username}:{_password}");
            return Convert.ToBase64String(bytes);
        }
    }
}