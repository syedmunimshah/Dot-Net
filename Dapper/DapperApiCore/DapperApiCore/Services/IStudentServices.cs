using DapperApiCore.Models;

namespace DapperApiCore.Services
{
    public interface IStudentServices
    {
        public IEnumerable<Student> GetStudentList();
        public string InsertStudent(Student student);
        public string UpdatetStudent(Student student);
        public string DeleteStudent(int StudentId);
        
    }
}
