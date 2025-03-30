using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
   private static List<TaskModel> Tasks = new List<TaskModel>();
   
   // PATCH - uso de DTO
   [HttpPatch("{id}")]
   public IActionResult Patch([FromRoute] int id, [FromBody] TaslModelPatchDTO updates)
   {
      var task = Tasks.FirstOrDefault(t => t.Id == id);
      if (task == null)
         return NotFound(new { message = "Task not found" });
      
      if (updates.Status != null)
         task.Status = updates.Status;
      
      return Ok(new { message = "Task patched", task });
   }
   
   // DELETE
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