namespace JiraBoardNg.Controllers.Models.Shared
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
        public IssueType IssueType { get; set; }
        public string Url { get; set; }
    }

    public class IssueType
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}