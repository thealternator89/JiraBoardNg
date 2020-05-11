# JiraBoardNg

A JIRA Board which uses filters for the columns.

Built with .NET Core 3.1, Angular and Bootstrap.

## Setup

Set the following environment variables prior to launching in order to connect to JIRA:

```
export JiraBoardNg_JiraClient__Username="YourJiraUsername"
export JiraBoardNg_JiraClient__Password="YourJiraPassword"
export JiraBoardNg_JiraClient__BaseUrl="https://base.url"
```

The filters need to be set up in JIRA. Ensure the filters are visible to the user querying JIRA for the board data.

Add your filter to the `Data/Boards.json` file. The JSON key you use for your board definition is what you pass to the page to load your board.

Launch the server, and navigate to http://localhost:5000?board={{key}}

## APIs

You don't really need to know these APIs to use the board. These are all behind the Angular frontend.

### `/Board`

* Query param: `id`: The board ID to get details for

Returns the board structure for the specified id in the following shape:

```json
{
    "boardTitle": "string",
    "columns": [{
        "title": "string",
        "bgColor": "string - CSS/HTML color",
        "filterId": 17,
        "filterUrl": "https://base.url/17",
        "wipLimit": 2
    }]
}
```

### `/Filter`

* Query param: `id`: The filter ID to get tickets for

Returns ticket details in the following shape:

```json
{
    "id": "JBNG-101",
    "summary": "Summary of the ticket",
    "assignee": {
        "name": "Bobby Tables",
        "icon": "https://base.url/image.png"
    },
    "issueType": {
        "text": "Bug",
        "icon": "https://base.url/bug.png"
    },
    "url": "https://base.url/browse/JBNG.101",
    "updated": "2020-06-11T09:51:17+00:00"
}
```




