using Core_Web_API_CRUD_Operations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Web_API_CRUD_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentContext _StudentContext;
        public StudentApiController(StudentContext studentContext)
        {
            _StudentContext = studentContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Emp>>> GetStudent()
        {
           var emp= await _StudentContext.Emps.ToListAsync();
            return Ok(emp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emp>> GetStudentIndex(int id)
        {
            var emp = await _StudentContext.Emps.FindAsync(id);
            if (emp == null)
            {
                return BadRequest();
            }
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Emp>> PostStudent(Emp emp)
        {
           
                await _StudentContext.Emps.AddAsync(emp);
                await _StudentContext.SaveChangesAsync();
                return Ok(emp);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Emp>> EditStudent(int id,Emp emp)
        {
              if (id != emp.Id)
                {
                    return BadRequest();
                }
                var em = _StudentContext.Emps.Update(emp);
                await _StudentContext.SaveChangesAsync();
                return Ok(em);
          
          
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Emp>> DeleteStudent(int id)
        {
           
            var em = await _StudentContext.Emps.FindAsync(id);
            if (em == null)
            {
                NotFound();
            }
            _StudentContext.Emps.Remove(em);
            await _StudentContext.SaveChangesAsync();
            return Ok(em);
        }










        //[HttpPost]

        //public async Task<ActionResult<Emp>> PostStudent(int id) {
        //    var emp = await _StudentContext.Emps.FindAsync(id);
        //    await _StudentContext.Update(emp);
        //    await _StudentContext.SaveChangesAsync();

        //}

    }
}
