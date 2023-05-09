using Application.Services;
using Domain.Commands;
using Domain.Commands.Handlers;
using Domain.Entities;
using Domain.Queries.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> Get([FromServices] IQueriesTaskHandler handler)
    {
        var taskList = await handler.Handle();
        return Ok(taskList);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetOne(
        [FromServices] IQueriesTaskHandler handler
        ,[FromRoute] int id)
    {
        try
        {
            var task = await handler.Handle(id);
            return Ok(task);
        }
        catch
        {
            return NotFound("Task not found");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post(
            [FromServices] ICommandsTaskHandler handler,
            [FromBody] CreateTaskRequest command)
    {
        var task = await handler.Handle(command);
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(
        [FromServices] ICommandsTaskHandler handler,
        [FromRoute] int id)
    {
        try
        {
            await handler.Handle(id);
            return NoContent();
        }
        catch
        {
            return NotFound("Task not found");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
        [FromServices] ICommandsTaskHandler handler,
        [FromRoute] int id, [FromBody] UpdateTaskRequest command)
    {
        try
        {
            var taskUpdated = await handler.Handle(id, command);
            return Ok(taskUpdated);
        }
        catch
        {
            return NotFound("Task not found");
        }
    }
}