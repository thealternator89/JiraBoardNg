using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JiraBoardNg.Controllers.Models;
using JiraBoardNg.Controllers.Models.Shared;
using JiraBoardNg.Processor;
using JiraBoardNg.RestClients;
using JiraBoardNg.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraBoardNg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardsService _service;
        
        public BoardController(IBoardsService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        [HttpGet]
        public BoardResponse Get([FromQuery][Required] string id)
        {
            return _service.BuildBoard(id);
        }
    }
}