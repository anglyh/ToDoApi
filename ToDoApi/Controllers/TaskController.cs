using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
namespace ToDoApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
   private static List<TaskModel> Tasks = new List<TaskModel>
   {
      new TaskModel
      {
         Id = 1,
         Title = "Check emails",
         Status = "pending"
      },
      new TaskModel
      {
         Id = 2,
         Title = "Finish laboratory report",
         Status = "pending"
      },
      new TaskModel
      {
         Id = 3,
         Title = "Send documentation",
         Status = "completed"
      }
   };

   [HttpGet]
   public IActionResult GetAll()
   {
      if (Tasks.Count == 0) return NotFound(new {message = "No task data found"});
      return Ok(Tasks);
   }

   [HttpGet("{id}")]
   public IActionResult GetById(int id)
   {
      var task = Tasks.FirstOrDefault(t => t.Id == id);
      if (task == null)
         return NotFound(new { message = "Task not found" });
      return Ok(task);
   }
   
   [HttpPost]
   public IActionResult AddTask([FromBody] TaskModel task)
   {
      Tasks.Add(task);
      return Ok(new { message = "Task created", Tasks});
   }

   [HttpPut("{id}")]
   public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
   {
      var taskFound = Tasks.FirstOrDefault(t => t.Id == task.Id);

      if (taskFound == null) return NotFound();
      
      taskFound.Title = task.Title;
      taskFound.Status = task.Status;
      return Ok(Tasks);
   }
   
   // PATCH - uso de DTO
   [HttpPatch("{id}")]
   public IActionResult Patch([FromRoute] int id, [FromBody] TaskModelPatchDTO updates)
   {
      var task = Tasks.FirstOrDefault(t => t.Id == id);
      if (task == null)
         return NotFound(new { message = "Task not found" });
      
      if (updates.Status != null)
         task.Status = updates.Status;
      
      return Ok(new { message = "Task patched", task });
   }
   
   [HttpDelete("{id}")]
   public IActionResult Delete([FromRoute] int id)
   {
      var task = Tasks.FirstOrDefault(t => t.Id == id);
      if (task == null)
         return NotFound(new { message = "Task not found" });
      Tasks.Remove(task);
      return Ok(new { message = "Task removed", Tasks });
   }

}