using System;
using System.Collections.Generic;

namespace JiraBoardNg.RestClients.Models
{
    public class JiraResponse
    {
        
        public int StartAt { get; set; }
        public int MaxResults { get; set; }
        public int Total { get; set; }
        public IEnumerable<JiraResponseIssue> Issues { get; set; }
    }
    
    public class JiraResponseIssue
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public JiraResponseIssueFields Fields { get; set; }
    }

    public class JiraResponseIssueFields
    {
        public string Summary { get; set; }
        public JiraResponseUser Assignee { get; set; }
        public JiraResponseUser Creator { get; set; }
        public JiraResponseUser Reporter { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Description { get; set; }
        public JiraResponseIssueType IssueType { get; set; }
    }

    public class JiraResponseUser
    {
        public string Self { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string Timezone { get; set; }
        public IDictionary<string, string> AvatarUrls { get; set; }
    }

    public class JiraResponseIssueType
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public bool SubTask { get; set; }
        public int AvatarId { get; set; }
    }
}