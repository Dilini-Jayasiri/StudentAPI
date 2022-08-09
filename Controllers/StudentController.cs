using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Dilini",
                Age = 25,
                City = "Panadura"
            },
            new Student()
            {
                Id = 2,
                Name = "Thiva",
                Age = 32,
                City = "new zealand"
            }
        };

        [HttpGet]
        [Route("getStudents")]

        public async Task<ActionResult<Student>> GetStudents()
        {
            return Ok(students);
        }

        [HttpGet]
        [Route("getStudent")]
        public async Task<ActionResult<Student>> GetStudant(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null)
                return BadRequest("Record not found");
           
            return Ok(student);

        }

        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<Student>> AddStudants(Student request)
        {
            students.Add(request);

            return Ok(students);

        }

        [HttpPut]
        [Route("updateStudent")]
        public async Task<ActionResult<Student>> UpdateStudant(Student request)
        {
            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
                return BadRequest("Record not found");

            student.Name = request.Name;
            student.Age= request.Age;
            student.City = request.City;
            return Ok(students);

        }

        [HttpDelete]
        [Route("deleteStudent")]
        public async Task<ActionResult<Student>> DeleteStudant(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null)
                return BadRequest("Record not found");

            students.Remove(student);
            return Ok(students);

        }
    }
}

