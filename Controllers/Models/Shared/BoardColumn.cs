using System.Collections.Generic;

namespace JiraBoardNg.Controllers.Models.Shared
{
    public class BoardColumn
    {
        public string Title { get; set; }
        public string BgColor { get; set; }
        public int FilterId { get; set; }
        public string FilterUrl { get; set; }
        public int? WipLimit { get; set; }
    }
}