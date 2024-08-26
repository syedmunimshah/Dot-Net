using System.Net.Mail;

namespace DapperApiCore.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }

        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public string Response { get; set; }


    }
}
