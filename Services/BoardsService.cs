using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JiraBoardNg.Controllers.Models;
using JiraBoardNg.Controllers.Models.Shared;
using JiraBoardNg.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JiraBoardNg.Services
{
    public class BoardsService : IBoardsService
    {
        private readonly IDictionary<string, BoardConfig> _boardsConfig;
        private readonly string _jiraBaseUrl;

        public BoardsService(IConfiguration config)
        {
            var boardsText = File.ReadAllText("Data/Boards.json");
            _boardsConfig = JsonConvert.DeserializeObject<IDictionary<string, BoardConfig>>(boardsText);
            _jiraBaseUrl = config["JiraClient:BaseUrl"] ?? throw new Exception("JIRA Base URL not found in configuration");
        }

        public BoardResponse BuildBoard(string id)
        {
            if (!_boardsConfig.ContainsKey(id))
            {
                throw new InvalidOperationException($"Board with ID {id} not found");
            }
            
            var boardConfig = _boardsConfig[id];

            return new BoardResponse
            {
                BoardTitle = boardConfig.Title,
                Columns = boardConfig.Columns.Select(column => new BoardColumn
                {
                    Title = column.Title,
                    BgColor = column.BgColor,
                    FilterId = column.FilterId,
                    FilterUrl = $"{_jiraBaseUrl}/issues/?filter={column.FilterId}",
                    WipLimit = column.WipLimit
                }),
            };
        }
    }
}