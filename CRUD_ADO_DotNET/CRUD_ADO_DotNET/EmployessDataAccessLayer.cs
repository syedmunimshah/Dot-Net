using CRUD_ADO_DotNET.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ADO_DotNET
{
    public class EmployessDataAccessLayer
    {
        string cs=ConnectionString.dbcs;

        public List<Employess> GetEmployesses()
        {
            List<Employess> empList = new List<Employess>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployee",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employess emp=new Employess();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.name = reader["name"].ToString() ?? "";
                    emp.gender = reader["gender"].ToString()??"";
                    emp.age = Convert.ToInt32(reader["age"]);
                    emp.designation = reader["designation"].ToString() ?? "";
                    emp.city = reader["city"].ToString() ?? "";
                    empList.Add(emp);
                }
            }
            return empList;
           
        }

        //public Employess GetEmployeeById(int? id)
        //{
        //    using (SqlConnection con = new SqlConnection())
        //    {

        //    }
        //}

        public void AddEmployee(Employess emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmpoyee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.name);
                cmd.Parameters.AddWithValue("@gender", emp.gender);
                cmd.Parameters.AddWithValue("@age", emp.age);
                cmd.Parameters.AddWithValue("@designation", emp.designation);
                cmd.Parameters.AddWithValue("@city", emp.city);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}
