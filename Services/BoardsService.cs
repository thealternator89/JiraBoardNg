using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JiraBoardNg.Controllers.Models;
using JiraBoardNg.Controllers.Models.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace JiraBoardNg.Services
{
    public class BoardsService : IBoardsService
    {
        private readonly JObject _boardsConfig;
        private readonly string _jiraBaseUrl;

        public BoardsService(IConfiguration config)
        {
            var boardsText = File.ReadAllText("Data/Boards.json");
            _boardsConfig = JObject.Parse(boardsText);
            _jiraBaseUrl = config["JiraClient:BaseUrl"] ?? throw new Exception("JIRA Base URL not found in configuration");
        }

        public BoardResponse BuildBoard(string id)
        {
            if (_boardsConfig[id] == null)
            {
                throw new InvalidOperationException($"Board with ID {id} not found");
            }

            var boardConfig = _boardsConfig[id];

            return new BoardResponse
            {
                BoardTitle = boardConfig["Title"].Value<string>(),
                Columns = ((JArray) boardConfig["Columns"])
                    .Select((column) => BuildColumn(column as JObject))
            };
        }

        private BoardColumn BuildColumn(JObject column)
        {
            var filterId = column["FilterId"].Value<int>();
            
            return new BoardColumn
            {
                Title = column["Title"].Value<string>(),
                BgColor = column["BgColor"].Value<string>(),
                FilterId = filterId,
                FilterUrl = $"{_jiraBaseUrl}/issues/?filter={filterId}"
            };
        }
    }
}