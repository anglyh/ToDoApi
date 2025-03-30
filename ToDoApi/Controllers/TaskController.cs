using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
   private static List<TaskModel> Tasks = new List<TaskModel>
   {
      new TaskModel
      {
         Id = 1,
         Title = "Revisar correos",
         Status = "pending"
      },
      new TaskModel
      {
         Id = 2,
         Title = "Terminar reporte",
         Status = "pending"
      },
      new TaskModel
      {
         Id = 3,
         Title = "Enviar documentación",
         Status = "completed"
      }
   };

   [HttpGet]
   public IActionResult GetAll()
   {
      if (Tasks.Count == 0) return NotFound(new {message = "Sin datos para mostrar"});
      return Ok(Tasks);
   }

   [HttpGet("{index}")]
   public IActionResult GetById(int index)
   {
      if (index < 0 || index >= Tasks.Count) return NotFound(new {message = "Indice fuera de rango"});
      return Ok(Tasks[index]);
   }
   
   [HttpPost]
   public IActionResult AddTask([FromBody] TaskModel task)
   {
      Tasks.Add(task);
      return Ok(new { message = "Task creado", Tasks});
   }
   
}