using System.Collections.Generic;
using System.Data.SqlClient;

namespace TaskManager
{
    public static class TaskService
    {
        private static readonly string connectionString =
            "Server=localhost;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static List<TaskItem> LoadTasks()
        {
            var tasks = new List<TaskItem>();
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var cmd = new SqlCommand("SELECT Id, Name, IsCompleted FROM Tasks", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new TaskItem
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    IsCompleted = reader.GetBoolean(2)
                });
            }

            return tasks;
        }

        public static void AddTask(TaskItem task)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Tasks (Name, IsCompleted) VALUES (@Name, @IsCompleted)", conn);
            cmd.Parameters.AddWithValue("@Name", task.Name);
            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateTask(TaskItem task)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand("UPDATE Tasks SET Name = @Name, IsCompleted = @IsCompleted WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", task.Id);
            cmd.Parameters.AddWithValue("@Name", task.Name);
            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteTask(int id)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Tasks WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
