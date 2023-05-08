using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<ActionResult> Post([FromBody] Tasks data)
    {
        var task = await _tasksService.CreateAsync(data);
        return Created("", task);
    }

    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
       // var task = await _tasksService.DeleteAsync(id);
    }

    [HttpPut("{id}")]
    public async Task Update([FromRoute] int id)
    {
        // var task = await _tasksService.UpdateAsync(id);
    }
}