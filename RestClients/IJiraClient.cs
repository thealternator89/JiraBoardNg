using System.Threading.Tasks;
using JiraBoardNg.RestClients.Models;

namespace JiraBoardNg.RestClients
{
    public interface IJiraClient
    {
        Task<JiraResponse> GetIssuesForFilter(int filterId);
    }
}