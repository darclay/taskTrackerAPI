using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static List<Event> tasks = new List<Event>()
        {
            new Event { Id = 0, Text = "the first event", Day = "Aug 30, 2022", Reminder = true },
            new Event { Id = 1, Text = "another event", Day = "Aug 31, 2022", Reminder = false },
            new Event { Id = 2, Text = "the third event", Day = "Sept 1, 2022", Reminder = true },
            new Event { Id = 3, Text = "quess what", Day = "Sept 2, 2022", Reminder = false },
            new Event { Id = 4, Text = "blah blah blah", Day = "Sept 3, 2022", Reminder = false }
        };


        // GET: api/<TasksController>
        //gets all of our events
        //below is the attribute which injects the http get method to the function just below
        [HttpGet]
        public List<Event> Get()
        {
            //returning a list of events
            return tasks;
        }

        // GET api/<TasksController>/5
        //gets a single event

        [HttpGet("{id}")]
        //can not add static to the below function or it will not read the function and execute
        public ActionResult<Event> Get(int id)
        {
            //loop through our list search for the id
            //return the id of the object with object
            //return ;
            //return tasks.FirstOrDefault(ev => ev.Id == id);
            var aTask = tasks.Find(ev => ev.Id == id);
            if (aTask != null)
            {
                return aTask;
            }
            else
                return NotFound("does this appear");
        }

        // POST api/<TasksController>
        [HttpPost]
        //public void Post()
        public ActionResult Post([FromBody] Event value)
        {
            tasks.Add(value);
            return CreatedAtAction("Post", value);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event value)
        {
            if (id != value.Id)
                return BadRequest("id not found");
            else
            {
                var index = tasks.FindIndex(ev => ev.Id == value.Id);
                if (index == -1)
                    return BadRequest(StatusCode(404));
                else
                {
                    tasks[index] = value;
                    return Ok(StatusCode(202));
                }
            }
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var index = tasks.FindIndex(ev => ev.Id == id);
            if (index == -1)
                return NotFound();
            else
            {
                tasks.Remove(tasks[index]);
                return Ok();
            }
        }
    }
}