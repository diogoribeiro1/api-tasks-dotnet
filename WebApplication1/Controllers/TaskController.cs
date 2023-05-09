using Application.Services;
using Domain.Commands;
using Domain.Commands.Handlers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITasksServices _tasksService;

    public TaskController(ITasksServices tasksService)
    {
        _tasksService = tasksService;   
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var listPayload = await _tasksService.GetAllAsync();
        return Ok(listPayload);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetOne([FromRoute] int id)
    {
        var task = await _tasksService.GetOneAsync(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<CreateTaskResponse> Post(
            [FromServices] ICreateTaskHandler handler,
            [FromBody] CreateTaskRequest command)
    {
       // var task = await _tasksService.CreateAsync(data);
       // Created("", task);
       return await handler.Handle(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _tasksService.DeleteAsync(id);
    }

    [HttpPut("{id}")]
    public async Task Update([FromRoute] int id, [FromBody] Tasks data)
    {
         await _tasksService.UpdateAsync(id, data);
    }
}