using Dapper;
using DapperApiCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
namespace DapperApiCore.Services
{
    public class StudentService : IStudentServices
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public string provideName { get; }
        public StudentService(IConfiguration configuration)

        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("StudentDB");
            provideName = "System.Data.SqlClient";
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public string DeleteStudent(int StudentId)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var stud = dbConnection.Query<Student>("DeleteStuent", new{StudentId =StudentId,},
                        commandType: CommandType.StoredProcedure);
                    if (stud != null && stud.FirstOrDefault().Response == "Delete Sucessfully")
                    {
                        return "Delete Sucessfully";
                    }

                    dbConnection.Close();
                    return result;

                }
            }
            catch (Exception ex)
            {

                string errorMsg = ex.Message;
                return errorMsg;
            }
        }



        public IEnumerable<Student> GetStudentList()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (IDbConnection dbConnection=Connection)
                {
                    dbConnection.Open();
                    students = dbConnection.Query<Student>("GetStudentList", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return students;
                   
                }
            }
            catch (Exception ex)
            {

                string errorMsg = ex.Message;
                return students;
            }
        }

        public string InsertStudent(Student student)
        {
            string result= "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var stud = dbConnection.Query<Student>("InsertStuent",
         new { StudentName=student.StudentName, EmailAddress=student.EmailAddress,City=student.City,
                CreatedBy=student.CreatedBy}, commandType: CommandType.StoredProcedure);
                    if (stud !=null && stud.FirstOrDefault().Response== "Save Sucessfully")
                    {
                        return "Save Sucessfully";
                    }

                    dbConnection.Close();
                    return result;
                  
                }
            }
            catch (Exception ex)
            {

                string errorMsg = ex.Message;
                return errorMsg;
            }
        }

        public string UpdatetStudent(Student student)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var stud = dbConnection.Query<Student>("UpdateStuent",
         new
         {
             StudentName = student.StudentName,
             EmailAddress = student.EmailAddress,
             City = student.City,
             CreatedBy = student.CreatedBy,
             StudentId=student.StudentId,
         }, commandType: CommandType.StoredProcedure);
                    if (stud != null && stud.FirstOrDefault().Response == "Save Sucessfully")
                    {
                        return "Save Sucessfully";
                    }

                    dbConnection.Close();
                    return result;

                }
            }
            catch (Exception ex)
            {

                string errorMsg = ex.Message;
                return errorMsg;
            }
        }
    }
}
