using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
   private List<TaskModel> Tasks = new List<TaskModel>();

   [HttpGet]
   public IActionResult GetTasks() => Ok(Tasks);
   
   [HttpPost]
   public IActionResult AddTask([FromBody] TaskModel task)
   {
      Tasks.Add(task);
      return Ok(Tasks);
   }

   [HttpPut("{id}")]
   public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
   {
      var taskFound = Tasks.FirstOrDefault(t => t.Id == task.Id);

      if (taskFound == null) return NotFound();
      
      Tasks.Remove(taskFound);
      return Ok(Tasks);
   }

}