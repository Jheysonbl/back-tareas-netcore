using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using prueba_to_do_api.Models;
using System.Threading.Tasks;

namespace prueba_to_do_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly PruebaTodoBdContext _context;
        public TaskController(PruebaTodoBdContext context)
        {
            _context = context;
        }

        [Route("GetTasks")]
        [HttpGet]
        [ActionName("GetTasks")]        
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _context.Tasks.Where(t=>t.IsDeleted==false).ToListAsync());
        }

        [Route("CreateTask")]
        [HttpPost]
        [ActionName("CreateTask")]        
        public IActionResult CreateTask([FromBody] Models.Task task_obj)
        {
            if (task_obj.Task1 is null)
                return NotFound();
            task_obj = new Models.Task { Task1 = task_obj.Task1.ToUpper() };
            _context.Tasks.Add(task_obj);
            _context.SaveChanges();
            return Ok();
        }


        [Route("EditTasks")]
        [HttpPost]
        [ActionName("EditTask")]        
        public IActionResult EditTasks([FromBody] Models.Task task_obj)
        {
            Models.Task tToedit = _context.Tasks.Where(t => t.IdTask == task_obj.IdTask).FirstOrDefault();
            if (tToedit == null) { return BadRequest("Tarea no existe"); }

            tToedit.Task1 = task_obj.Task1.ToUpper();
            tToedit.IsDeleted = task_obj.IsDeleted;
            tToedit.IsCompleted = task_obj.IsCompleted;
            tToedit.ModifiedDate = DateTime.Now;
            _context.Tasks.Update(tToedit);
            _context.SaveChanges();
            return Ok();
        }
    }
}