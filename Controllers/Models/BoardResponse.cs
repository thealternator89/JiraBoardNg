using System.Collections.Generic;
using JiraBoardNg.Controllers.Models.Shared;

namespace JiraBoardNg.Controllers.Models
{
    public class BoardResponse
    {
        public string BoardTitle { get; set; }
        public IEnumerable<BoardColumn> Columns { get; set; }
    }
}