using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataRetrive
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string connectionString = @"server =HP\SQLEXPRESS ; database = StudentDB; Integrated security =sspi; Trusted_connection =true";
            SqlConnection conn = new SqlConnection(connectionString);
            RetrieveStudents(conn);
        }

        private static void RetrieveStudents(SqlConnection conn)
        {     conn.Open();
            try
            {
                Console.WriteLine("The students who has  Grade more than 85 are :");
                string query = "select * from students where grade > @Grade";
                SqlCommand GetStudentByGrade = new SqlCommand(query, conn);
                GetStudentByGrade.Parameters.AddWithValue("Grade", 85);
                GetStudentByGrade.ExecuteNonQuery();
                SqlDataReader reader = GetStudentByGrade.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + "   " + reader["FirstName"] + "   " + reader["age"] + "   " + reader["grade"]);
                }
                reader.Close();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                conn.Close();
                Console.Read();
                
            }

            

        }
    }
}
