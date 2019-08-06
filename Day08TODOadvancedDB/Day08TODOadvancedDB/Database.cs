using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08TODOadvancedDB
{
    public class Database
    {
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\1896190\Documents\ipd17-dotnet\Day08TODOadvancedDB\ToDoDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
        }

        public List<ToDo> GetAllToDos()
        {
            List<ToDo> result = new List<ToDo>();
            SqlCommand command = new SqlCommand("SELECT * FROM ToDos", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // while there is another record present
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string task = (string)reader["Task"];
                    string status = (string)reader["Status"];
                    string duedate = (string)reader["DueDate"];
                    ToDo todo = new ToDo() { Id = id, Task=task, Status=status, DueDate= duedate};
                    result.Add(todo);
                }
            }
            return result;
        }

        public void AddToDo(ToDo todo)
        {
            SqlCommand command = new SqlCommand("INSERT INTO ToDos (Task, Status, DueDate) VALUES (@Task, @Status, @DueDate)", conn);
            command.Parameters.AddWithValue("@Task", todo.Task);
            command.Parameters.AddWithValue("@Status", todo.Status);
            command.Parameters.AddWithValue("@DueDate", todo.DueDate);
            command.ExecuteNonQuery();
        }

        public void UpdateToDo(ToDo todo)
        {          
            SqlCommand command = new SqlCommand("UPDATE ToDos SET Task=@Task, Status=@Status, DueDate=@DueDate WHERE Id=@Id", conn);
            command.Parameters.AddWithValue("@Task", todo.Task);
            command.Parameters.AddWithValue("@Status", todo.Status);
            command.Parameters.AddWithValue("@DueDate", todo.DueDate);
            command.Parameters.AddWithValue("@Id", todo.Id);
            command.ExecuteNonQuery();
        }

        public void DeleteToDo(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ToDos WHERE Id=@Id", conn);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
