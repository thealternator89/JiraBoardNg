using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JiraBoardNg.Controllers.Models.Shared;
using JiraBoardNg.Processor;
using JiraBoardNg.RestClients;
using Microsoft.AspNetCore.Mvc;

namespace JiraBoardNg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : ControllerBase
    {
        private readonly IJiraClient _jiraClient;
        private readonly ITicketConverter _ticketConverter;
        
        public FilterController(IJiraClient jiraClient, ITicketConverter converter)
        {
            _jiraClient = jiraClient ?? throw new ArgumentNullException(nameof(jiraClient));
            _ticketConverter = converter ?? throw new ArgumentNullException(nameof(converter));
        }
        
        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get([FromQuery][Required] int id)
        {
            var filterResult = await _jiraClient.GetIssuesForFilter(id);
            return _ticketConverter.ConvertJiraResponseToTickets(filterResult);
        }
    }
}