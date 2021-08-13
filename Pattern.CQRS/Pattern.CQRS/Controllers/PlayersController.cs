using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pattern.CQRS.Features.Players.Commands;
using Pattern.CQRS.Features.Players.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pattern.CQRS.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(await _mediator.Send(new GetAllPlayersQuery()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            return Ok(await _mediator.Send(new GetPlayerByIdQuery() { Id = id }));
        }

        [HttpPost]
        [Route("player")]
        public async Task<IActionResult> Create(CreatePlayerCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Unable to save changes.");
            }
            return Ok(command);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id, UpdatePlayerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Unable to save changes.");
            }
            return Ok(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeletePlayerCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Unable to delete. ");
            }

            return Ok();
        }
    }
}
