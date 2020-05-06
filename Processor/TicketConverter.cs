using System;
using System.Collections.Generic;
using System.Linq;
using JiraBoardNg.Controllers.Models.Shared;
using JiraBoardNg.RestClients.Models;
using Microsoft.Extensions.Configuration;

namespace JiraBoardNg.Processor
{
    public class TicketConverter : ITicketConverter
    {
        private readonly string _jiraBaseUrl;
        public TicketConverter(IConfiguration config)
        {
            _jiraBaseUrl = config["JiraClient:BaseUrl"] ?? throw new Exception("JIRA Base URL not found in configuration");
        }
        
        public IEnumerable<Ticket> ConvertJiraResponseToTickets(JiraResponse response)
        {
            return response.Issues?.Select((issue) => new Ticket
            {
                Id = issue.Key,
                Summary = issue.Fields?.Summary,
                Assignee = issue.Fields?.Assignee?.DisplayName,
                IssueType = new IssueType
                {
                    Text = issue.Fields?.IssueType.Name,
                    Icon = issue.Fields?.IssueType.IconUrl,
                },
                Url = $"{_jiraBaseUrl}/browse/{issue.Key}",
                Updated = issue.Fields?.Updated,
            });
        }
    }
}