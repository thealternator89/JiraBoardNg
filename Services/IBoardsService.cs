using JiraBoardNg.Controllers.Models;

namespace JiraBoardNg.Services
{
    public interface IBoardsService
    {
        BoardResponse BuildBoard(string id);
    }
}