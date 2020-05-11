namespace JiraBoardNg.Model
{
    public class BoardConfig
    {
        public string Title { get; set; }
        public BoardColumnConfig[] Columns { get; set; }
    }

    public class BoardColumnConfig
    {
        public string Title { get; set; }
        public string BgColor { get; set; }
        public int FilterId { get; set; }
        public int? WipLimit { get; set; }
    }
}