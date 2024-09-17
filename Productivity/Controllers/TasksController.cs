using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productivity.Context;
using Productivity.Interface;
using Productivity.Models;

namespace Productivity.Controllers
{
    [Route("api/Tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DapperContext _context;
        private readonly ITask _task;

        public TasksController(DapperContext ctx, ITask t)
        {
            _context = ctx;
            _task = t;
        }

        //Get all
        [HttpGet("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            try
            {
                var l = await _task.GetAllTasks();
                return new JsonResult(l);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Get pending
        [HttpGet("ViewPending")]
        public async Task<IActionResult> ViewPending()
        {
            try
            {
                var l = await _task.GetPendingTasks();
                return new JsonResult(l);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Get done
        [HttpGet("ViewDone")]
        public async Task<IActionResult> ViewDone()
        {
            try
            {
                var l = await _task.GetDoneTasks();
                return new JsonResult(l);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Get count all
        [HttpGet("ViewAllCount")]
        public async Task<IActionResult> ViewAllCount()
        {
            try
            {
                var r = await _task.CountAllTasks();
                return new JsonResult(r);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Get count done
        [HttpGet("ViewDoneCount")]
        public async Task<IActionResult> ViewDoneCount()
        {
            try
            {
                var r = await _task.CountDoneTasks();
                return new JsonResult(r);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Get count pending
        [HttpGet("ViewPendingCount")]
        public async Task<IActionResult> ViewPendingCount()
        {
            try
            {
                var r = await _task.CountPendingTasks();
                return new JsonResult(r);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Add task
        [HttpPost("Add")]
        public async Task<IActionResult> Add(Tasks task)
        {
            try
            {
                await _task.AddTask(task);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Update task
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                await _task.UpdateTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Delete task
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete()
        {
            try
            {
                await _task.DeleteTask();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
