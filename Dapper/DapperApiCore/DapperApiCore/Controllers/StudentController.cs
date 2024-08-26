using DapperApiCore.Models;
using DapperApiCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentServices _studentServices;

        public StudentController(IConfiguration configuration, IStudentServices studentServices)
        {
            _configuration = configuration;
            _studentServices = studentServices;
        }

     

        [HttpGet("GetStudentList")]
        public List<Student> Index()
        {

            return _studentServices.GetStudentList().ToList();
        }

        [HttpPost("InsertStudent")]
        public string InsertStudent(Student student)
        {
            return _studentServices.InsertStudent(student);
            
            
        }
        [HttpPost("UpdatetStudent")]
        public string UpdatetStudent(Student student)
        {
            return _studentServices.UpdatetStudent(student);


        }
        [HttpPost("DeleteStudent")]
        public string DeleteStudent(int studentId)
        {
            return _studentServices.DeleteStudent(studentId);


        }

    }
}
