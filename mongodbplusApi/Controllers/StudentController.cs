using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using mongodbplusApi.Models;
using mongodbplusApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mongodbplusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices studentServices;

        public StudentController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return studentServices.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            return studentServices.Get(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentServices.Create(student);
            return CreatedAtAction(nameof(Get),new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentServices.Get(id);
            if (existingStudent == null)
            {
                return NotFound(" student is not present in database");
            }

            studentServices.Update(id, student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = studentServices.Get(id);
            if(student == null)
            {
                return NotFound("student is not present");

            }

            studentServices.Delete(id);

            return NoContent();

        }
    }
}
