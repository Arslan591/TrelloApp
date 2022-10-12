using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrelloApp.Data;
using TrelloApp.Model;

namespace TrelloApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatesController : ControllerBase
    {
        private readonly DataContext _context;

        public UserStatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskState>>> GetUser()
        {
            return await _context.Taskst.ToListAsync();
        }

        // GET: api/UserStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskState>> GetUserState(Guid id)
        {
            var userState = await _context.Taskst.FindAsync(id);

            if (userState == null)
            {
                return NotFound();
            }

            return userState;
        }

        // PUT: api/UserStates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserState(Guid id, TaskState userState)
        {
            if (id != userState.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(userState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserStates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskState>> PostUserState(TaskState userState)
        {
            _context.Taskst.Add(userState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserState", new { id = userState.TaskId }, userState);
        }

        // DELETE: api/UserStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserState(Guid id)
        {
            var userState = await _context.Taskst.FindAsync(id);
            if (userState == null)
            {
                return NotFound();
            }

            _context.Taskst.Remove(userState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserStateExists(Guid id)
        {
            return _context.Taskst.Any(e => e.TaskId == id);
        }
    }
}
