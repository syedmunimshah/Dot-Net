using ApiDatabaseWebAPICRUDOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDatabaseWebAPICRUDOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly CodeFirstDbContext Context;
        public StudentApiController(CodeFirstDbContext _context)
        {
            Context = _context;
        }
        [HttpGet]
      
        //public async Task<ActionResult<List<Student>>> GetStudent() {
        //    try
        //    {
        //        var stdData = await Context.Students.ToListAsync();
        //        return Ok(stdData);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var std = await Context.Students.ToListAsync();
                return Ok(std);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentId(int id)
        {
            var std = await Context.Students.FindAsync(id);
            if (std == null)
            {
              return  NotFound();
            }
            return std;

        }




        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student std)
        {
            

           
           await Context.Students.AddAsync(std);
            await Context.SaveChangesAsync();
            return Ok(std);
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> EditStudent(Student std, int id)
        {
            if(id != std.Id)
            {
                return BadRequest();
            }

            //Context.Entry(std).State = EntityState.Modified;
            //await Context.SaveChangesAsync();
            //return Ok(std);

            Context.Update(std);
            await Context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await Context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
           
             Context.Students.Remove(std);
            await Context.SaveChangesAsync();
            return Ok();


        }

    }

}
