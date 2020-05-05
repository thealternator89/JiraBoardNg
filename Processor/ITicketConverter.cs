using System.Collections.Generic;
using JiraBoardNg.Controllers.Models.Shared;
using JiraBoardNg.RestClients.Models;

namespace JiraBoardNg.Processor
{
    public interface ITicketConverter
    {
        IEnumerable<Ticket> ConvertJiraResponseToTickets(JiraResponse response);
    }
}