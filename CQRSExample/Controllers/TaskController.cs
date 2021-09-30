using CQRSExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSExample.Controllers
{
   
        [ApiController]
        public class TaskController : ControllerBase
        {
            private readonly IMediator _mediatr;
            public TaskController(IMediator mediatr)
            {
                _mediatr = mediatr;
            }
            [HttpGet("/{Id}")]
            public async Task<IActionResult> GetDatabyId(int Id)
            {
                var result = await _mediatr.Send(new GetData.Query(Id));
                return result != null ? Ok(result) : NotFound();
            }
            [HttpPost("")]
            public async Task<IActionResult> GetDatabyId(AddData.Command command) => Ok(await _mediatr.Send(command));
        }
    
}
