using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
   private List<TaskModel> Tasks = new List<TaskModel>();

   [HttpPost]
   public IActionResult AddTask([FromBody] TaskModel task)
   {
      Tasks.Add(task);
      return Ok(task);
   }

}