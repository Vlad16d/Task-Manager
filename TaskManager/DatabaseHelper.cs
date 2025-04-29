using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace TaskManager
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static List<TaskItem> LoadTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, IsCompleted FROM Tasks";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        IsCompleted = reader.GetBoolean(2)
                    });
                }
            }

            return tasks;
        }

        public static void AddTask(TaskItem task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Tasks (Name, IsCompleted) VALUES (@Name, @IsCompleted)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", task.Name);
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateTask(TaskItem task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Tasks SET Name = @Name, IsCompleted = @IsCompleted WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@Name", task.Name);
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteTask(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Tasks WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public static void SaveTasks(List<TaskItem> tasks)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Удаляем все старые записи
                var deleteCmd = new SqlCommand("DELETE FROM TaskItems", connection);
                deleteCmd.ExecuteNonQuery();

                // Вставляем заново
                foreach (var task in tasks)
                {
                    var insertCmd = new SqlCommand("INSERT INTO TaskItems (Name, IsCompleted) VALUES (@Name, @IsCompleted)", connection);
                    insertCmd.Parameters.AddWithValue("@Name", task.Name);
                    insertCmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

    }
}
